using Npgsql;
using Oil.Helpers;
using Oil.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace Oil
{
    partial class OilLotEditForm : Form
    {
        private int _oilLotId = -1; // -1 = новая запись
        private bool _isEditMode = false;

        // КОНСТРУКТОР 1: Для добавления новой партии
        public OilLotEditForm()
        {
            InitializeComponent();
            // Устанавливаем заголовок для добавления
            lblTitle.Text = "Добавить партию нефти";
            Text = "Oil System - Добавление партии нефти";
        }

        // КОНСТРУКТОР 2: Для редактирования существующей партии
        public OilLotEditForm(int oilLotId)
        {
            InitializeComponent();
            _oilLotId = oilLotId;
            _isEditMode = true;
            // Устанавливаем заголовок для редактирования
            lblTitle.Text = "Редактировать партию нефти";
            Text = "Oil System - Редактирование партии нефти";
        }

        private void OilLotEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Проверка подключения к БД
                if (!DbMethods.TestConnection())
                {
                    MessageBox.Show("Нет подключения к базе данных!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Загружаем данные в выпадающие списки
                LoadComboBoxData();

                // Если редактируем, загружаем данные партии
                if (_isEditMode)
                {
                    LoadOilLotData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке формы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxData()
        {
            try
            {
                // 1. Загружаем месторождения
                string oilfieldQuery = @"
                    SELECT o.oilfield_id, 
                           nof.oilfield_name || ' (' || r.region_name || ')' as display_name
                    FROM oilfield o
                    JOIN name_of_oilfield nof ON o.name_of_oilfield_id = nof.name_of_oilfield_id
                    JOIN region r ON o.region_id = r.region_id
                    ORDER BY nof.oilfield_name";

                DataTable oilfields = DbMethods.GetData(oilfieldQuery);
                cbxOilfield.DataSource = oilfields;
                cbxOilfield.DisplayMember = "display_name";
                cbxOilfield.ValueMember = "oilfield_id";

                // 2. Загружаем цвета
                DataTable colors = DbMethods.GetData("SELECT color_id, color_name FROM color ORDER BY color_name");
                cbxColor.DataSource = colors;
                cbxColor.DisplayMember = "color_name";
                cbxColor.ValueMember = "color_id";

                // 3. Загружаем фракции
                DataTable fractions = DbMethods.GetData("SELECT oil_fraction_id, fraction FROM oil_fraction ORDER BY fraction");
                cbxFraction.DataSource = fractions;
                cbxFraction.DisplayMember = "fraction";
                cbxFraction.ValueMember = "oil_fraction_id";

                // 4. Загружаем плотность
                DataTable densities = DbMethods.GetData("SELECT oil_density_id, density FROM oil_density ORDER BY oil_density_id");
                cbxDensity.DataSource = densities;
                cbxDensity.DisplayMember = "density";
                cbxDensity.ValueMember = "oil_density_id";

                // 5. Загружаем вязкость
                DataTable viscosities = DbMethods.GetData("SELECT oil_viscosity_id, viscosity FROM oil_viscosity ORDER BY oil_viscosity_id");
                cbxViscosity.DataSource = viscosities;
                cbxViscosity.DisplayMember = "viscosity";
                cbxViscosity.ValueMember = "oil_viscosity_id";

                // 6. Загружаем содержание серы
                DataTable sulfur = DbMethods.GetData("SELECT oil_sulfur_content_id, sulfur_content FROM oil_sulfur_content ORDER BY oil_sulfur_content_id");
                cbxSulfurContent.DataSource = sulfur;
                cbxSulfurContent.DisplayMember = "sulfur_content";
                cbxSulfurContent.ValueMember = "oil_sulfur_content_id";

                // 7. Загружаем содержание смол
                DataTable resin = DbMethods.GetData("SELECT oil_resin_content_id, resin_content FROM oil_resin_content ORDER BY oil_resin_content_id");
                cbxResinContent.DataSource = resin;
                cbxResinContent.DisplayMember = "resin_content";
                cbxResinContent.ValueMember = "oil_resin_content_id";

                // 8. Загружаем содержание парафина
                DataTable paraffin = DbMethods.GetData("SELECT oil_paraffin_content_id, paraffin_content FROM oil_paraffin_content ORDER BY oil_paraffin_content_id");
                cbxParaffinContent.DataSource = paraffin;
                cbxParaffinContent.DisplayMember = "paraffin_content";
                cbxParaffinContent.ValueMember = "oil_paraffin_content_id";

                // 9. Загружаем температуру вспышки
                DataTable flashPoint = DbMethods.GetData("SELECT oil_flash_point_id, flash_point_class FROM oil_flash_point ORDER BY oil_flash_point_id");
                cbxFlashPoint.DataSource = flashPoint;
                cbxFlashPoint.DisplayMember = "flash_point_class";
                cbxFlashPoint.ValueMember = "oil_flash_point_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOilLotData()
        {
            try
            {
                string query = $@"
                    SELECT 
                        number_of_oil_lot,
                        date_of_extraction,
                        oilfield_id,
                        color_id,
                        oil_fraction_id,
                        oil_density_id,
                        oil_viscosity_id,
                        oil_sulfur_content_id,
                        oil_resin_content_id,
                        oil_paraffin_content_id,
                        oil_flash_point_id
                    FROM oil_lot 
                    WHERE oil_lot_id = {_oilLotId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtLotNumber.Text = row["number_of_oil_lot"].ToString();
                    dtpExtractionDate.Value = Convert.ToDateTime(row["date_of_extraction"]);

                    // Устанавливаем значения в выпадающие списки
                    SetComboBoxValue(cbxOilfield, row["oilfield_id"]);
                    SetComboBoxValue(cbxColor, row["color_id"]);
                    SetComboBoxValue(cbxFraction, row["oil_fraction_id"]);
                    SetComboBoxValue(cbxDensity, row["oil_density_id"]);
                    SetComboBoxValue(cbxViscosity, row["oil_viscosity_id"]);
                    SetComboBoxValue(cbxSulfurContent, row["oil_sulfur_content_id"]);
                    SetComboBoxValue(cbxResinContent, row["oil_resin_content_id"]);
                    SetComboBoxValue(cbxParaffinContent, row["oil_paraffin_content_id"]);
                    SetComboBoxValue(cbxFlashPoint, row["oil_flash_point_id"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных партии: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetComboBoxValue(ComboBox comboBox, object value)
        {
            try
            {
                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    DataRowView item = (DataRowView)comboBox.Items[i];
                    if (item.Row[comboBox.ValueMember].ToString() == value.ToString())
                    {
                        comboBox.SelectedIndex = i;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка установки значения в ComboBox: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что все поля заполнены
                if (string.IsNullOrWhiteSpace(txtLotNumber.Text))
                {
                    MessageBox.Show("Введите номер партии!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLotNumber.Focus();
                    return;
                }

                // Проверяем, что все выпадающие списки выбраны
                if (cbxOilfield.SelectedIndex == -1 ||
                    cbxColor.SelectedIndex == -1 ||
                    cbxFraction.SelectedIndex == -1 ||
                    cbxDensity.SelectedIndex == -1 ||
                    cbxViscosity.SelectedIndex == -1 ||
                    cbxSulfurContent.SelectedIndex == -1 ||
                    cbxResinContent.SelectedIndex == -1 ||
                    cbxParaffinContent.SelectedIndex == -1 ||
                    cbxFlashPoint.SelectedIndex == -1)
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string lotNumber = txtLotNumber.Text.Trim();
                string extractionDate = dtpExtractionDate.Value.ToString("yyyy-MM-dd");
                int oilfieldId = Convert.ToInt32(cbxOilfield.SelectedValue);
                int colorId = Convert.ToInt32(cbxColor.SelectedValue);
                int fractionId = Convert.ToInt32(cbxFraction.SelectedValue);
                int densityId = Convert.ToInt32(cbxDensity.SelectedValue);
                int viscosityId = Convert.ToInt32(cbxViscosity.SelectedValue);
                int sulfurId = Convert.ToInt32(cbxSulfurContent.SelectedValue);
                int resinId = Convert.ToInt32(cbxResinContent.SelectedValue);
                int paraffinId = Convert.ToInt32(cbxParaffinContent.SelectedValue);
                int flashPointId = Convert.ToInt32(cbxFlashPoint.SelectedValue);

                if (_isEditMode)
                {
                    // Обновляем существующую запись
                    string updateQuery = $@"
                        UPDATE oil_lot SET
                            number_of_oil_lot = '{lotNumber}',
                            date_of_extraction = '{extractionDate}',
                            oilfield_id = {oilfieldId},
                            color_id = {colorId},
                            oil_fraction_id = {fractionId},
                            oil_density_id = {densityId},
                            oil_viscosity_id = {viscosityId},
                            oil_sulfur_content_id = {sulfurId},
                            oil_resin_content_id = {resinId},
                            oil_paraffin_content_id = {paraffinId},
                            oil_flash_point_id = {flashPointId}
                        WHERE oil_lot_id = {_oilLotId}";

                    bool success = DbMethods.Execute(updateQuery);
                    if (success)
                    {
                        MessageBox.Show("Партия успешно обновлена!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // Добавляем новую запись
                    // Сначала проверяем, нет ли уже такой партии
                    string checkQuery = $"SELECT COUNT(*) FROM oil_lot WHERE number_of_oil_lot = '{lotNumber}'";
                    DataTable dt = DbMethods.GetData(checkQuery);
                    int count = Convert.ToInt32(dt.Rows[0][0]);

                    if (count > 0)
                    {
                        MessageBox.Show("Партия с таким номером уже существует!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string insertQuery = $@"
                        INSERT INTO oil_lot (
                            number_of_oil_lot,
                            date_of_extraction,
                            oilfield_id,
                            color_id,
                            oil_fraction_id,
                            oil_density_id,
                            oil_viscosity_id,
                            oil_sulfur_content_id,
                            oil_resin_content_id,
                            oil_paraffin_content_id,
                            oil_flash_point_id
                        ) VALUES (
                            '{lotNumber}',
                            '{extractionDate}',
                            {oilfieldId},
                            {colorId},
                            {fractionId},
                            {densityId},
                            {viscosityId},
                            {sulfurId},
                            {resinId},
                            {paraffinId},
                            {flashPointId}
                        )";

                    bool success = DbMethods.Execute(insertQuery);
                    if (success)
                    {
                        MessageBox.Show("Партия успешно добавлена!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
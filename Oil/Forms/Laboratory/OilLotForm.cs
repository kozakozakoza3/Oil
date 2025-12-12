using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using Oil.Helpers;
using Oil.Models;

namespace Oil
{
    partial class OilLotForm : Form
    {
        public OilLotForm()
        {
            InitializeComponent();
        }

        private void LoadOilLots()
        {
            try
            {
                string query = @"
                    SELECT 
                        ol.oil_lot_id,
                        ol.number_of_oil_lot,
                        ol.date_of_extraction,
                        nof.oilfield_name,
                        r.region_name,
                        c.color_name,
                        ofr.fraction,
                        CONCAT(od.min_oil_density, ' - ', od.max_oil_density, ' ', od.unit_of_measure) AS density_range,
                        CONCAT(ov.min_oil_viscosity, ' - ', ov.max_oil_viscosity, ' ', ov.unit_of_measure) AS viscosity_range,
                        CONCAT(osc.min_oil_sulfur_content, ' - ', osc.max_oil_sulfur_content, ' ', osc.unit_of_measure) AS sulfur_content_range,
                        CONCAT(orc.min_oil_resin_content, ' - ', orc.max_oil_resin_content, ' ', orc.unit_of_measure) AS resin_content_range,
                        CONCAT(opc.min_oil_paraffin_content, ' - ', opc.max_oil_paraffin_content, ' ', opc.unit_of_measure) AS paraffin_content_range,
                        CONCAT(ofp.min_oil_flash_point, ' - ', ofp.max_oil_flash_point, ' ', ofp.unit_of_measure) AS flash_point_range
                    FROM oil_lot ol
                    JOIN oilfield o ON ol.oilfield_id = o.oilfield_id
                    JOIN name_of_oilfield nof ON o.name_of_oilfield_id = nof.name_of_oilfield_id
                    JOIN region r ON o.region_id = r.region_id
                    JOIN color c ON ol.color_id = c.color_id
                    JOIN oil_fraction ofr ON ol.oil_fraction_id = ofr.oil_fraction_id
                    JOIN oil_density od ON ol.oil_density_id = od.oil_density_id
                    JOIN oil_viscosity ov ON ol.oil_viscosity_id = ov.oil_viscosity_id
                    JOIN oil_sulfur_content osc ON ol.oil_sulfur_content_id = osc.oil_sulfur_content_id
                    JOIN oil_resin_content orc ON ol.oil_resin_content_id = orc.oil_resin_content_id
                    JOIN oil_paraffin_content opc ON ol.oil_paraffin_content_id = opc.oil_paraffin_content_id
                    JOIN oil_flash_point ofp ON ol.oil_flash_point_id = ofp.oil_flash_point_id
                    ORDER BY ol.number_of_oil_lot";

                DataTable dt = DbMethods.GetData(query);
                dgvOilLots.DataSource = dt;

                // Настройка заголовков колонок
                if (dgvOilLots.Columns.Count > 0)
                {
                    dgvOilLots.Columns["oil_lot_id"].Visible = false; // Скрываем ID
                    dgvOilLots.Columns["number_of_oil_lot"].HeaderText = "Номер партии";
                    dgvOilLots.Columns["date_of_extraction"].HeaderText = "Дата добычи";
                    dgvOilLots.Columns["oilfield_name"].HeaderText = "Месторождение";
                    dgvOilLots.Columns["region_name"].HeaderText = "Регион";
                    dgvOilLots.Columns["color_name"].HeaderText = "Цвет";
                    dgvOilLots.Columns["fraction"].HeaderText = "Фракция";
                    dgvOilLots.Columns["density_range"].HeaderText = "Плотность";
                    dgvOilLots.Columns["viscosity_range"].HeaderText = "Вязкость";
                    dgvOilLots.Columns["sulfur_content_range"].HeaderText = "Содержание серы";
                    dgvOilLots.Columns["resin_content_range"].HeaderText = "Содержание смол";
                    dgvOilLots.Columns["paraffin_content_range"].HeaderText = "Содержание парафина";
                    dgvOilLots.Columns["flash_point_range"].HeaderText = "Темп. вспышки";

                    // Настройка ширины колонок
                    dgvOilLots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Форматирование даты
                    dgvOilLots.Columns["date_of_extraction"].DefaultCellStyle.Format = "dd.MM.yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OilLotForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadOilLots();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке формы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OilLotEditForm editForm = new OilLotEditForm();
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadOilLots();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOilLots.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvOilLots.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["oil_lot_id"].Value);

                    OilLotEditForm editForm = new OilLotEditForm(id);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadOilLots();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите запись для редактирования", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOilLots.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvOilLots.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["oil_lot_id"].Value);
                    string lotNumber = row.Cells["number_of_oil_lot"].Value.ToString();

                    var result = MessageBox.Show($"Вы уверены, что хотите удалить партию {lotNumber}?",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Проверяем, есть ли связанные записи
                        string checkQuery = $"SELECT COUNT(*) FROM oil_lot_in_tank WHERE oil_lot_id = {id}";
                        DataTable dt = DbMethods.GetData(checkQuery);
                        int count = Convert.ToInt32(dt.Rows[0][0]);

                        if (count > 0)
                        {
                            MessageBox.Show("Невозможно удалить партию, так как она находится в резервуаре!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        bool success = DbMethods.Delete("oil_lot", id);
                        if (success)
                        {
                            MessageBox.Show("Партия успешно удалена", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOilLots();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите запись для удаления", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOilLots();
        }

        private void dgvOilLots_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }
    }
}
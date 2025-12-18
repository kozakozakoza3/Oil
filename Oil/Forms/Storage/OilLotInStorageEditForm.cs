using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using Oil.Helpers;
using Oil.Models;

namespace Oil
{
    partial class OilLotInStorageEditForm : Form
    {
        private int _oilLotInTankId = -1; // -1 = новая запись
        private bool _isEditMode = false;

        // КОНСТРУКТОР 1: Для добавления новой партии в резервуар
        public OilLotInStorageEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавить партию нефти в резервуар";
            Text = "Oil System - Добавление партии нефти в резервуар";
        }

        // КОНСТРУКТОР 2: Для редактирования существующей записи
        public OilLotInStorageEditForm(int oilLotInTankId)
        {
            InitializeComponent();
            _oilLotInTankId = oilLotInTankId;
            _isEditMode = true;
            lblTitle.Text = "Редактировать партию нефти в резервуаре";
            Text = "Oil System - Редактирование партии нефти в резервуаре";
        }

        private void OilLotInStorageEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (!DbMethods.TestConnection())
                {
                    MessageBox.Show("Нет подключения к базе данных!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Загружаем данные в выпадающие списки
                LoadComboBoxData();

                // Если редактируем, загружаем данные
                if (_isEditMode)
                {
                    LoadOilLotInStorageData();
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
                // 1. Загружаем партии нефти
                string oilLotQuery = @"
                    SELECT ol.oil_lot_id, 
                           ol.number_of_oil_lot || ' (' || nof.oilfield_name || ')' as display_name
                    FROM oil_lot ol
                    JOIN oilfield o ON ol.oilfield_id = o.oilfield_id
                    JOIN name_of_oilfield nof ON o.name_of_oilfield_id = nof.name_of_oilfield_id
                    ORDER BY ol.number_of_oil_lot";

                DataTable oilLots = DbMethods.GetData(oilLotQuery);
                cbxOilLot.DataSource = oilLots;
                cbxOilLot.DisplayMember = "display_name";
                cbxOilLot.ValueMember = "oil_lot_id";

                // 2. Загружаем резервуары
                DataTable tanks = DbMethods.GetData(@"
                    SELECT t.tank_id, 
                           t.tank_id || ' (' || t.tank_capacity || ' ' || t.unit_of_measure || ')' as display_name
                    FROM tank t
                    ORDER BY t.tank_id");

                cbxTank.DataSource = tanks;
                cbxTank.DisplayMember = "display_name";
                cbxTank.ValueMember = "tank_id";

                // Устанавливаем единицы измерения по умолчанию
                txtUnitMeasure.Text = "м³";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOilLotInStorageData()
        {
            try
            {
                string query = $@"
                    SELECT 
                        oil_lot_id,
                        tank_id,
                        oil_lot_size,
                        unit_of_measure
                    FROM oil_lot_in_tank 
                    WHERE oil_lot_in_tank_id = {_oilLotInTankId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtLotSize.Text = row["oil_lot_size"].ToString();
                    txtUnitMeasure.Text = row["unit_of_measure"].ToString();

                    SetComboBoxValue(cbxOilLot, row["oil_lot_id"]);
                    SetComboBoxValue(cbxTank, row["tank_id"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
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
                MessageBox.Show($"Ошибка установки значения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что все поля заполнены
                if (string.IsNullOrWhiteSpace(txtLotSize.Text))
                {
                    MessageBox.Show("Введите объем партии!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtLotSize.Focus();
                    return;
                }

                // Проверяем, что все выпадающие списки выбраны
                if (cbxOilLot.SelectedIndex == -1 || cbxTank.SelectedIndex == -1)
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int lotSize = Convert.ToInt32(txtLotSize.Text);
                string unitMeasure = txtUnitMeasure.Text.Trim();
                int oilLotId = Convert.ToInt32(cbxOilLot.SelectedValue);
                int tankId = Convert.ToInt32(cbxTank.SelectedValue);

                if (_isEditMode)
                {
                    // Обновляем существующую запись
                    string updateQuery = $@"
                        UPDATE oil_lot_in_tank SET
                            oil_lot_id = {oilLotId},
                            tank_id = {tankId},
                            oil_lot_size = {lotSize},
                            unit_of_measure = '{unitMeasure}'
                        WHERE oil_lot_in_tank_id = {_oilLotInTankId}";

                    bool success = DbMethods.Execute(updateQuery);
                    if (success)
                    {
                        MessageBox.Show("Запись успешно обновлена!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // Добавляем новую запись
                    // Проверяем, нет ли уже этой партии в другом резервуаре
                    string checkQuery = $"SELECT COUNT(*) FROM oil_lot_in_tank WHERE oil_lot_id = {oilLotId}";
                    DataTable dt = DbMethods.GetData(checkQuery);
                    int count = Convert.ToInt32(dt.Rows[0][0]);

                    if (count > 0)
                    {
                        MessageBox.Show("Эта партия уже находится в резервуаре!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string insertQuery = $@"
                        INSERT INTO oil_lot_in_tank (
                            oil_lot_id,
                            tank_id,
                            oil_lot_size,
                            unit_of_measure
                        ) VALUES (
                            {oilLotId},
                            {tankId},
                            {lotSize},
                            '{unitMeasure}'
                        )";

                    bool success = DbMethods.Execute(insertQuery);
                    if (success)
                    {
                        MessageBox.Show("Партия успешно добавлена в резервуар!", "Успех",
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
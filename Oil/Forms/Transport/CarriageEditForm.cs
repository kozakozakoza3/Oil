using System;
using System.Data;
using System.Windows.Forms;
using Oil.Helpers;

namespace Oil.Forms.Transport
{
    public partial class CarriageEditForm : Form
    {
        private int _carriageId = -1;
        private bool _isEditMode = false;

        public CarriageEditForm()
        {
            InitializeComponent();
            Text = "Добавление вагона";
        }

        public CarriageEditForm(int carriageId)
        {
            InitializeComponent();
            _carriageId = carriageId;
            _isEditMode = true;
            Text = "Редактирование вагона";
        }

        private void CarriageEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxData();
                if (_isEditMode)
                {
                    LoadCarriageData();
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
                // Типы вагонов
                DataTable carriageTypes = DbMethods.GetData(@"
                    SELECT carriage_type_id, 
                           carriage_type_name || ' (' || carriage_capacity || ' ' || unit_of_measure || ')' as display_name
                    FROM carriage_type 
                    ORDER BY carriage_type_name");
                cbxType.DataSource = carriageTypes;
                cbxType.DisplayMember = "display_name";
                cbxType.ValueMember = "carriage_type_id";

                // Поезда (можно выбрать "не назначен")
                DataTable trains = DbMethods.GetData(@"
                    SELECT train_id, 
                           'Поезд №' || train_id || ': ' || train_name as display_name
                    FROM train 
                    ORDER BY train_id");
                cbxTrain.DataSource = trains;
                cbxTrain.DisplayMember = "display_name";
                cbxTrain.ValueMember = "train_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCarriageData()
        {
            try
            {
                string query = $@"
                    SELECT 
                        vin_number,
                        load_capacity,
                        unit_of_measure,
                        carriage_type_id,
                        train_id
                    FROM carriage 
                    WHERE carriage_id = {_carriageId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtVinNumber.Text = SafeConverter.ToString(row["vin_number"]);
                    txtLoadCapacity.Text = SafeConverter.ToString(row["load_capacity"]);
                    txtUnitMeasure.Text = SafeConverter.ToString(row["unit_of_measure"]);

                    // Устанавливаем значения в комбобоксы
                    SetComboBoxValue(cbxType, row["carriage_type_id"]);
                    SetComboBoxValue(cbxTrain, row["train_id"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных вагона: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetComboBoxValue(ComboBox comboBox, object value)
        {
            try
            {
                if (value == null || value == DBNull.Value || Convert.ToInt32(value) == 0)
                {
                    comboBox.SelectedIndex = -1;
                    return;
                }

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
                // Проверяем обязательные поля
                if (!ValidateRequiredFields())
                {
                    return;
                }

                // Получаем значения из формы
                var carriageData = GetCarriageData();

                if (_isEditMode)
                {
                    // Обновляем существующую запись
                    UpdateCarriage(carriageData);
                }
                else
                {
                    // Добавляем новую запись
                    AddNewCarriage(carriageData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateRequiredFields()
        {
            if (string.IsNullOrWhiteSpace(txtVinNumber.Text))
            {
                MessageBox.Show("Введите VIN-номер!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVinNumber.Focus();
                return false;
            }

            if (txtVinNumber.Text.Length != 8)
            {
                MessageBox.Show("VIN-номер должен содержать 8 символов!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtVinNumber.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLoadCapacity.Text))
            {
                MessageBox.Show("Введите грузоподъемность!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoadCapacity.Focus();
                return false;
            }

            if (!int.TryParse(txtLoadCapacity.Text, out int capacity) || capacity <= 0)
            {
                MessageBox.Show("Грузоподъемность должна быть положительным числом!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLoadCapacity.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUnitMeasure.Text))
            {
                MessageBox.Show("Введите единицу измерения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnitMeasure.Focus();
                return false;
            }

            if (cbxType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип вагона!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxType.Focus();
                return false;
            }

            // Поезд может быть не выбран (NULL)

            // Проверка уникальности VIN-номера
            if (!ValidateUniqueVinNumber())
            {
                return false;
            }

            return true;
        }

        private bool ValidateUniqueVinNumber()
        {
            string vinNumber = txtVinNumber.Text.Trim().ToUpper();
            string condition = _isEditMode ? $"AND carriage_id != {_carriageId}" : "";

            string checkQuery = $@"
                SELECT COUNT(*) FROM carriage 
                WHERE vin_number = '{vinNumber.Replace("'", "''")}' {condition}";

            DataTable dt = DbMethods.GetData(checkQuery);
            int count = Convert.ToInt32(dt.Rows[0][0]);

            if (count > 0)
            {
                MessageBox.Show("Вагон с таким VIN-номером уже существует!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private (string VinNumber, int LoadCapacity, string UnitMeasure, int TypeId, int? TrainId) GetCarriageData()
        {
            int? trainId = cbxTrain.SelectedIndex == -1 ?
                (int?)null : Convert.ToInt32(cbxTrain.SelectedValue);

            return (
                txtVinNumber.Text.Trim().ToUpper(),
                Convert.ToInt32(txtLoadCapacity.Text),
                txtUnitMeasure.Text.Trim(),
                Convert.ToInt32(cbxType.SelectedValue),
                trainId
            );
        }

        private void UpdateCarriage((string VinNumber, int LoadCapacity, string UnitMeasure, int TypeId, int? TrainId) data)
        {
            string trainIdValue = data.TrainId.HasValue ? data.TrainId.Value.ToString() : "NULL";

            string updateQuery = $@"
                UPDATE carriage SET
                    vin_number = '{data.VinNumber}',
                    load_capacity = {data.LoadCapacity},
                    unit_of_measure = '{data.UnitMeasure}',
                    carriage_type_id = {data.TypeId},
                    train_id = {trainIdValue}
                WHERE carriage_id = {_carriageId}";

            bool success = DbMethods.Execute(updateQuery);
            if (success)
            {
                MessageBox.Show("Вагон успешно обновлён!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось обновить вагон!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewCarriage((string VinNumber, int LoadCapacity, string UnitMeasure, int TypeId, int? TrainId) data)
        {
            string trainIdValue = data.TrainId.HasValue ? data.TrainId.Value.ToString() : "NULL";

            string insertQuery = $@"
                INSERT INTO carriage (
                    vin_number,
                    load_capacity,
                    unit_of_measure,
                    carriage_type_id,
                    train_id
                ) VALUES (
                    '{data.VinNumber}',
                    {data.LoadCapacity},
                    '{data.UnitMeasure}',
                    {data.TypeId},
                    {trainIdValue}
                )";

            bool success = DbMethods.Execute(insertQuery);
            if (success)
            {
                MessageBox.Show("Вагон успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось добавить вагон!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtVinNumber_TextChanged(object sender, EventArgs e)
        {
            // Автоматическое преобразование в верхний регистр
            txtVinNumber.Text = txtVinNumber.Text.ToUpper();
            txtVinNumber.SelectionStart = txtVinNumber.Text.Length;
        }
    }
}
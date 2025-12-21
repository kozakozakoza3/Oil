using System;
using System.Data;
using System.Windows.Forms;
using Oil.Helpers;

namespace Oil.Forms.Transport
{
    public partial class LocomotiveEditForm : Form
    {
        private int _locomotiveId = -1;
        private bool _isEditMode = false;

        public LocomotiveEditForm()
        {
            InitializeComponent();
            Text = "Добавление локомотива";
        }

        public LocomotiveEditForm(int locomotiveId)
        {
            InitializeComponent();
            _locomotiveId = locomotiveId;
            _isEditMode = true;
            Text = "Редактирование локомотива";
        }

        private void LocomotiveEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxData();
                if (_isEditMode)
                {
                    LoadLocomotiveData();
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
                // Типы локомотивов
                DataTable locomotiveTypes = DbMethods.GetData(@"
                    SELECT locomotive_type_id, 
                           CONCAT('Тяга: ', traction_force, ' кН, ', 
                                  'Скорость: ', structural_speed, ' км/ч, ',
                                  'Мощность: ', engine_power, ' кВт') as display_name
                    FROM locomotive_type 
                    ORDER BY locomotive_type_id");
                cbxType.DataSource = locomotiveTypes;
                cbxType.DisplayMember = "display_name";
                cbxType.ValueMember = "locomotive_type_id";

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

        private void LoadLocomotiveData()
        {
            try
            {
                string query = $@"
                    SELECT 
                        state_number_locomotive,
                        locomotive_type_id,
                        train_id
                    FROM locomotive 
                    WHERE locomotive_id = {_locomotiveId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtStateNumber.Text = SafeConverter.ToString(row["state_number_locomotive"]);

                    // Устанавливаем значения в комбобоксы
                    SetComboBoxValue(cbxType, row["locomotive_type_id"]);
                    SetComboBoxValue(cbxTrain, row["train_id"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных локомотива: {ex.Message}", "Ошибка",
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
                var locomotiveData = GetLocomotiveData();

                if (_isEditMode)
                {
                    // Обновляем существующую запись
                    UpdateLocomotive(locomotiveData);
                }
                else
                {
                    // Добавляем новую запись
                    AddNewLocomotive(locomotiveData);
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
            if (string.IsNullOrWhiteSpace(txtStateNumber.Text))
            {
                MessageBox.Show("Введите государственный номер!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStateNumber.Focus();
                return false;
            }

            if (txtStateNumber.Text.Length != 8)
            {
                MessageBox.Show("Государственный номер должен содержать 8 символов!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStateNumber.Focus();
                return false;
            }

            if (cbxType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип локомотива!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxType.Focus();
                return false;
            }

            // Поезд может быть не выбран (NULL)

            // Проверка уникальности государственного номера
            if (!ValidateUniqueStateNumber())
            {
                return false;
            }

            return true;
        }

        private bool ValidateUniqueStateNumber()
        {
            string stateNumber = txtStateNumber.Text.Trim().ToUpper();
            string condition = _isEditMode ? $"AND locomotive_id != {_locomotiveId}" : "";

            string checkQuery = $@"
                SELECT COUNT(*) FROM locomotive 
                WHERE state_number_locomotive = '{stateNumber.Replace("'", "''")}' {condition}";

            DataTable dt = DbMethods.GetData(checkQuery);
            int count = Convert.ToInt32(dt.Rows[0][0]);

            if (count > 0)
            {
                MessageBox.Show("Локомотив с таким государственным номером уже существует!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private (string StateNumber, int TypeId, int? TrainId) GetLocomotiveData()
        {
            int? trainId = cbxTrain.SelectedIndex == -1 ?
                (int?)null : Convert.ToInt32(cbxTrain.SelectedValue);

            return (
                txtStateNumber.Text.Trim().ToUpper(),
                Convert.ToInt32(cbxType.SelectedValue),
                trainId
            );
        }

        private void UpdateLocomotive((string StateNumber, int TypeId, int? TrainId) data)
        {
            string trainIdValue = data.TrainId.HasValue ? data.TrainId.Value.ToString() : "NULL";

            string updateQuery = $@"
                UPDATE locomotive SET
                    state_number_locomotive = '{data.StateNumber}',
                    locomotive_type_id = {data.TypeId},
                    train_id = {trainIdValue}
                WHERE locomotive_id = {_locomotiveId}";

            bool success = DbMethods.Execute(updateQuery);
            if (success)
            {
                MessageBox.Show("Локомотив успешно обновлён!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось обновить локомотив!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewLocomotive((string StateNumber, int TypeId, int? TrainId) data)
        {
            string trainIdValue = data.TrainId.HasValue ? data.TrainId.Value.ToString() : "NULL";

            string insertQuery = $@"
                INSERT INTO locomotive (
                    state_number_locomotive,
                    locomotive_type_id,
                    train_id
                ) VALUES (
                    '{data.StateNumber}',
                    {data.TypeId},
                    {trainIdValue}
                )";

            bool success = DbMethods.Execute(insertQuery);
            if (success)
            {
                MessageBox.Show("Локомотив успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось добавить локомотив!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtStateNumber_TextChanged(object sender, EventArgs e)
        {
            // Автоматическое преобразование в верхний регистр
            txtStateNumber.Text = txtStateNumber.Text.ToUpper();
            txtStateNumber.SelectionStart = txtStateNumber.Text.Length;
        }
    }
}
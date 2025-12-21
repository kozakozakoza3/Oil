using Oil.Helpers;
using System;
using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Oil.Forms.Transport
{
    public partial class TrainEditForm : Form
    {
        private int _trainId = -1;
        private bool _isEditMode = false;

        public TrainEditForm()
        {
            InitializeComponent();
            Text = "Добавление поезда";
        }

        public TrainEditForm(int trainId)
        {
            InitializeComponent();
            _trainId = trainId;
            _isEditMode = true;
            Text = "Редактирование поезда";
        }

        private void TrainEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxData();
                if (_isEditMode)
                {
                    LoadTrainData();
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
                // Статусы поездов
                DataTable trainStatuses = DbMethods.GetData(
                    "SELECT train_status_id, status_name FROM train_status ORDER BY status_name");
                cbxStatus.DataSource = trainStatuses;
                cbxStatus.DisplayMember = "status_name";
                cbxStatus.ValueMember = "train_status_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTrainData()
        {
            try
            {
                string query = $@"
                    SELECT 
                        train_name,
                        train_status_id
                    FROM train 
                    WHERE train_id = {_trainId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtName.Text = SafeConverter.ToString(row["train_name"]);

                    // Устанавливаем значения в комбобоксы
                    SetComboBoxValue(cbxStatus, row["train_status_id"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных поезда: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetComboBoxValue(ComboBox comboBox, object value)
        {
            try
            {
                if (value == null || value == DBNull.Value) return;

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
                var trainData = GetTrainData();

                if (_isEditMode)
                {
                    // Обновляем существующую запись
                    UpdateTrain(trainData);
                }
                else
                {
                    // Добавляем новую запись
                    AddNewTrain(trainData);
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
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название поезда!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }

            if (cbxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите статус поезда!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxStatus.Focus();
                return false;
            }

            // Проверка уникальности названия поезда
            if (!ValidateUniqueName())
            {
                return false;
            }

            return true;
        }

        private bool ValidateUniqueName()
        {
            string trainName = txtName.Text.Trim();
            string condition = _isEditMode ? $"AND train_id != {_trainId}" : "";

            string checkQuery = $@"
                SELECT COUNT(*) FROM train 
                WHERE train_name = '{trainName.Replace("'", "''")}' {condition}";

            DataTable dt = DbMethods.GetData(checkQuery);
            int count = Convert.ToInt32(dt.Rows[0][0]);

            if (count > 0)
            {
                MessageBox.Show("Поезд с таким названием уже существует!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private (string Name, int StatusId) GetTrainData()
        {
            return (
                txtName.Text.Trim(),
                Convert.ToInt32(cbxStatus.SelectedValue)
            );
        }

        private void UpdateTrain((string Name, int StatusId) data)
        {
            string updateQuery = $@"
                UPDATE train SET
                    train_name = '{data.Name.Replace("'", "''")}',
                    train_status_id = {data.StatusId}
                WHERE train_id = {_trainId}";

            bool success = DbMethods.Execute(updateQuery);
            if (success)
            {
                MessageBox.Show("Поезд успешно обновлён!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось обновить поезд!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewTrain((string Name, int StatusId) data)
        {
            string insertQuery = $@"
                INSERT INTO train (
                    train_name,
                    train_status_id
                ) VALUES (
                    '{data.Name.Replace("'", "''")}',
                    {data.StatusId}
                )";

            bool success = DbMethods.Execute(insertQuery);
            if (success)
            {
                MessageBox.Show("Поезд успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось добавить поезд!", "Ошибка",
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
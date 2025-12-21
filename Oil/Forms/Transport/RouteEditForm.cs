using Oil.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace Oil.Forms.Transport
{
    public partial class RouteEditForm : Form
    {
        private int _routeId = -1; // -1 = новая запись
        private bool _isEditMode = false;

        // КОНСТРУКТОР 1: Для добавления нового маршрута
        public RouteEditForm()
        {
            InitializeComponent();
            Text = "Добавление маршрута";
        }

        // КОНСТРУКТОР 2: Для редактирования существующего маршрута
        public RouteEditForm(int routeId)
        {
            InitializeComponent();
            _routeId = routeId;
            _isEditMode = true;
            Text = "Редактирование маршрута";
        }

        private void RouteEditForm_Load(object sender, EventArgs e)
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

                // Устанавливаем текущую дату и время
                dtpDateSending.Value = DateTime.Now;
                dtpDateArrival.Value = DateTime.Now.AddHours(1); // По умолчанию через час

                // Если редактируем, загружаем данные маршрута
                if (_isEditMode)
                {
                    LoadRouteData();
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
                // 1. Загружаем статусы маршрутов
                string statusQuery = @"
                    SELECT 
                        route_status_id,
                        status_name
                    FROM route_status
                    ORDER BY route_status_id";

                DataTable statuses = DbMethods.GetData(statusQuery);
                cbxRouteStatus.DataSource = statuses;
                cbxRouteStatus.DisplayMember = "status_name";
                cbxRouteStatus.ValueMember = "route_status_id";

                // Устанавливаем "Запланирован" по умолчанию для новых записей
                if (!_isEditMode)
                {
                    // Ищем статус "Запланирован" (обычно это id = 1)
                    foreach (DataRowView item in cbxRouteStatus.Items)
                    {
                        if (item["status_name"].ToString() == "Запланирован")
                        {
                            cbxRouteStatus.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRouteData()
        {
            try
            {
                string query = $@"
                    SELECT 
                        route_status_id,
                        date_time_sending,
                        date_time_arrival
                    FROM route 
                    WHERE route_id = {_routeId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Устанавливаем значение в выпадающий список статуса
                    SetComboBoxValue(cbxRouteStatus, row["route_status_id"]);

                    // Заполняем даты
                    if (row["date_time_sending"] != DBNull.Value)
                        dtpDateSending.Value = Convert.ToDateTime(row["date_time_sending"]);

                    if (row["date_time_arrival"] != DBNull.Value)
                        dtpDateArrival.Value = Convert.ToDateTime(row["date_time_arrival"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных маршрута: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetComboBoxValue(ComboBox comboBox, object value)
        {
            try
            {
                if (value == DBNull.Value) return;

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

        private bool ValidateInput()
        {
            // Проверяем обязательные поля
            if (cbxRouteStatus.SelectedValue == null)
            {
                MessageBox.Show("Выберите статус маршрута!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxRouteStatus.Focus();
                return false;
            }

            DateTime sendingDate = dtpDateSending.Value;
            DateTime arrivalDate = dtpDateArrival.Value;

            // Проверяем, что дата прибытия не раньше даты отправки
            if (arrivalDate <= sendingDate)
            {
                MessageBox.Show("Дата прибытия должна быть позже даты отправки!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateArrival.Focus();
                return false;
            }

            // Проверяем разницу во времени (минимум 5 минут)
            TimeSpan timeDifference = arrivalDate - sendingDate;
            if (timeDifference.TotalMinutes < 5)
            {
                MessageBox.Show("Разница между отправкой и прибытием должна быть не менее 5 минут!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateArrival.Focus();
                return false;
            }

            // Проверяем, что дата отправки не в прошлом для новых записей
            if (!_isEditMode && sendingDate < DateTime.Now.AddMinutes(-5))
            {
                DialogResult result = MessageBox.Show(
                    "Дата отправки установлена в прошлом. Вы уверены, что хотите сохранить?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    dtpDateSending.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация полей
                if (!ValidateInput())
                    return;

                // Получаем значения из формы
                int routeStatusId = Convert.ToInt32(cbxRouteStatus.SelectedValue);
                string dateTimeSending = dtpDateSending.Value.ToString("yyyy-MM-dd HH:mm:ss");
                string dateTimeArrival = dtpDateArrival.Value.ToString("yyyy-MM-dd HH:mm:ss");

                if (_isEditMode)
                {
                    // Обновляем существующую запись
                    string updateQuery = $@"
                        UPDATE route SET
                            route_status_id = {routeStatusId},
                            date_time_sending = '{dateTimeSending}',
                            date_time_arrival = '{dateTimeArrival}'
                        WHERE route_id = {_routeId}";

                    bool success = DbMethods.Execute(updateQuery);
                    if (success)
                    {
                        MessageBox.Show("Маршрут успешно обновлен!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить маршрут", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Добавляем новую запись
                    string insertQuery = $@"
                        INSERT INTO route (
                            route_status_id,
                            date_time_sending,
                            date_time_arrival
                        ) VALUES (
                            {routeStatusId},
                            '{dateTimeSending}',
                            '{dateTimeArrival}'
                        )";

                    bool success = DbMethods.Execute(insertQuery);
                    if (success)
                    {
                        MessageBox.Show("Маршрут успешно добавлен!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось добавить маршрут", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dtpDateSending_ValueChanged(object sender, EventArgs e)
        {
            // Автоматически корректируем дату прибытия, если она стала раньше отправки
            if (dtpDateArrival.Value <= dtpDateSending.Value)
            {
                // Устанавливаем прибытие на 1 час позже отправки
                dtpDateArrival.Value = dtpDateSending.Value.AddHours(1);
            }
        }

        private void dtpDateArrival_ValueChanged(object sender, EventArgs e)
        {
            // Проверяем в реальном времени и подсвечиваем поле, если дата неправильная
            if (dtpDateArrival.Value <= dtpDateSending.Value)
            {
                dtpDateArrival.BackColor = Color.LightPink;
                lblDateArrival.ForeColor = Color.Red;
            }
            else
            {
                dtpDateArrival.BackColor = Color.White;
                lblDateArrival.ForeColor = SystemColors.ControlText;
            }
        }
    }
}
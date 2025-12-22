using Oil.Forms.Transport;
using Oil.Helpers;
using Oil.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Oil.Forms.Transport
{
    public partial class RouteForm : Form
    {
        private List<Route> _routes;

        public RouteForm()
        {
            InitializeComponent();
        }

        private void RouteForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                LoadRoutes();
                DisplayRoutes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message, "Ошибка");
            }
        }

        private void LoadRoutes()
        {
            _routes = new List<Route>();

            string sql = @"
                SELECT 
                    r.Route_id,
                    rs.Status_name AS Route_status,
                    r.Date_time_sending,
                    r.Date_time_arrival
                FROM Route r
                LEFT JOIN Route_status rs ON r.Route_status_id = rs.Route_status_id
                ORDER BY r.Date_time_sending DESC";

            DataTable table = DbMethods.GetData(sql);

            foreach (DataRow row in table.Rows)
            {
                try
                {
                    Route route = new Route
                    {
                        Route_id = SafeConverter.ToInt32(row["Route_id"]),
                        Route_status = SafeConverter.ToString(row["Route_status"]),
                        Date_time_sending = SafeConverter.ToDateTime(row["Date_time_sending"]),
                        Date_time_arrival = SafeConverter.ToDateTime(row["Date_time_arrival"])
                    };

                    _routes.Add(route);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка создания Route: {ex.Message}");
                }
            }
        }

        private void DisplayRoutes()
        {
            if (_routes == null || _routes.Count == 0)
            {
                // Отображаем пустую таблицу
                DataTable data = new DataTable();
                data.Columns.Add("Route_id", typeof(int));
                data.Columns.Add("Route_status", typeof(string));
                data.Columns.Add("Date_time_sending", typeof(DateTime));
                data.Columns.Add("Date_time_arrival", typeof(DateTime));
                data.Columns.Add("Duration", typeof(string));

                dgvRoutes.DataSource = data;
                ConfigureDataGridView();
                return;
            }

            // Создаем таблицу для отображения
            DataTable table = new DataTable();

            // Добавляем колонки
            table.Columns.Add("Route_id", typeof(int));
            table.Columns.Add("Route_status", typeof(string));
            table.Columns.Add("Date_time_sending", typeof(DateTime));
            table.Columns.Add("Date_time_arrival", typeof(DateTime));
            table.Columns.Add("Duration", typeof(string));

            // Заполняем данными
            foreach (Route route in _routes)
            {
                string duration = "";
                if (route.Date_time_sending != DateTime.MinValue && route.Date_time_arrival != DateTime.MinValue)
                {
                    TimeSpan span = route.Date_time_arrival - route.Date_time_sending;
                    duration = $"{span.Days} дней {span.Hours} часов {span.Minutes} минут";
                }

                table.Rows.Add(
                    route.Route_id,
                    route.Route_status,
                    route.Date_time_sending,
                    route.Date_time_arrival,
                    duration
                );
            }

            dgvRoutes.DataSource = table;

            // Настраиваем отображение
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            if (dgvRoutes.Columns.Count == 0) return;

            // Скрываем ID
            if (dgvRoutes.Columns.Contains("Route_id"))
            {
                dgvRoutes.Columns["Route_id"].Visible = false;
            }

            // Русские заголовки
            SetColumnHeader("Route_status", "Статус маршрута");
            SetColumnHeader("Date_time_sending", "Дата и время отправки");
            SetColumnHeader("Date_time_arrival", "Дата и время прибытия");
            SetColumnHeader("Duration", "Длительность");

            // Форматирование дат
            if (dgvRoutes.Columns.Contains("Date_time_sending"))
            {
                dgvRoutes.Columns["Date_time_sending"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                dgvRoutes.Columns["Date_time_sending"].Width = 150;
            }

            if (dgvRoutes.Columns.Contains("Date_time_arrival"))
            {
                dgvRoutes.Columns["Date_time_arrival"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                dgvRoutes.Columns["Date_time_arrival"].Width = 150;
            }

            if (dgvRoutes.Columns.Contains("Route_status"))
            {
                dgvRoutes.Columns["Route_status"].Width = 150;
            }

            if (dgvRoutes.Columns.Contains("Duration"))
            {
                dgvRoutes.Columns["Duration"].Width = 200;
            }

            // Растягиваем столбцы по ширине формы
            dgvRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Настройка цвета строк в зависимости от статуса
            dgvRoutes.RowPrePaint += DgvRoutes_RowPrePaint;
        }

        private void DgvRoutes_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvRoutes.Rows.Count) return;

            DataGridViewRow row = dgvRoutes.Rows[e.RowIndex];
            string status = row.Cells["Route_status"].Value?.ToString() ?? "";

            // Цвета в зависимости от статуса
            switch (status)
            {
                case "Запланирован":
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                    break;
                case "В процессе":
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    break;
                case "Завершен":
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    break;
                case "Отложен":
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                    break;
                case "Отменен":
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    break;
                default:
                    row.DefaultCellStyle.BackColor = Color.White;
                    break;
            }
        }

        private void SetColumnHeader(string columnName, string headerText)
        {
            if (dgvRoutes.Columns.Contains(columnName))
            {
                dgvRoutes.Columns[columnName].HeaderText = headerText;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                RouteEditForm form = new RouteEditForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Маршрут добавлен");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvRoutes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите маршрут для редактирования", "Информация");
                return;
            }

            try
            {
                DataGridViewRow row = dgvRoutes.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["Route_id"].Value);

                // Проверяем, можно ли редактировать завершенный маршрут
                string status = row.Cells["Route_status"].Value?.ToString() ?? "";
                if (status == "Завершен")
                {
                    MessageBox.Show("Завершенный маршрут нельзя редактировать", "Предупреждение");
                    return;
                }

                // Передаем ID в форму редактирования
                RouteEditForm form = new RouteEditForm(id);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Изменения сохранены");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRoutes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите маршрут для удаления", "Информация");
                return;
            }

            try
            {
                DataGridViewRow row = dgvRoutes.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["Route_id"].Value);
                string status = row.Cells["Route_status"].Value?.ToString() ?? "";

                // Проверяем активные маршруты
                if (status != "Завершен" && status != "Отменен")
                {
                    MessageBox.Show("Можно удалять только завершенные или отмененные маршруты", "Ошибка");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Удалить маршрут #{id}?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = DbMethods.Delete("Route", id);

                    if (success)
                    {
                        MessageBox.Show("Маршрут удален");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить маршрут", "Ошибка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRoutes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }
    }
}
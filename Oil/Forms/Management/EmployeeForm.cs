using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Oil.Helpers;  // Добавьте этот using
using Oil.Models;

namespace Oil.Forms.Management
{
    public partial class EmployeeForm : Form
    {
        private List<Employee> _employees;

        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                LoadEmployees();
                DisplayEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message, "Ошибка");
            }
        }

        private void LoadEmployees()
        {
            _employees = new List<Employee>();

            string sql = @"
                SELECT 
                    e.Employee_id,
                    e.Last_name,
                    e.Name,
                    e.Middle_name,
                    s.Sex_name,
                    el.Level_name AS Education_level,
                    d.Department_name,
                    p.Post_name,
                    q.Qualification_name,
                    ei.Institution_name AS Educational_institution,
                    e.Passport_series,
                    e.Passport_number,
                    e.Passport_issue_date,
                    e.Who_issued_passport,
                    e.Subdivision_code,
                    e.Phone_number,
                    e.Email,
                    e.Residential_address,
                    e.Registration_address
                FROM Employee e
                LEFT JOIN Sex s ON e.Sex_id = s.Sex_id
                LEFT JOIN Education_level el ON e.Education_level_id = el.Education_level_id
                LEFT JOIN Department d ON e.Department_id = d.Department_id
                LEFT JOIN Post p ON e.Post_id = p.Post_id
                LEFT JOIN Qualification q ON e.Qualification_id = q.Qualification_id
                LEFT JOIN Educational_institution ei ON q.Educational_Institution_id = ei.Educational_institution_id
                ORDER BY e.Last_name, e.Name";

            DataTable table = DbMethods.GetData(sql);

            if (table == null || table.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных о сотрудниках", "Информация");
                return;
            }

            foreach (DataRow row in table.Rows)
            {
                try
                {
                    Employee employee = new Employee
                    {
                        Employee_id = SafeConverter.ToInt32(row["Employee_id"]),
                        Last_name = SafeConverter.ToString(row["Last_name"]),
                        Name = SafeConverter.ToString(row["Name"]),
                        Middle_name = SafeConverter.ToString(row["Middle_name"]),
                        Sex_name = SafeConverter.ToString(row["Sex_name"]),
                        Education_level = SafeConverter.ToString(row["Education_level"]),
                        Department_name = SafeConverter.ToString(row["Department_name"]),
                        Post_name = SafeConverter.ToString(row["Post_name"]),
                        Qualification_name = SafeConverter.ToString(row["Qualification_name"]),
                        Educational_institution = SafeConverter.ToString(row["Educational_institution"]),
                        Passport_series = SafeConverter.ToString(row["Passport_series"]),
                        Passport_number = SafeConverter.ToString(row["Passport_number"]),
                        Passport_issue_date = SafeConverter.ToDateTime(row["Passport_issue_date"]),
                        Who_issued_passport = SafeConverter.ToString(row["Who_issued_passport"]),
                        Subdivision_code = SafeConverter.ToString(row["Subdivision_code"]),
                        Phone_number = SafeConverter.ToString(row["Phone_number"]),
                        Email = SafeConverter.ToString(row["Email"]),
                        Residential_address = SafeConverter.ToString(row["Residential_address"]),
                        Registration_address = SafeConverter.ToString(row["Registration_address"])
                    };

                    _employees.Add(employee);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка создания Employee: {ex.Message}");
                }
            }
        }

        private void DisplayEmployees()
        {
            if (_employees == null || _employees.Count == 0)
            {
                // Отображаем пустую таблицу
                DataTable data = new DataTable();
                data.Columns.Add("Employee_id", typeof(int));
                data.Columns.Add("Last_name", typeof(string));
                data.Columns.Add("Name", typeof(string));
                data.Columns.Add("Middle_name", typeof(string));
                data.Columns.Add("Sex_name", typeof(string));
                data.Columns.Add("Department_name", typeof(string));
                data.Columns.Add("Post_name", typeof(string));
                data.Columns.Add("Phone_number", typeof(string));
                data.Columns.Add("Email", typeof(string));
                data.Columns.Add("Passport_issue_date", typeof(DateTime));

                dgvEmployees.DataSource = data;
                ConfigureDataGridView();
                return;
            }

            // Создаем таблицу для отображения
            DataTable table = new DataTable();

            // Добавляем колонки
            table.Columns.Add("Employee_id", typeof(int));
            table.Columns.Add("Last_name", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Middle_name", typeof(string));
            table.Columns.Add("Sex_name", typeof(string));
            table.Columns.Add("Department_name", typeof(string));
            table.Columns.Add("Post_name", typeof(string));
            table.Columns.Add("Phone_number", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Passport_issue_date", typeof(DateTime));

            // Заполняем данными из списка сотрудников
            foreach (Employee emp in _employees)
            {
                table.Rows.Add(
                    emp.Employee_id,
                    emp.Last_name,
                    emp.Name,
                    emp.Middle_name,
                    emp.Sex_name,
                    emp.Department_name,
                    emp.Post_name,
                    emp.Phone_number,
                    emp.Email,
                    emp.Passport_issue_date
                );
            }

            dgvEmployees.DataSource = table;

            // Настраиваем отображение
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            if (dgvEmployees.Columns.Count == 0) return;

            // Скрываем ID
            if (dgvEmployees.Columns.Contains("Employee_id"))
            {
                dgvEmployees.Columns["Employee_id"].Visible = false;
            }

            // Русские заголовки
            SetColumnHeader("Last_name", "Фамилия");
            SetColumnHeader("Name", "Имя");
            SetColumnHeader("Middle_name", "Отчество");
            SetColumnHeader("Sex_name", "Пол");
            SetColumnHeader("Department_name", "Отдел");
            SetColumnHeader("Post_name", "Должность");
            SetColumnHeader("Phone_number", "Телефон");
            SetColumnHeader("Email", "Email");

            if (dgvEmployees.Columns.Contains("Passport_issue_date"))
            {
                dgvEmployees.Columns["Passport_issue_date"].HeaderText = "Дата выдачи паспорта";
                dgvEmployees.Columns["Passport_issue_date"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }

            // Автонастройка ширины колонок
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void SetColumnHeader(string columnName, string headerText)
        {
            if (dgvEmployees.Columns.Contains(columnName))
            {
                dgvEmployees.Columns[columnName].HeaderText = headerText;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeeEditForm form = new EmployeeEditForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Сотрудник добавлен");
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
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для редактирования", "Информация");
                return;
            }

            try
            {
                DataGridViewRow row = dgvEmployees.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["Employee_id"].Value);

                // Передаем ID в форму редактирования
                EmployeeEditForm form = new EmployeeEditForm(id);

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
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите сотрудника для удаления", "Информация");
                return;
            }

            try
            {
                DataGridViewRow row = dgvEmployees.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["Employee_id"].Value);
                string lastName = row.Cells["Last_name"].Value?.ToString() ?? "";
                string firstName = row.Cells["Name"].Value?.ToString() ?? "";
                string fullName = lastName + " " + firstName;

                DialogResult result = MessageBox.Show(
                    "Удалить сотрудника " + fullName + "?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (CheckIfCanDelete(id))
                    {
                        bool success = DbMethods.Delete("Employee", id);

                        if (success)
                        {
                            MessageBox.Show("Сотрудник удален");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось удалить сотрудника", "Ошибка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нельзя удалить - есть связанные записи", "Ошибка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }

        private bool CheckIfCanDelete(int employeeId)
        {
            try
            {
                string sql1 = $"SELECT COUNT(*) FROM Account_employee WHERE Employee_id = {employeeId}";
                string sql2 = $"SELECT COUNT(*) FROM Invoice WHERE Employee_id = {employeeId}";
                string sql3 = $"SELECT COUNT(*) FROM Laboratory_analysis WHERE Employee_id = {employeeId}";

                DataTable dt1 = DbMethods.GetData(sql1);
                int count1 = SafeConverter.ToInt32(dt1?.Rows[0]?[0]);
                if (count1 > 0) return false;

                DataTable dt2 = DbMethods.GetData(sql2);
                int count2 = SafeConverter.ToInt32(dt2?.Rows[0]?[0]);
                if (count2 > 0) return false;

                DataTable dt3 = DbMethods.GetData(sql3);
                int count3 = SafeConverter.ToInt32(dt3?.Rows[0]?[0]);
                if (count3 > 0) return false;

                return true;
            }
            catch
            {
                return false;
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

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                DisplayEmployees();
                return;
            }

            try
            {
                List<Employee> filteredEmployees = _employees.FindAll(emp =>
                    emp.Last_name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    emp.Name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    emp.Middle_name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);

                DisplayFilteredEmployees(filteredEmployees);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка поиска: " + ex.Message, "Ошибка");
            }
        }

        private void DisplayFilteredEmployees(List<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
            {
                // Отображаем пустую таблицу
                DataTable emptyTable = new DataTable();
                emptyTable.Columns.Add("Employee_id", typeof(int));
                emptyTable.Columns.Add("Last_name", typeof(string));
                emptyTable.Columns.Add("Name", typeof(string));
                emptyTable.Columns.Add("Middle_name", typeof(string));
                emptyTable.Columns.Add("Sex_name", typeof(string));
                emptyTable.Columns.Add("Department_name", typeof(string));
                emptyTable.Columns.Add("Post_name", typeof(string));
                emptyTable.Columns.Add("Phone_number", typeof(string));
                emptyTable.Columns.Add("Email", typeof(string));
                emptyTable.Columns.Add("Passport_issue_date", typeof(DateTime));

                dgvEmployees.DataSource = emptyTable;
                ConfigureDataGridView();
                return;
            }

            DataTable table = new DataTable();

            table.Columns.Add("Employee_id", typeof(int));
            table.Columns.Add("Last_name", typeof(string));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("Middle_name", typeof(string));
            table.Columns.Add("Sex_name", typeof(string));
            table.Columns.Add("Department_name", typeof(string));
            table.Columns.Add("Post_name", typeof(string));
            table.Columns.Add("Phone_number", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("Passport_issue_date", typeof(DateTime));

            foreach (Employee emp in employees)
            {
                table.Rows.Add(
                    emp.Employee_id,
                    emp.Last_name,
                    emp.Name,
                    emp.Middle_name,
                    emp.Sex_name,
                    emp.Department_name,
                    emp.Post_name,
                    emp.Phone_number,
                    emp.Email,
                    emp.Passport_issue_date
                );
            }

            dgvEmployees.DataSource = table;
            ConfigureDataGridView();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.Handled = true;
            }
        }
    }
}
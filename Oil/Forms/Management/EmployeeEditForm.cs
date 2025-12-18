using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oil.Helpers;
using Oil.Models;

namespace Oil.Forms.Management
{
    public partial class EmployeeEditForm : Form
    {
        private int _employeeId = -1;
        private bool _isEditMode = false;

        public EmployeeEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавить сотрудника";
            Text = "Oil System - Добавление сотрудника";
        }

        public EmployeeEditForm(int employeeId)
        {
            InitializeComponent();
            _employeeId = employeeId;
            _isEditMode = true;
            lblTitle.Text = "Редактировать сотрудника";
            Text = "Oil System - Редактирование сотрудника";
        }

        // Новый конструктор для передачи объекта Employee
        public EmployeeEditForm(Employee employee)
        {
            InitializeComponent();
            if (employee != null)
            {
                _employeeId = employee.Employee_id;
                _isEditMode = true;
                lblTitle.Text = "Редактировать сотрудника";
                Text = "Oil System - Редактирование сотрудника";
                // Можно сохранить объект employee для заполнения формы
            }
        }

        private void EmployeeEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxData();
                if (_isEditMode)
                {
                    LoadEmployeeData();
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
                // Пол
                DataTable sex = DbMethods.GetData("SELECT Sex_id, Sex_name FROM Sex ORDER BY Sex_id");
                cbxSex.DataSource = sex;
                cbxSex.DisplayMember = "Sex_name";
                cbxSex.ValueMember = "Sex_id";

                // Уровень образования
                DataTable education = DbMethods.GetData("SELECT Education_level_id, Level_name FROM Education_level ORDER BY Education_level_id");
                cbxEducation.DataSource = education;
                cbxEducation.DisplayMember = "Level_name";
                cbxEducation.ValueMember = "Education_level_id";

                // Отделы
                DataTable departments = DbMethods.GetData("SELECT Department_id, Department_name FROM Department ORDER BY Department_name");
                cbxDepartment.DataSource = departments;
                cbxDepartment.DisplayMember = "Department_name";
                cbxDepartment.ValueMember = "Department_id";

                // Должности
                DataTable posts = DbMethods.GetData("SELECT Post_id, Post_name FROM Post ORDER BY Post_name");
                cbxPost.DataSource = posts;
                cbxPost.DisplayMember = "Post_name";
                cbxPost.ValueMember = "Post_id";

                // Учебные заведения
                DataTable institutions = DbMethods.GetData("SELECT Educational_institution_id, Institution_name FROM Educational_institution ORDER BY Institution_name");
                cbxInstitution.DataSource = institutions;
                cbxInstitution.DisplayMember = "Institution_name";
                cbxInstitution.ValueMember = "Educational_institution_id";

                // Загружаем квалификации для первого учебного заведения
                if (cbxInstitution.Items.Count > 0)
                {
                    cbxInstitution.SelectedIndex = 0;
                    LoadQualifications();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadQualifications()
        {
            try
            {
                int institutionId = SafeConverter.GetComboBoxValue(cbxInstitution);
                if (institutionId <= 0) return;

                // Используем параметризованный запрос
                string query = "SELECT Qualification_id, Qualification_name FROM Qualification WHERE Educational_Institution_id = @InstitutionId ORDER BY Qualification_name";

                var parameters = new Dictionary<string, object>
        {
            { "@InstitutionId", institutionId }
        };

                DataTable qualifications = DbMethods.GetData(query, parameters);
                cbxQualification.DataSource = qualifications;
                cbxQualification.DisplayMember = "Qualification_name";
                cbxQualification.ValueMember = "Qualification_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки квалификаций: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEmployeeData()
        {
            try
            {
                string query = $@"
                    SELECT 
                        e.Last_name,
                        e.Name,
                        e.Middle_name,
                        e.Sex_id,
                        e.Education_level_id,
                        e.Department_id,
                        e.Post_id,
                        e.Qualification_id,
                        q.Educational_Institution_id,
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
                    LEFT JOIN Qualification q ON e.Qualification_id = q.Qualification_id
                    WHERE e.Employee_id = {_employeeId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtLastName.Text = SafeConverter.ToString(row["Last_name"]);
                    txtFirstName.Text = SafeConverter.ToString(row["Name"]);
                    txtMiddleName.Text = SafeConverter.ToString(row["Middle_name"]);
                    txtPassportSeries.Text = SafeConverter.ToString(row["Passport_series"]);
                    txtPassportNumber.Text = SafeConverter.ToString(row["Passport_number"]);
                    txtWhoIssuedPassport.Text = SafeConverter.ToString(row["Who_issued_passport"]);
                    txtSubdivisionCode.Text = SafeConverter.ToString(row["Subdivision_code"]);
                    txtPhone.Text = SafeConverter.ToString(row["Phone_number"]);
                    txtEmail.Text = SafeConverter.ToString(row["Email"]);
                    txtResidentialAddress.Text = SafeConverter.ToString(row["Residential_address"]);
                    txtRegistrationAddress.Text = SafeConverter.ToString(row["Registration_address"]);

                    // Устанавливаем дату паспорта
                    if (row["Passport_issue_date"] != DBNull.Value)
                    {
                        dtpPassportDate.Value = SafeConverter.ToDateTime(row["Passport_issue_date"]);
                    }

                    // Устанавливаем значения в комбобоксы
                    SetComboBoxValue(cbxSex, row["Sex_id"]);
                    SetComboBoxValue(cbxEducation, row["Education_level_id"]);
                    SetComboBoxValue(cbxDepartment, row["Department_id"]);
                    SetComboBoxValue(cbxPost, row["Post_id"]);

                    // Сначала устанавливаем учебное заведение
                    if (row["Educational_Institution_id"] != DBNull.Value)
                    {
                        SetComboBoxValue(cbxInstitution, row["Educational_Institution_id"]);
                        LoadQualifications(); // Загружаем квалификации для этого учебного заведения
                        SetComboBoxValue(cbxQualification, row["Qualification_id"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных сотрудника: {ex.Message}", "Ошибка",
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

                // Проверяем email
                if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Введите корректный email адрес!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем уникальность паспорта
                if (!ValidatePassportUnique())
                {
                    return;
                }

                // Проверяем уникальность телефона и email
                if (!ValidateUniqueContacts())
                {
                    return;
                }

                // Получаем значения из формы
                var employeeData = GetEmployeeData();

                if (_isEditMode)
                {
                    // Обновляем существующую запись
                    UpdateEmployee(employeeData);
                }
                else
                {
                    // Добавляем новую запись
                    AddNewEmployee(employeeData);
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
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Введите фамилию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Введите имя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassportSeries.Text) || txtPassportSeries.Text.Length != 4)
            {
                MessageBox.Show("Введите серию паспорта (4 цифры)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassportNumber.Text) || txtPassportNumber.Text.Length != 6)
            {
                MessageBox.Show("Введите номер паспорта (6 цифр)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtWhoIssuedPassport.Text))
            {
                MessageBox.Show("Введите, кем выдан паспорт!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSubdivisionCode.Text))
            {
                MessageBox.Show("Введите код подразделения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Введите телефон!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Введите email!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtResidentialAddress.Text))
            {
                MessageBox.Show("Введите адрес проживания!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRegistrationAddress.Text))
            {
                MessageBox.Show("Введите адрес регистрации!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbxSex.SelectedIndex == -1 ||
                cbxEducation.SelectedIndex == -1 ||
                cbxDepartment.SelectedIndex == -1 ||
                cbxPost.SelectedIndex == -1 ||
                cbxQualification.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите все обязательные параметры!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidatePassportUnique()
        {
            string passportNumber = txtPassportNumber.Text.Trim();
            string condition = _isEditMode ? $"AND Employee_id != {_employeeId}" : "";

            string checkQuery = $@"
                SELECT COUNT(*) FROM Employee 
                WHERE Passport_number = '{passportNumber}' {condition}";

            DataTable dt = DbMethods.GetData(checkQuery);
            int count = Convert.ToInt32(dt.Rows[0][0]);

            if (count > 0)
            {
                MessageBox.Show("Сотрудник с таким номером паспорта уже существует!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidateUniqueContacts()
        {
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string condition = _isEditMode ? $"AND Employee_id != {_employeeId}" : "";

            string checkQuery = $@"
                SELECT COUNT(*) FROM Employee 
                WHERE (Phone_number = '{phone}' OR Email = '{email}') {condition}";

            DataTable dt = DbMethods.GetData(checkQuery);
            int count = Convert.ToInt32(dt.Rows[0][0]);

            if (count > 0)
            {
                MessageBox.Show("Сотрудник с таким телефоном или email уже существует!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private (string LastName, string Name, string MiddleName, int SexId, int EducationId,
            int DepartmentId, int PostId, int QualificationId, string PassportSeries,
            string PassportNumber, string PassportDate, string WhoIssued, string SubdivisionCode,
            string Phone, string Email, string ResidentialAddress, string RegistrationAddress)
            GetEmployeeData()
        {
            return (
                txtLastName.Text.Trim(),
                txtFirstName.Text.Trim(),
                txtMiddleName.Text.Trim(),
                Convert.ToInt32(cbxSex.SelectedValue),
                Convert.ToInt32(cbxEducation.SelectedValue),
                Convert.ToInt32(cbxDepartment.SelectedValue),
                Convert.ToInt32(cbxPost.SelectedValue),
                Convert.ToInt32(cbxQualification.SelectedValue),
                txtPassportSeries.Text.Trim(),
                txtPassportNumber.Text.Trim(),
                dtpPassportDate.Value.ToString("yyyy-MM-dd"),
                txtWhoIssuedPassport.Text.Trim(),
                txtSubdivisionCode.Text.Trim(),
                txtPhone.Text.Trim(),
                txtEmail.Text.Trim(),
                txtResidentialAddress.Text.Trim(),
                txtRegistrationAddress.Text.Trim()
            );
        }

        private void UpdateEmployee((string LastName, string Name, string MiddleName, int SexId,
            int EducationId, int DepartmentId, int PostId, int QualificationId,
            string PassportSeries, string PassportNumber, string PassportDate,
            string WhoIssued, string SubdivisionCode, string Phone, string Email,
            string ResidentialAddress, string RegistrationAddress) data)
        {
            string updateQuery = $@"
                UPDATE Employee SET
                    Last_name = '{data.LastName}',
                    Name = '{data.Name}',
                    Middle_name = '{data.MiddleName}',
                    Sex_id = {data.SexId},
                    Education_level_id = {data.EducationId},
                    Department_id = {data.DepartmentId},
                    Post_id = {data.PostId},
                    Qualification_id = {data.QualificationId},
                    Passport_series = '{data.PassportSeries}',
                    Passport_number = '{data.PassportNumber}',
                    Passport_issue_date = '{data.PassportDate}',
                    Who_issued_passport = '{data.WhoIssued}',
                    Subdivision_code = '{data.SubdivisionCode}',
                    Phone_number = '{data.Phone}',
                    Email = '{data.Email}',
                    Residential_address = '{data.ResidentialAddress}',
                    Registration_address = '{data.RegistrationAddress}'
                WHERE Employee_id = {_employeeId}";

            bool success = DbMethods.Execute(updateQuery);
            if (success)
            {
                MessageBox.Show("Сотрудник успешно обновлён!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void AddNewEmployee((string LastName, string Name, string MiddleName, int SexId,
            int EducationId, int DepartmentId, int PostId, int QualificationId,
            string PassportSeries, string PassportNumber, string PassportDate,
            string WhoIssued, string SubdivisionCode, string Phone, string Email,
            string ResidentialAddress, string RegistrationAddress) data)
        {
            string insertQuery = $@"
                INSERT INTO Employee (
                    Sex_id,
                    Education_level_id,
                    Department_id,
                    Post_id,
                    Qualification_id,
                    Last_name,
                    Name,
                    Middle_name,
                    Passport_series,
                    Passport_number,
                    Passport_issue_date,
                    Who_issued_passport,
                    Subdivision_code,
                    Phone_number,
                    Email,
                    Residential_address,
                    Registration_address
                ) VALUES (
                    {data.SexId},
                    {data.EducationId},
                    {data.DepartmentId},
                    {data.PostId},
                    {data.QualificationId},
                    '{data.LastName}',
                    '{data.Name}',
                    '{data.MiddleName}',
                    '{data.PassportSeries}',
                    '{data.PassportNumber}',
                    '{data.PassportDate}',
                    '{data.WhoIssued}',
                    '{data.SubdivisionCode}',
                    '{data.Phone}',
                    '{data.Email}',
                    '{data.ResidentialAddress}',
                    '{data.RegistrationAddress}'
                )";

            bool success = DbMethods.Execute(insertQuery);
            if (success)
            {
                MessageBox.Show("Сотрудник успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cbxInstitution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxInstitution.SelectedValue != null)
            {
                LoadQualifications();
            }
        }
    }
}
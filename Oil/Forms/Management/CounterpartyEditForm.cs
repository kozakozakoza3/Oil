using System;
using System.Data;
using System.Windows.Forms;
using Oil.Helpers;

namespace Oil.Forms.Management
{
    public partial class CounterpartyEditForm : Form
    {
        private int _counterpartyId = -1;
        private bool _isEditMode = false;

        public CounterpartyEditForm()
        {
            InitializeComponent();
            Text = "Добавление контрагента";
        }

        public CounterpartyEditForm(int counterpartyId)
        {
            InitializeComponent();
            _counterpartyId = counterpartyId;
            _isEditMode = true;
            Text = "Редактирование контрагента";
        }

        private void CounterpartyEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxData();
                if (_isEditMode)
                {
                    LoadCounterpartyData();
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
                // Типы контрагентов
                DataTable counterpartyTypes = DbMethods.GetData("SELECT Counterparty_type_id, Counterparty_type_name FROM Counterparty_type ORDER BY Counterparty_type_id");
                cbxCounterpartyType.DataSource = counterpartyTypes;
                cbxCounterpartyType.DisplayMember = "Counterparty_type_name";
                cbxCounterpartyType.ValueMember = "Counterparty_type_id";

                // Коды ОКФС
                DataTable okfs = DbMethods.GetData("SELECT OKFS_id, OKFS_code FROM OKFS ORDER BY OKFS_code");
                cbxOKFS.DataSource = okfs;
                cbxOKFS.DisplayMember = "OKFS_code";
                cbxOKFS.ValueMember = "OKFS_id";

                // Названия организаций
                DataTable organizations = DbMethods.GetData("SELECT Name_organization_id, Organization_name FROM Name_organization ORDER BY Organization_name");
                cbxOrganization.DataSource = organizations;
                cbxOrganization.DisplayMember = "Organization_name";
                cbxOrganization.ValueMember = "Name_organization_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCounterpartyData()
        {
            try
            {
                string query = $@"
                    SELECT 
                        c.Counterparty_type_id,
                        c.OKFS_id,
                        c.Name_organization_id,
                        c.Phone_number,
                        c.Email,
                        c.INN,
                        c.KPP,
                        c.OGRN,
                        c.Statutory_address,
                        c.Physical_address
                    FROM Counterparty c
                    WHERE c.Counterparty_id = {_counterpartyId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtPhone.Text = SafeConverter.ToString(row["Phone_number"]);
                    txtEmail.Text = SafeConverter.ToString(row["Email"]);
                    txtINN.Text = SafeConverter.ToString(row["INN"]);
                    txtKPP.Text = SafeConverter.ToString(row["KPP"]);
                    txtOGRN.Text = SafeConverter.ToString(row["OGRN"]);
                    txtStatutoryAddress.Text = SafeConverter.ToString(row["Statutory_address"]);
                    txtPhysicalAddress.Text = SafeConverter.ToString(row["Physical_address"]);

                    // Устанавливаем значения в комбобоксы
                    SetComboBoxValue(cbxCounterpartyType, row["Counterparty_type_id"]);
                    SetComboBoxValue(cbxOKFS, row["OKFS_id"]);
                    SetComboBoxValue(cbxOrganization, row["Name_organization_id"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных контрагента: {ex.Message}", "Ошибка",
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

                // Проверяем уникальность ИНН, ОГРН, телефона и email
                if (!ValidateUniqueFields())
                {
                    return;
                }

                // Получаем значения из формы
                var counterpartyData = GetCounterpartyData();

                if (_isEditMode)
                {
                    // Обновляем существующую запись
                    UpdateCounterparty(counterpartyData);
                }
                else
                {
                    // Добавляем новую запись
                    AddNewCounterparty(counterpartyData);
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
            if (cbxCounterpartyType.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите тип контрагента!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbxOKFS.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите код ОКФС!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cbxOrganization.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите название организации!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (string.IsNullOrWhiteSpace(txtINN.Text) || txtINN.Text.Length != 10)
            {
                MessageBox.Show("ИНН должен содержать 10 цифр!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtKPP.Text) || txtKPP.Text.Length != 9)
            {
                MessageBox.Show("КПП должен содержать 9 цифр!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtOGRN.Text) || txtOGRN.Text.Length != 13)
            {
                MessageBox.Show("ОГРН должен содержать 13 цифр!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtStatutoryAddress.Text))
            {
                MessageBox.Show("Введите юридический адрес!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhysicalAddress.Text))
            {
                MessageBox.Show("Введите физический адрес!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool ValidateUniqueFields()
        {
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string inn = txtINN.Text.Trim();
            string ogrn = txtOGRN.Text.Trim();
            string condition = _isEditMode ? $"AND Counterparty_id != {_counterpartyId}" : "";

            // Проверяем уникальность ИНН
            string checkINNQuery = $@"
                SELECT COUNT(*) FROM Counterparty 
                WHERE INN = '{inn}' {condition}";

            DataTable dtINN = DbMethods.GetData(checkINNQuery);
            int countINN = Convert.ToInt32(dtINN.Rows[0][0]);

            if (countINN > 0)
            {
                MessageBox.Show("Контрагент с таким ИНН уже существует!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверяем уникальность ОГРН
            string checkOGRNQuery = $@"
                SELECT COUNT(*) FROM Counterparty 
                WHERE OGRN = '{ogrn}' {condition}";

            DataTable dtOGRN = DbMethods.GetData(checkOGRNQuery);
            int countOGRN = Convert.ToInt32(dtOGRN.Rows[0][0]);

            if (countOGRN > 0)
            {
                MessageBox.Show("Контрагент с таким ОГРН уже существует!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Проверяем уникальность телефона и email
            string checkContactsQuery = $@"
                SELECT COUNT(*) FROM Counterparty 
                WHERE (Phone_number = '{phone}' OR Email = '{email}') {condition}";

            DataTable dtContacts = DbMethods.GetData(checkContactsQuery);
            int countContacts = Convert.ToInt32(dtContacts.Rows[0][0]);

            if (countContacts > 0)
            {
                MessageBox.Show("Контрагент с таким телефоном или email уже существует!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private (int CounterpartyTypeId, int OKFSId, int OrganizationId, string Phone,
            string Email, string INN, string KPP, string OGRN, string StatutoryAddress,
            string PhysicalAddress) GetCounterpartyData()
        {
            return (
                Convert.ToInt32(cbxCounterpartyType.SelectedValue),
                Convert.ToInt32(cbxOKFS.SelectedValue),
                Convert.ToInt32(cbxOrganization.SelectedValue),
                txtPhone.Text.Trim(),
                txtEmail.Text.Trim(),
                txtINN.Text.Trim(),
                txtKPP.Text.Trim(),
                txtOGRN.Text.Trim(),
                txtStatutoryAddress.Text.Trim(),
                txtPhysicalAddress.Text.Trim()
            );
        }

        private void UpdateCounterparty((int CounterpartyTypeId, int OKFSId, int OrganizationId,
            string Phone, string Email, string INN, string KPP, string OGRN,
            string StatutoryAddress, string PhysicalAddress) data)
        {
            string updateQuery = $@"
                UPDATE Counterparty SET
                    Counterparty_type_id = {data.CounterpartyTypeId},
                    OKFS_id = {data.OKFSId},
                    Name_organization_id = {data.OrganizationId},
                    Phone_number = '{data.Phone}',
                    Email = '{data.Email}',
                    INN = '{data.INN}',
                    KPP = '{data.KPP}',
                    OGRN = '{data.OGRN}',
                    Statutory_address = '{data.StatutoryAddress.Replace("'", "''")}',
                    Physical_address = '{data.PhysicalAddress.Replace("'", "''")}'
                WHERE Counterparty_id = {_counterpartyId}";

            bool success = DbMethods.Execute(updateQuery);
            if (success)
            {
                MessageBox.Show("Контрагент успешно обновлён!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось обновить контрагента!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewCounterparty((int CounterpartyTypeId, int OKFSId, int OrganizationId,
            string Phone, string Email, string INN, string KPP, string OGRN,
            string StatutoryAddress, string PhysicalAddress) data)
        {
            string insertQuery = $@"
                INSERT INTO Counterparty (
                    Counterparty_type_id,
                    OKFS_id,
                    Name_organization_id,
                    Phone_number,
                    Email,
                    INN,
                    KPP,
                    OGRN,
                    Statutory_address,
                    Physical_address
                ) VALUES (
                    {data.CounterpartyTypeId},
                    {data.OKFSId},
                    {data.OrganizationId},
                    '{data.Phone}',
                    '{data.Email}',
                    '{data.INN}',
                    '{data.KPP}',
                    '{data.OGRN}',
                    '{data.StatutoryAddress.Replace("'", "''")}',
                    '{data.PhysicalAddress.Replace("'", "''")}'
                )";

            bool success = DbMethods.Execute(insertQuery);
            if (success)
            {
                MessageBox.Show("Контрагент успешно добавлен!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Не удалось добавить контрагента!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtINN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtKPP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtOGRN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
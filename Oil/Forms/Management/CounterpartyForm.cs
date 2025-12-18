using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Oil.Helpers;
using Oil.Models;

namespace Oil.Forms.Management
{
    public partial class CounterpartyForm : Form
    {
        private List<Counterparty> _counterparties;

        public CounterpartyForm()
        {
            InitializeComponent();
        }

        private void CounterpartyForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                LoadCounterparties();
                DisplayCounterparties();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message, "Ошибка");
            }
        }

        private void LoadCounterparties()
        {
            _counterparties = new List<Counterparty>();

            string sql = @"
                SELECT 
                    c.Counterparty_id,
                    ct.Counterparty_type_name,
                    no.Organization_name,
                    ok.OKFS_code,
                    ok.OKFS_name,
                    c.Phone_number,
                    c.Email,
                    c.INN,
                    c.KPP,
                    c.OGRN,
                    c.Statutory_address,
                    c.Physical_address
                FROM Counterparty c
                LEFT JOIN Counterparty_type ct ON c.Counterparty_type_id = ct.Counterparty_type_id
                LEFT JOIN Name_organization no ON c.Name_organization_id = no.Name_organization_id
                LEFT JOIN OKFS ok ON c.OKFS_id = ok.OKFS_id
                ORDER BY no.Organization_name";

            DataTable table = DbMethods.GetData(sql);

            if (table == null || table.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных о контрагентах", "Информация");
                return;
            }

            foreach (DataRow row in table.Rows)
            {
                try
                {
                    Counterparty counterparty = new Counterparty
                    {
                        Counterparty_id = SafeConverter.ToInt32(row["Counterparty_id"]),
                        Counterparty_type_name = SafeConverter.ToString(row["Counterparty_type_name"]),
                        Organization_name = SafeConverter.ToString(row["Organization_name"]),
                        OKFS_code = SafeConverter.ToString(row["OKFS_code"]),
                        OKFS_name = SafeConverter.ToString(row["OKFS_name"]),
                        Phone_number = SafeConverter.ToString(row["Phone_number"]),
                        Email = SafeConverter.ToString(row["Email"]),
                        INN = SafeConverter.ToString(row["INN"]),
                        KPP = SafeConverter.ToString(row["KPP"]),
                        OGRN = SafeConverter.ToString(row["OGRN"]),
                        Statutory_address = SafeConverter.ToString(row["Statutory_address"]),
                        Physical_address = SafeConverter.ToString(row["Physical_address"])
                    };

                    _counterparties.Add(counterparty);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка создания Counterparty: {ex.Message}");
                }
            }
        }

        private void DisplayCounterparties()
        {
            if (_counterparties == null || _counterparties.Count == 0)
            {
                // Отображаем пустую таблицу
                DataTable data = new DataTable();
                data.Columns.Add("Counterparty_id", typeof(int));
                data.Columns.Add("Organization_name", typeof(string));
                data.Columns.Add("Counterparty_type_name", typeof(string));
                data.Columns.Add("OKFS_code", typeof(string));
                data.Columns.Add("Phone_number", typeof(string));
                data.Columns.Add("Email", typeof(string));
                data.Columns.Add("INN", typeof(string));
                data.Columns.Add("OGRN", typeof(string));
                data.Columns.Add("KPP", typeof(string));
                data.Columns.Add("OKFS_name", typeof(string));

                dgvCounterparties.DataSource = data;
                ConfigureDataGridView();
                return;
            }

            // Создаем таблицу для отображения
            DataTable table = new DataTable();

            // Добавляем колонки - показываем ВСЮ информацию сразу
            table.Columns.Add("Counterparty_id", typeof(int));
            table.Columns.Add("Organization_name", typeof(string));
            table.Columns.Add("Counterparty_type_name", typeof(string));
            table.Columns.Add("OKFS_code", typeof(string));
            table.Columns.Add("OKFS_name", typeof(string));
            table.Columns.Add("Phone_number", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("INN", typeof(string));
            table.Columns.Add("KPP", typeof(string));
            table.Columns.Add("OGRN", typeof(string));
            table.Columns.Add("Statutory_address", typeof(string));
            table.Columns.Add("Physical_address", typeof(string));

            // Заполняем данными из списка контрагентов
            foreach (Counterparty cp in _counterparties)
            {
                table.Rows.Add(
                    cp.Counterparty_id,
                    cp.Organization_name,
                    cp.Counterparty_type_name,
                    cp.OKFS_code,
                    cp.OKFS_name,
                    cp.Phone_number,
                    cp.Email,
                    cp.INN,
                    cp.KPP,
                    cp.OGRN,
                    cp.Statutory_address,
                    cp.Physical_address
                );
            }

            dgvCounterparties.DataSource = table;

            // Настраиваем отображение
            ConfigureDataGridView();
        }

        private void ConfigureDataGridView()
        {
            if (dgvCounterparties.Columns.Count == 0) return;

            // Скрываем ID
            if (dgvCounterparties.Columns.Contains("Counterparty_id"))
            {
                dgvCounterparties.Columns["Counterparty_id"].Visible = false;
            }

            // Русские заголовки
            SetColumnHeader("Organization_name", "Название организации");
            SetColumnHeader("Counterparty_type_name", "Тип контрагента");
            SetColumnHeader("OKFS_code", "Код ОКФС");
            SetColumnHeader("OKFS_name", "Название ОКФС");
            SetColumnHeader("Phone_number", "Телефон");
            SetColumnHeader("Email", "Email");
            SetColumnHeader("INN", "ИНН");
            SetColumnHeader("KPP", "КПП");
            SetColumnHeader("OGRN", "ОГРН");
            SetColumnHeader("Statutory_address", "Юридический адрес");
            SetColumnHeader("Physical_address", "Физический адрес");

            // Автонастройка ширины колонок
            dgvCounterparties.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Позволяем перенос текста в колонках с адресами
            if (dgvCounterparties.Columns.Contains("Statutory_address"))
            {
                dgvCounterparties.Columns["Statutory_address"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            if (dgvCounterparties.Columns.Contains("Physical_address"))
            {
                dgvCounterparties.Columns["Physical_address"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }

            // Настройка высоты строк для переноса текста
            dgvCounterparties.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void SetColumnHeader(string columnName, string headerText)
        {
            if (dgvCounterparties.Columns.Contains(columnName))
            {
                dgvCounterparties.Columns[columnName].HeaderText = headerText;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CounterpartyEditForm form = new CounterpartyEditForm();

                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Контрагент добавлен");
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
            if (dgvCounterparties.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите контрагента для редактирования", "Информация");
                return;
            }

            try
            {
                DataGridViewRow row = dgvCounterparties.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["Counterparty_id"].Value);

                // Передаем ID в форму редактирования
                CounterpartyEditForm form = new CounterpartyEditForm(id);

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
            if (dgvCounterparties.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите контрагента для удаления", "Информация");
                return;
            }

            try
            {
                DataGridViewRow row = dgvCounterparties.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells["Counterparty_id"].Value);
                string orgName = row.Cells["Organization_name"].Value?.ToString() ?? "";

                DialogResult result = MessageBox.Show(
                    $"Удалить контрагента \"{orgName}\"?",
                    "Подтверждение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (CheckIfCanDelete(id))
                    {
                        bool success = DbMethods.Delete("Counterparty", id);

                        if (success)
                        {
                            MessageBox.Show("Контрагент удален");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось удалить контрагента", "Ошибка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нельзя удалить - есть связанные записи (накладные, месторождения)", "Ошибка");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message, "Ошибка");
            }
        }

        private bool CheckIfCanDelete(int counterpartyId)
        {
            try
            {
                string sql1 = $"SELECT COUNT(*) FROM Invoice WHERE Counterparty_id = {counterpartyId}";
                string sql2 = $"SELECT COUNT(*) FROM Oilfield WHERE Counterparty_id = {counterpartyId}";

                DataTable dt1 = DbMethods.GetData(sql1);
                int count1 = SafeConverter.ToInt32(dt1?.Rows[0]?[0]);
                if (count1 > 0) return false;

                DataTable dt2 = DbMethods.GetData(sql2);
                int count2 = SafeConverter.ToInt32(dt2?.Rows[0]?[0]);
                if (count2 > 0) return false;

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

        private void dgvCounterparties_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // При двойном клике - сразу редактирование
                btnEdit_Click(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                DisplayCounterparties();
                return;
            }

            try
            {
                List<Counterparty> filteredCounterparties = _counterparties.FindAll(cp =>
                    cp.Organization_name.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    cp.INN.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0);

                DisplayFilteredCounterparties(filteredCounterparties);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка поиска: " + ex.Message, "Ошибка");
            }
        }

        private void DisplayFilteredCounterparties(List<Counterparty> counterparties)
        {
            if (counterparties == null || counterparties.Count == 0)
            {
                // Отображаем пустую таблицу
                DataTable emptyTable = new DataTable();
                emptyTable.Columns.Add("Counterparty_id", typeof(int));
                emptyTable.Columns.Add("Organization_name", typeof(string));
                emptyTable.Columns.Add("Counterparty_type_name", typeof(string));
                emptyTable.Columns.Add("OKFS_code", typeof(string));
                emptyTable.Columns.Add("OKFS_name", typeof(string));
                emptyTable.Columns.Add("Phone_number", typeof(string));
                emptyTable.Columns.Add("Email", typeof(string));
                emptyTable.Columns.Add("INN", typeof(string));
                emptyTable.Columns.Add("KPP", typeof(string));
                emptyTable.Columns.Add("OGRN", typeof(string));
                emptyTable.Columns.Add("Statutory_address", typeof(string));
                emptyTable.Columns.Add("Physical_address", typeof(string));

                dgvCounterparties.DataSource = emptyTable;
                ConfigureDataGridView();
                return;
            }

            DataTable table = new DataTable();

            table.Columns.Add("Counterparty_id", typeof(int));
            table.Columns.Add("Organization_name", typeof(string));
            table.Columns.Add("Counterparty_type_name", typeof(string));
            table.Columns.Add("OKFS_code", typeof(string));
            table.Columns.Add("OKFS_name", typeof(string));
            table.Columns.Add("Phone_number", typeof(string));
            table.Columns.Add("Email", typeof(string));
            table.Columns.Add("INN", typeof(string));
            table.Columns.Add("KPP", typeof(string));
            table.Columns.Add("OGRN", typeof(string));
            table.Columns.Add("Statutory_address", typeof(string));
            table.Columns.Add("Physical_address", typeof(string));

            foreach (Counterparty cp in counterparties)
            {
                table.Rows.Add(
                    cp.Counterparty_id,
                    cp.Organization_name,
                    cp.Counterparty_type_name,
                    cp.OKFS_code,
                    cp.OKFS_name,
                    cp.Phone_number,
                    cp.Email,
                    cp.INN,
                    cp.KPP,
                    cp.OGRN,
                    cp.Statutory_address,
                    cp.Physical_address
                );
            }

            dgvCounterparties.DataSource = table;
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
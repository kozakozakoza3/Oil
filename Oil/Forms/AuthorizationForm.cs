using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Oil.Management;

namespace Oil
{
    public partial class AuthorizationForm : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234567890;Database=Oil;";

        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            try
            {
                var authenticationResult = AuthenticateUser(login, password);

                if (authenticationResult.roleId != 0)
                {
                    if (authenticationResult.roleId == 2)
                    {
                        Form employeeForm = GetEmployeeFormByPostSwitch(login, authenticationResult.postName, authenticationResult.employeeName);

                        if (employeeForm != null)
                        {
                            employeeForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show($"Для вашей должности '{authenticationResult.postName}' не определена форма доступа.");
                        }
                    }
                    else if (authenticationResult.roleId == 3)
                    {
                        ManagementForm managementForm = new ManagementForm(login);
                        managementForm.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка аутентификации: " + ex.Message);
            }
        }

        private (int roleId, string postName, string employeeName) AuthenticateUser(string login, string password)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var command = new NpgsqlCommand(@"
                    SELECT a.role_id, p.post_name, 
                           e.last_name || ' ' || e.name || ' ' || COALESCE(e.middle_name, '') as full_name
                    FROM account_employee ae
                    JOIN account a ON ae.account_id = a.account_id
                    JOIN employee e ON ae.employee_id = e.employee_id
                    JOIN post p ON e.post_id = p.post_id
                    WHERE ae.login = @login AND a.password = @password", conn))
                {
                    command.Parameters.AddWithValue("login", login);
                    command.Parameters.AddWithValue("password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int roleId = reader.GetInt32(0);
                            string postName = reader.GetString(1);
                            string employeeName = reader.GetString(2);
                            return (roleId, postName, employeeName);
                        }
                    }
                }
            }
            return (0, string.Empty, string.Empty); // Возвращаем пустые строки вместо null
        }

        private Form GetEmployeeFormByPostSwitch(string login, string postName, string employeeName)
        {
            // Проверяем, что postName не null и не пустой
            if (string.IsNullOrEmpty(postName))
            {
                return new GuestForm();
            }

            string normalizedPostName = postName.ToLower();

            switch (normalizedPostName)
            {
                case "химик":
                case "старший химик":
                case "лаборант":
                case "инженер качества":
                case "старший инженер качества":
                case "технолог":
                case "старший технолог":
                case "аналитик":
                    LaboratoryForm laboratoryForm = new LaboratoryForm();
                    return laboratoryForm;

                case "водитель":
                case "логист":
                case "старший логист":
                case "диспетчер":
                case "машинист":
                case "машинист насосов":
                case "механик":
                case "старший механик":
                case "оператор":
                case "оператор установок":
                case "оператор технологических установок":
                    TransportForm transportForm = new TransportForm(login);
                    return transportForm;

                case "кладовщик":
                case "старший кладовщик":
                case "грузчик":
                case "складской работник":
                    WarehouseForm warehouseForm = new WarehouseForm(login);
                    return warehouseForm;

                default:
                    GuestForm guestForm = new GuestForm();
                    return guestForm;
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            GuestForm guestForm = new GuestForm();
            guestForm.Show();
            this.Hide();
        }
    }
}
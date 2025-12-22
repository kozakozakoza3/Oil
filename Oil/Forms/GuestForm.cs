using System;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Oil
{
    public partial class GuestForm : Form
    {
        private const string FROM_EMAIL = "hodunovaaa@yandex.ru";
        private const string FROM_PASSWORD = "jssbqjxyogzyllhq";
        private const string TO_EMAIL = "serz.levshin@mail.ru";

        public GuestForm()
        {
            InitializeComponent();
            cmbSubject.SelectedIndex = 0;
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Заполните все обязательные поля!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
            {
                MessageBox.Show("Введите корректный email!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnSend.Enabled = false;

                SendEmail();

                MessageBox.Show("Заявка успешно отправлена!", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}\n\nПроверьте настройки:\n" +
                                "1. Убедитесь, что в почтовом ящике Яндекса разрешен доступ для почтовых клиентов\n" +
                                "2. Убедитесь, что используется правильный пароль для приложения (не основной пароль)\n" +
                                "3. Проверьте настройки брандмауэра или антивируса",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnSend.Enabled = true;
            }
        }

        private void SendEmail()
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
                smtp.Credentials = new NetworkCredential(FROM_EMAIL, FROM_PASSWORD);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(FROM_EMAIL);
                mail.To.Add(TO_EMAIL);

                // Добавляем информацию о пользователе в тему письма
                string subject = $"Заявка: {cmbSubject.Text}";
                if (!string.IsNullOrEmpty(AuthorizationForm.SavedEmployeeName))
                {
                    subject += $" (от: {AuthorizationForm.SavedEmployeeName})";
                }
                else if (!string.IsNullOrEmpty(AuthorizationForm.SavedLogin))
                {
                    subject += $" (логин: {AuthorizationForm.SavedLogin})";
                }
                mail.Subject = subject;

                string messageBody = $"Новая заявка на сотрудничество\n\n" +
                                    $"ФИО: {txtName.Text}\n" +
                                    $"Email: {txtEmail.Text}\n" +
                                    $"Телефон: {txtPhone.Text}\n" +
                                    $"Тема: {cmbSubject.Text}\n\n" +
                                    $"Сообщение:\n{txtMessage.Text}\n\n" +
                                    $"Дата: {DateTime.Now:dd.MM.yyyy HH:mm}";

                mail.Body = messageBody;

                smtp.Send(mail);
            }
            catch
            {
                throw;
            }
        }

        private void ClearForm()
        {
            // Очищаем поля, но сохраняем данные из системы если они есть
            if (string.IsNullOrEmpty(AuthorizationForm.SavedEmployeeName))
            {
                txtName.Clear();
            }
            else
            {
                txtName.Text = AuthorizationForm.SavedEmployeeName;
            }

            txtEmail.Clear();
            txtPhone.Clear();
            txtMessage.Clear();
            cmbSubject.SelectedIndex = 0;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();

            // При возврате создаем новую форму авторизации
            // Данные уже сохранены в статических полях AuthorizationForm
            AuthorizationForm authForm = new AuthorizationForm();
            authForm.Show();
        }
    }
}
namespace Oil
{
    partial class GuestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblSubject = new Label();
            cmbSubject = new ComboBox();
            lblMessage = new Label();
            txtMessage = new TextBox();
            btnSend = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(200, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(801, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Заявка на сотрудничество";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblName.Location = new Point(60, 140);
            lblName.Name = "lblName";
            lblName.Size = new Size(74, 29);
            lblName.TabIndex = 1;
            lblName.Text = "ФИО:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Arial", 12F);
            txtName.Location = new Point(187, 140);
            txtName.Name = "txtName";
            txtName.Size = new Size(853, 30);
            txtName.TabIndex = 0;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblEmail.Location = new Point(60, 190);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(80, 29);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Arial", 12F);
            txtEmail.Location = new Point(187, 190);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(853, 30);
            txtEmail.TabIndex = 1;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPhone.Location = new Point(60, 240);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(112, 29);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "Телефон:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Arial", 12F);
            txtPhone.Location = new Point(187, 240);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(853, 30);
            txtPhone.TabIndex = 2;
            // 
            // lblSubject
            // 
            lblSubject.AutoSize = true;
            lblSubject.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblSubject.Location = new Point(60, 290);
            lblSubject.Name = "lblSubject";
            lblSubject.Size = new Size(72, 29);
            lblSubject.TabIndex = 7;
            lblSubject.Text = "Тема:";
            // 
            // cmbSubject
            // 
            cmbSubject.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubject.Font = new Font("Arial", 12F);
            cmbSubject.FormattingEnabled = true;
            cmbSubject.Items.AddRange(new object[] { "Запрос на сотрудничество", "Коммерческое предложение", "Запрос информации", "Жалоба или предложение", "Другое" });
            cmbSubject.Location = new Point(187, 290);
            cmbSubject.Name = "cmbSubject";
            cmbSubject.Size = new Size(853, 31);
            cmbSubject.TabIndex = 3;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblMessage.Location = new Point(60, 340);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(146, 29);
            lblMessage.TabIndex = 9;
            lblMessage.Text = "Сообщение:";
            // 
            // txtMessage
            // 
            txtMessage.Font = new Font("Arial", 12F);
            txtMessage.Location = new Point(211, 340);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.ScrollBars = ScrollBars.Vertical;
            txtMessage.Size = new Size(829, 200);
            txtMessage.TabIndex = 4;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.CadetBlue;
            btnSend.Font = new Font("Constantia", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(303, 562);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(250, 70);
            btnSend.TabIndex = 5;
            btnSend.Text = "Отправить заявку";
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += BtnSend_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightGray;
            btnBack.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnBack.Location = new Point(603, 562);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(250, 70);
            btnBack.TabIndex = 6;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BtnBack_Click;
            // 
            // GuestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 720);
            Controls.Add(btnBack);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(lblMessage);
            Controls.Add(cmbSubject);
            Controls.Add(lblSubject);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            Name = "GuestForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Заявка на сотрудничество";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblSubject;
        private ComboBox cmbSubject;
        private Label lblMessage;
        private TextBox txtMessage;
        private Button btnSend;
        private Button btnBack;
    }
}
namespace Oil
{
    partial class AuthorizationForm
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
            lblLogin = new Label();
            lblPassword = new Label();
            txtLogin = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            btnGuest = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(284, 60);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(616, 97);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Вход в систему";
            // 
            // lblLogin
            // 
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Constantia", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblLogin.Location = new Point(105, 233);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(110, 37);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Логин:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Constantia", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPassword.Location = new Point(105, 333);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(125, 37);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Пароль:";
            // 
            // txtLogin
            // 
            txtLogin.Font = new Font("Arial", 16F);
            txtLogin.Location = new Point(245, 233);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(710, 38);
            txtLogin.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Arial", 16F);
            txtPassword.Location = new Point(245, 333);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(710, 38);
            txtPassword.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.CadetBlue;
            btnLogin.Font = new Font("Constantia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(320, 453);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(250, 70);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnGuest
            // 
            btnGuest.BackColor = Color.LightGray;
            btnGuest.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnGuest.Location = new Point(620, 453);
            btnGuest.Name = "btnGuest";
            btnGuest.Size = new Size(250, 70);
            btnGuest.TabIndex = 4;
            btnGuest.Text = "Гостевой вход";
            btnGuest.UseVisualStyleBackColor = false;
            btnGuest.Click += btnGuest_Click;
            // 
            // AuthorizationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 600);
            Controls.Add(btnGuest);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtLogin);
            Controls.Add(lblPassword);
            Controls.Add(lblLogin);
            Controls.Add(lblTitle);
            Name = "AuthorizationForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Авторизация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblLogin;
        private Label lblPassword;
        private TextBox txtLogin;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnGuest;
    }
}
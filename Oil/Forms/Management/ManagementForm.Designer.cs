namespace Oil.Management
{
    partial class ManagementForm
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
            lblWelcome = new Label();
            btnEmployees = new Button();
            btnCounterparties = new Button();
            btnLabReports = new Button();
            btnInvoices = new Button();
            btnStorage = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(160, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(460, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Панель руководства";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblWelcome.Location = new Point(170, 100);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(451, 24);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Управление системой учёта нефтепродуктов";
            // 
            // btnEmployees
            // 
            btnEmployees.BackColor = Color.CadetBlue;
            btnEmployees.Font = new Font("Constantia", 10.2F, FontStyle.Bold);
            btnEmployees.ForeColor = Color.White;
            btnEmployees.Location = new Point(100, 160);
            btnEmployees.Name = "btnEmployees";
            btnEmployees.Size = new Size(250, 58);
            btnEmployees.TabIndex = 1;
            btnEmployees.Text = "Сотрудники";
            btnEmployees.UseVisualStyleBackColor = false;
            btnEmployees.Click += btnEmployees_Click;
            // 
            // btnCounterparties
            // 
            btnCounterparties.BackColor = Color.CadetBlue;
            btnCounterparties.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCounterparties.ForeColor = Color.White;
            btnCounterparties.Location = new Point(100, 240);
            btnCounterparties.Name = "btnCounterparties";
            btnCounterparties.Size = new Size(250, 58);
            btnCounterparties.TabIndex = 2;
            btnCounterparties.Text = "Контрагенты";
            btnCounterparties.UseVisualStyleBackColor = false;
            btnCounterparties.Click += btnCounterparties_Click;
            // 
            // btnLabReports
            // 
            btnLabReports.BackColor = Color.CadetBlue;
            btnLabReports.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnLabReports.ForeColor = Color.White;
            btnLabReports.Location = new Point(450, 160);
            btnLabReports.Name = "btnLabReports";
            btnLabReports.Size = new Size(250, 58);
            btnLabReports.TabIndex = 3;
            btnLabReports.Text = "Лабораторные анализы";
            btnLabReports.UseVisualStyleBackColor = false;
            btnLabReports.Click += btnLabReports_Click;
            // 
            // btnInvoices
            // 
            btnInvoices.BackColor = Color.CadetBlue;
            btnInvoices.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnInvoices.ForeColor = Color.White;
            btnInvoices.Location = new Point(450, 240);
            btnInvoices.Name = "btnInvoices";
            btnInvoices.Size = new Size(250, 58);
            btnInvoices.TabIndex = 4;
            btnInvoices.Text = "Накладные";
            btnInvoices.UseVisualStyleBackColor = false;
            btnInvoices.Click += btnInvoices_Click;
            // 
            // btnStorage
            // 
            btnStorage.BackColor = Color.CadetBlue;
            btnStorage.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnStorage.ForeColor = Color.White;
            btnStorage.Location = new Point(275, 320);
            btnStorage.Name = "btnStorage";
            btnStorage.Size = new Size(250, 58);
            btnStorage.TabIndex = 5;
            btnStorage.Text = "Склады";
            btnStorage.UseVisualStyleBackColor = false;
            btnStorage.Click += btnStorage_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LightGray;
            btnExit.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnExit.Location = new Point(275, 400);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(250, 47);
            btnExit.TabIndex = 6;
            btnExit.Text = "Выйти";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // ManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 500);
            Controls.Add(btnExit);
            Controls.Add(btnStorage);
            Controls.Add(btnInvoices);
            Controls.Add(btnLabReports);
            Controls.Add(btnCounterparties);
            Controls.Add(btnEmployees);
            Controls.Add(lblWelcome);
            Controls.Add(lblTitle);
            Name = "ManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Панель руководства";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblWelcome;
        private Button btnEmployees;
        private Button btnCounterparties;
        private Button btnLabReports;
        private Button btnInvoices;
        private Button btnStorage;
        private Button btnExit;
    }
}
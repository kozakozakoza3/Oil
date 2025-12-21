namespace Oil
{
    partial class TransportForm
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
            btnTrains = new Button();
            btnRoutes = new Button();
            btnInvoices = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(300, 53);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(459, 97);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Логистика";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Constantia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblWelcome.Location = new Point(103, 182);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(843, 37);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Управление транспортными средствами и перевозками";
            // 
            // btnTrains
            // 
            btnTrains.BackColor = Color.CadetBlue;
            btnTrains.Font = new Font("Constantia", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnTrains.ForeColor = Color.White;
            btnTrains.Location = new Point(137, 270);
            btnTrains.Name = "btnTrains";
            btnTrains.Size = new Size(770, 106);
            btnTrains.TabIndex = 1;
            btnTrains.Text = "Поезда";
            btnTrains.UseVisualStyleBackColor = false;
            btnTrains.Click += btnTrains_Click;
            // 
            // btnRoutes
            // 
            btnRoutes.BackColor = Color.CadetBlue;
            btnRoutes.Font = new Font("Constantia", 22.2F, FontStyle.Bold);
            btnRoutes.ForeColor = Color.White;
            btnRoutes.Location = new Point(137, 423);
            btnRoutes.Name = "btnRoutes";
            btnRoutes.Size = new Size(770, 106);
            btnRoutes.TabIndex = 4;
            btnRoutes.Text = "Маршруты";
            btnRoutes.UseVisualStyleBackColor = false;
            btnRoutes.Click += btnRoutes_Click;
            // 
            // btnInvoices
            // 
            btnInvoices.BackColor = Color.CadetBlue;
            btnInvoices.Font = new Font("Constantia", 22.2F, FontStyle.Bold);
            btnInvoices.ForeColor = Color.White;
            btnInvoices.Location = new Point(137, 570);
            btnInvoices.Name = "btnInvoices";
            btnInvoices.Size = new Size(770, 106);
            btnInvoices.TabIndex = 5;
            btnInvoices.Text = "Накладные";
            btnInvoices.UseVisualStyleBackColor = false;
            btnInvoices.Click += btnInvoices_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LightGray;
            btnExit.Font = new Font("Arial", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnExit.Location = new Point(137, 712);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(770, 85);
            btnExit.TabIndex = 6;
            btnExit.Text = "Выйти";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // TransportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1036, 821);
            Controls.Add(btnExit);
            Controls.Add(btnInvoices);
            Controls.Add(btnRoutes);
            Controls.Add(btnTrains);
            Controls.Add(lblWelcome);
            Controls.Add(lblTitle);
            Name = "TransportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Транспорт";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblWelcome;
        private Button btnTrains;
        private Button btnRoutes;
        private Button btnInvoices;
        private Button btnExit;
    }
}
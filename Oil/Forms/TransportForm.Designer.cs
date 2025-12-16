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
            btnTransportLogistics = new Button();
            btnVehicleManagement = new Button();
            btnRoutePlanning = new Button();
            btnCargoTracking = new Button();
            btnReports = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(288, 49);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(459, 97);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Транспорт";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Constantia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblWelcome.Location = new Point(279, 166);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(454, 37);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Выберите раздел для работы:";
            // 
            // btnTransportLogistics
            // 
            btnTransportLogistics.BackColor = Color.CadetBlue;
            btnTransportLogistics.Font = new Font("Constantia", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnTransportLogistics.ForeColor = Color.White;
            btnTransportLogistics.Location = new Point(124, 238);
            btnTransportLogistics.Name = "btnTransportLogistics";
            btnTransportLogistics.Size = new Size(770, 58);
            btnTransportLogistics.TabIndex = 1;
            btnTransportLogistics.Text = "Транспортная логистика";
            btnTransportLogistics.UseVisualStyleBackColor = false;
            // 
            // btnVehicleManagement
            // 
            btnVehicleManagement.BackColor = Color.CadetBlue;
            btnVehicleManagement.Font = new Font("Constantia", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnVehicleManagement.ForeColor = Color.White;
            btnVehicleManagement.Location = new Point(124, 326);
            btnVehicleManagement.Name = "btnVehicleManagement";
            btnVehicleManagement.Size = new Size(770, 58);
            btnVehicleManagement.TabIndex = 2;
            btnVehicleManagement.Text = "Управление транспортом";
            btnVehicleManagement.UseVisualStyleBackColor = false;
            // 
            // btnRoutePlanning
            // 
            btnRoutePlanning.BackColor = Color.CadetBlue;
            btnRoutePlanning.Font = new Font("Constantia", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRoutePlanning.ForeColor = Color.White;
            btnRoutePlanning.Location = new Point(124, 416);
            btnRoutePlanning.Name = "btnRoutePlanning";
            btnRoutePlanning.Size = new Size(770, 58);
            btnRoutePlanning.TabIndex = 3;
            btnRoutePlanning.Text = "Планирование маршрутов";
            btnRoutePlanning.UseVisualStyleBackColor = false;
            // 
            // btnCargoTracking
            // 
            btnCargoTracking.BackColor = Color.CadetBlue;
            btnCargoTracking.Font = new Font("Constantia", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCargoTracking.ForeColor = Color.White;
            btnCargoTracking.Location = new Point(124, 507);
            btnCargoTracking.Name = "btnCargoTracking";
            btnCargoTracking.Size = new Size(770, 58);
            btnCargoTracking.TabIndex = 4;
            btnCargoTracking.Text = "Отслеживание грузов";
            btnCargoTracking.UseVisualStyleBackColor = false;
            // 
            // btnReports
            // 
            btnReports.BackColor = Color.SteelBlue;
            btnReports.Font = new Font("Constantia", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnReports.ForeColor = Color.White;
            btnReports.Location = new Point(124, 598);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(770, 58);
            btnReports.TabIndex = 5;
            btnReports.Text = "Отчеты по транспорту";
            btnReports.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightGray;
            btnBack.Font = new Font("Arial", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnBack.Location = new Point(124, 688);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(770, 47);
            btnBack.TabIndex = 6;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // TransportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1036, 659);
            Controls.Add(btnBack);
            Controls.Add(btnReports);
            Controls.Add(btnCargoTracking);
            Controls.Add(btnRoutePlanning);
            Controls.Add(btnVehicleManagement);
            Controls.Add(btnTransportLogistics);
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
        private Button btnTransportLogistics;
        private Button btnVehicleManagement;
        private Button btnRoutePlanning;
        private Button btnCargoTracking;
        private Button btnReports;
        private Button btnBack;
    }
}
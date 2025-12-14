namespace Oil
{
    partial class StorageForm
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
            btnTanks = new Button();
            btnOilLots = new Button();
            btnProductLots = new Button();
            btnStorageUnits = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(536, 58);
            lblTitle.Margin = new Padding(5, 0, 5, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(241, 85);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Склад";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblWelcome.Location = new Point(406, 160);
            lblWelcome.Margin = new Padding(5, 0, 5, 0);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(484, 39);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Выберите раздел для работы:";
            // 
            // btnTanks
            // 
            btnTanks.BackColor = Color.CadetBlue;
            btnTanks.Font = new Font("Constantia", 10.2F, FontStyle.Bold);
            btnTanks.ForeColor = Color.White;
            btnTanks.Location = new Point(312, 240);
            btnTanks.Margin = new Padding(5, 5, 5, 5);
            btnTanks.Name = "btnTanks";
            btnTanks.Size = new Size(663, 93);
            btnTanks.TabIndex = 1;
            btnTanks.Text = "Резервуары";
            btnTanks.UseVisualStyleBackColor = false;
            btnTanks.Click += btnTanks_Click;
            // 
            // btnOilLots
            // 
            btnOilLots.BackColor = Color.CadetBlue;
            btnOilLots.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnOilLots.ForeColor = Color.White;
            btnOilLots.Location = new Point(312, 358);
            btnOilLots.Margin = new Padding(5, 5, 5, 5);
            btnOilLots.Name = "btnOilLots";
            btnOilLots.Size = new Size(663, 93);
            btnOilLots.TabIndex = 2;
            btnOilLots.Text = "Партии нефти на складе";
            btnOilLots.UseVisualStyleBackColor = false;
            btnOilLots.Click += btnOilLots_Click;
            // 
            // btnProductLots
            // 
            btnProductLots.BackColor = Color.CadetBlue;
            btnProductLots.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnProductLots.ForeColor = Color.White;
            btnProductLots.Location = new Point(312, 477);
            btnProductLots.Margin = new Padding(5, 5, 5, 5);
            btnProductLots.Name = "btnProductLots";
            btnProductLots.Size = new Size(663, 93);
            btnProductLots.TabIndex = 3;
            btnProductLots.Text = "Партии нефтепродуктов на складе";
            btnProductLots.UseVisualStyleBackColor = false;
            btnProductLots.Click += btnProductLots_Click;
            // 
            // btnStorageUnits
            // 
            btnStorageUnits.BackColor = Color.CadetBlue;
            btnStorageUnits.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnStorageUnits.ForeColor = Color.White;
            btnStorageUnits.Location = new Point(312, 595);
            btnStorageUnits.Margin = new Padding(5, 5, 5, 5);
            btnStorageUnits.Name = "btnStorageUnits";
            btnStorageUnits.Size = new Size(663, 93);
            btnStorageUnits.TabIndex = 4;
            btnStorageUnits.Text = "Хранилища";
            btnStorageUnits.UseVisualStyleBackColor = false;
            btnStorageUnits.Click += btnStorageUnits_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LightGray;
            btnExit.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnExit.Location = new Point(312, 720);
            btnExit.Margin = new Padding(5, 5, 5, 5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(663, 75);
            btnExit.TabIndex = 5;
            btnExit.Text = "Выйти";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // StorageForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1300, 832);
            Controls.Add(btnExit);
            Controls.Add(btnStorageUnits);
            Controls.Add(btnProductLots);
            Controls.Add(btnOilLots);
            Controls.Add(btnTanks);
            Controls.Add(lblWelcome);
            Controls.Add(lblTitle);
            Margin = new Padding(5, 5, 5, 5);
            Name = "StorageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Склад";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblWelcome;
        private Button btnTanks;
        private Button btnOilLots;
        private Button btnProductLots;
        private Button btnStorageUnits;
        private Button btnExit;
    }
}
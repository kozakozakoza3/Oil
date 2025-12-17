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
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(380, 57);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(279, 97);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Склад";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Constantia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblWelcome.Location = new Point(287, 171);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(454, 37);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Выберите раздел для работы:";
            // 
            // btnTanks
            // 
            btnTanks.BackColor = Color.CadetBlue;
            btnTanks.Font = new Font("Constantia", 13.875F, FontStyle.Bold);
            btnTanks.ForeColor = Color.White;
            btnTanks.Location = new Point(130, 240);
            btnTanks.Name = "btnTanks";
            btnTanks.Size = new Size(770, 80);
            btnTanks.TabIndex = 1;
            btnTanks.Text = "Резервуары";
            btnTanks.UseVisualStyleBackColor = false;
            btnTanks.Click += btnTanks_Click;
            // 
            // btnOilLots
            // 
            btnOilLots.BackColor = Color.CadetBlue;
            btnOilLots.Font = new Font("Constantia", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnOilLots.ForeColor = Color.White;
            btnOilLots.Location = new Point(130, 340);
            btnOilLots.Name = "btnOilLots";
            btnOilLots.Size = new Size(770, 80);
            btnOilLots.TabIndex = 2;
            btnOilLots.Text = "Партии нефти на складе";
            btnOilLots.UseVisualStyleBackColor = false;
            btnOilLots.Click += btnOilLots_Click;
            // 
            // btnProductLots
            // 
            btnProductLots.BackColor = Color.CadetBlue;
            btnProductLots.Font = new Font("Constantia", 13.875F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnProductLots.ForeColor = Color.White;
            btnProductLots.Location = new Point(130, 440);
            btnProductLots.Name = "btnProductLots";
            btnProductLots.Size = new Size(770, 80);
            btnProductLots.TabIndex = 3;
            btnProductLots.Text = "Партии нефтепродуктов на складе";
            btnProductLots.UseVisualStyleBackColor = false;
            btnProductLots.Click += btnProductLots_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LightGray;
            btnExit.Font = new Font("Arial", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnExit.Location = new Point(130, 540);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(770, 70);
            btnExit.TabIndex = 4;
            btnExit.Text = "Выйти";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // StorageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1036, 650);
            Controls.Add(btnExit);
            Controls.Add(btnProductLots);
            Controls.Add(btnOilLots);
            Controls.Add(btnTanks);
            Controls.Add(lblWelcome);
            Controls.Add(lblTitle);
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
        private Button btnExit;
    }
}
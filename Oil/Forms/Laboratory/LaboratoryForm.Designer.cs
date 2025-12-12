namespace Oil
{
    partial class LaboratoryForm
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
            btnOil = new Button();
            btnProducts = new Button();
            btnAnalysis = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(240, 34);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(312, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Лаборатория";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblWelcome.Location = new Point(250, 100);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(303, 24);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Выберите раздел для работы:";
            // 
            // btnOil
            // 
            btnOil.BackColor = Color.CadetBlue;
            btnOil.Font = new Font("Constantia", 10.2F, FontStyle.Bold);
            btnOil.ForeColor = Color.White;
            btnOil.Location = new Point(192, 150);
            btnOil.Name = "btnOil";
            btnOil.Size = new Size(408, 58);
            btnOil.TabIndex = 1;
            btnOil.Text = "Партии нефти";
            btnOil.UseVisualStyleBackColor = false;
            btnOil.Click += btnOil_Click;
            // 
            // btnProducts
            // 
            btnProducts.BackColor = Color.CadetBlue;
            btnProducts.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnProducts.ForeColor = Color.White;
            btnProducts.Location = new Point(192, 224);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(408, 58);
            btnProducts.TabIndex = 2;
            btnProducts.Text = "Нефтепродукты";
            btnProducts.UseVisualStyleBackColor = false;
            btnProducts.Click += btnProducts_Click;
            // 
            // btnAnalysis
            // 
            btnAnalysis.BackColor = Color.CadetBlue;
            btnAnalysis.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAnalysis.ForeColor = Color.White;
            btnAnalysis.Location = new Point(192, 298);
            btnAnalysis.Name = "btnAnalysis";
            btnAnalysis.Size = new Size(408, 58);
            btnAnalysis.TabIndex = 3;
            btnAnalysis.Text = "Лабораторные анализы";
            btnAnalysis.UseVisualStyleBackColor = false;
            btnAnalysis.Click += btnAnalysis_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LightGray;
            btnExit.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnExit.Location = new Point(192, 383);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(408, 47);
            btnExit.TabIndex = 5;
            btnExit.Text = "Выйти";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // LaboratoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            Controls.Add(btnExit);
            Controls.Add(btnAnalysis);
            Controls.Add(btnProducts);
            Controls.Add(btnOil);
            Controls.Add(lblWelcome);
            Controls.Add(lblTitle);
            Name = "LaboratoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Лаборатория";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblWelcome;
        private Button btnOil;
        private Button btnProducts;
        private Button btnAnalysis;
        private Button btnExit;
    }
}
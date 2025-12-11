namespace Oil
{
    partial class LaboratoryAnalysisForm
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
            lblProductName = new Label();
            txtProductName = new TextBox();
            lblAnalyst = new Label();
            txtAnalyst = new TextBox();
            lblDensity = new Label();
            txtDensity = new TextBox();
            lblSulfurContent = new Label();
            txtSulfurContent = new TextBox();
            lblWaterContent = new Label();
            txtWaterContent = new TextBox();
            lblViscosity = new Label();
            txtViscosity = new TextBox();
            lblFlashPoint = new Label();
            txtFlashPoint = new TextBox();
            lblAnalysisDate = new Label();
            dtpAnalysisDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(134, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(368, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ЛАБОРАТОРНЫЙ АНАЛИЗ";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblProductName.Location = new Point(70, 80);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(162, 19);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Название продукта:";
            // 
            // txtProductName
            // 
            txtProductName.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtProductName.Location = new Point(230, 77);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(316, 27);
            txtProductName.TabIndex = 1;
            // 
            // lblAnalyst
            // 
            lblAnalyst.AutoSize = true;
            lblAnalyst.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblAnalyst.Location = new Point(70, 120);
            lblAnalyst.Name = "lblAnalyst";
            lblAnalyst.Size = new Size(86, 19);
            lblAnalyst.TabIndex = 3;
            lblAnalyst.Text = "Аналитик:";
            // 
            // txtAnalyst
            // 
            txtAnalyst.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtAnalyst.Location = new Point(230, 117);
            txtAnalyst.Name = "txtAnalyst";
            txtAnalyst.ReadOnly = true;
            txtAnalyst.Size = new Size(316, 27);
            txtAnalyst.TabIndex = 2;
            // 
            // lblDensity
            // 
            lblDensity.AutoSize = true;
            lblDensity.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblDensity.Location = new Point(70, 160);
            lblDensity.Name = "lblDensity";
            lblDensity.Size = new Size(96, 19);
            lblDensity.TabIndex = 5;
            lblDensity.Text = "Плотность:";
            // 
            // txtDensity
            // 
            txtDensity.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtDensity.Location = new Point(230, 157);
            txtDensity.Name = "txtDensity";
            txtDensity.Size = new Size(316, 27);
            txtDensity.TabIndex = 3;
            // 
            // lblSulfurContent
            // 
            lblSulfurContent.AutoSize = true;
            lblSulfurContent.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblSulfurContent.Location = new Point(70, 200);
            lblSulfurContent.Name = "lblSulfurContent";
            lblSulfurContent.Size = new Size(154, 19);
            lblSulfurContent.TabIndex = 7;
            lblSulfurContent.Text = "Содержание серы:";
            // 
            // txtSulfurContent
            // 
            txtSulfurContent.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtSulfurContent.Location = new Point(230, 197);
            txtSulfurContent.Name = "txtSulfurContent";
            txtSulfurContent.Size = new Size(316, 27);
            txtSulfurContent.TabIndex = 4;
            // 
            // lblWaterContent
            // 
            lblWaterContent.AutoSize = true;
            lblWaterContent.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblWaterContent.Location = new Point(70, 240);
            lblWaterContent.Name = "lblWaterContent";
            lblWaterContent.Size = new Size(155, 19);
            lblWaterContent.TabIndex = 9;
            lblWaterContent.Text = "Содержание воды:";
            // 
            // txtWaterContent
            // 
            txtWaterContent.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtWaterContent.Location = new Point(230, 237);
            txtWaterContent.Name = "txtWaterContent";
            txtWaterContent.Size = new Size(316, 27);
            txtWaterContent.TabIndex = 5;
            // 
            // lblViscosity
            // 
            lblViscosity.AutoSize = true;
            lblViscosity.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblViscosity.Location = new Point(70, 280);
            lblViscosity.Name = "lblViscosity";
            lblViscosity.Size = new Size(84, 19);
            lblViscosity.TabIndex = 11;
            lblViscosity.Text = "Вязкость:";
            // 
            // txtViscosity
            // 
            txtViscosity.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtViscosity.Location = new Point(230, 277);
            txtViscosity.Name = "txtViscosity";
            txtViscosity.Size = new Size(316, 27);
            txtViscosity.TabIndex = 6;
            // 
            // lblFlashPoint
            // 
            lblFlashPoint.AutoSize = true;
            lblFlashPoint.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFlashPoint.Location = new Point(70, 320);
            lblFlashPoint.Name = "lblFlashPoint";
            lblFlashPoint.Size = new Size(166, 19);
            lblFlashPoint.TabIndex = 13;
            lblFlashPoint.Text = "Темп. вспышки (°C):";
            // 
            // txtFlashPoint
            // 
            txtFlashPoint.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtFlashPoint.Location = new Point(230, 317);
            txtFlashPoint.Name = "txtFlashPoint";
            txtFlashPoint.Size = new Size(316, 27);
            txtFlashPoint.TabIndex = 7;
            // 
            // lblAnalysisDate
            // 
            lblAnalysisDate.AutoSize = true;
            lblAnalysisDate.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblAnalysisDate.Location = new Point(70, 360);
            lblAnalysisDate.Name = "lblAnalysisDate";
            lblAnalysisDate.Size = new Size(120, 19);
            lblAnalysisDate.TabIndex = 15;
            lblAnalysisDate.Text = "Дата анализа:";
            // 
            // dtpAnalysisDate
            // 
            dtpAnalysisDate.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dtpAnalysisDate.Location = new Point(230, 357);
            dtpAnalysisDate.Name = "dtpAnalysisDate";
            dtpAnalysisDate.Size = new Size(316, 27);
            dtpAnalysisDate.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SeaGreen;
            btnSave.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(169, 411);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 35);
            btnSave.TabIndex = 9;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(309, 411);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 35);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // LaboratoryAnalysisForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(631, 470);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpAnalysisDate);
            Controls.Add(lblAnalysisDate);
            Controls.Add(txtFlashPoint);
            Controls.Add(lblFlashPoint);
            Controls.Add(txtViscosity);
            Controls.Add(lblViscosity);
            Controls.Add(txtWaterContent);
            Controls.Add(lblWaterContent);
            Controls.Add(txtSulfurContent);
            Controls.Add(lblSulfurContent);
            Controls.Add(txtDensity);
            Controls.Add(lblDensity);
            Controls.Add(txtAnalyst);
            Controls.Add(lblAnalyst);
            Controls.Add(txtProductName);
            Controls.Add(lblProductName);
            Controls.Add(lblTitle);
            Name = "LaboratoryAnalysisForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Лабораторный анализ";
            Load += LaboratoryAnalysisForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblProductName;
        private TextBox txtProductName;
        private Label lblAnalyst;
        private TextBox txtAnalyst;
        private Label lblDensity;
        private TextBox txtDensity;
        private Label lblSulfurContent;
        private TextBox txtSulfurContent;
        private Label lblWaterContent;
        private TextBox txtWaterContent;
        private Label lblViscosity;
        private TextBox txtViscosity;
        private Label lblFlashPoint;
        private TextBox txtFlashPoint;
        private Label lblAnalysisDate;
        private DateTimePicker dtpAnalysisDate;
        private Button btnSave;
        private Button btnCancel;
    }
}
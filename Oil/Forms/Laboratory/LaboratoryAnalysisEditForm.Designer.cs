namespace Oil.Forms
{
    partial class LaboratoryAnalysisEditForm
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
            lblOilProduct = new Label();
            cbxOilProduct = new ComboBox();
            lblEmployee = new Label();
            cbxEmployee = new ComboBox();
            lblSampleVolume = new Label();
            txtSampleVolume = new TextBox();
            lblUnitVolume = new Label();
            cbxUnitVolume = new ComboBox();
            lblOilProductDensity = new Label();
            txtOilProductDensity = new TextBox();
            lblUnitDensity = new Label();
            cbxUnitDensity = new ComboBox();
            lblOilProductSulfurContent = new Label();
            txtOilProductSulfurContent = new TextBox();
            lblUnitSulfur = new Label();
            cbxUnitSulfur = new ComboBox();
            lblOilProductViscosity = new Label();
            txtOilProductViscosity = new TextBox();
            lblUnitViscosity = new Label();
            cbxUnitViscosity = new ComboBox();
            lblOilProductFlashPoint = new Label();
            txtOilProductFlashPoint = new TextBox();
            lblUnitFlash = new Label();
            cbxUnitFlash = new ComboBox();
            lblOilProductWaterContent = new Label();
            txtOilProductWaterContent = new TextBox();
            lblUnitWater = new Label();
            cbxUnitWater = new ComboBox();
            lblDateTimeAnalysis = new Label();
            dtpDateTimeAnalysis = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(159, 36);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(861, 58);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Добавление лабораторного анализа";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblOilProduct
            // 
            lblOilProduct.AutoSize = true;
            lblOilProduct.Font = new Font("Constantia", 12F);
            lblOilProduct.Location = new Point(59, 127);
            lblOilProduct.Name = "lblOilProduct";
            lblOilProduct.Size = new Size(150, 24);
            lblOilProduct.TabIndex = 1;
            lblOilProduct.Text = "Нефтепродукт:";
            // 
            // cbxOilProduct
            // 
            cbxOilProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxOilProduct.Font = new Font("Arial", 10F);
            cbxOilProduct.FormattingEnabled = true;
            cbxOilProduct.Location = new Point(247, 127);
            cbxOilProduct.Name = "cbxOilProduct";
            cbxOilProduct.Size = new Size(827, 27);
            cbxOilProduct.TabIndex = 1;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Font = new Font("Constantia", 12F);
            lblEmployee.Location = new Point(59, 177);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(115, 24);
            lblEmployee.TabIndex = 3;
            lblEmployee.Text = "Сотрудник:";
            // 
            // cbxEmployee
            // 
            cbxEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEmployee.Font = new Font("Arial", 10F);
            cbxEmployee.FormattingEnabled = true;
            cbxEmployee.Location = new Point(247, 177);
            cbxEmployee.Name = "cbxEmployee";
            cbxEmployee.Size = new Size(827, 27);
            cbxEmployee.TabIndex = 2;
            // 
            // lblSampleVolume
            // 
            lblSampleVolume.AutoSize = true;
            lblSampleVolume.Font = new Font("Constantia", 12F);
            lblSampleVolume.Location = new Point(59, 227);
            lblSampleVolume.Name = "lblSampleVolume";
            lblSampleVolume.Size = new Size(142, 24);
            lblSampleVolume.TabIndex = 5;
            lblSampleVolume.Text = "Объем пробы:";
            // 
            // txtSampleVolume
            // 
            txtSampleVolume.Font = new Font("Arial", 10F);
            txtSampleVolume.Location = new Point(247, 227);
            txtSampleVolume.Name = "txtSampleVolume";
            txtSampleVolume.Size = new Size(827, 27);
            txtSampleVolume.TabIndex = 3;
            txtSampleVolume.KeyPress += txtNumeric_KeyPress;
            // 
            // lblUnitVolume
            // 
            lblUnitVolume.AutoSize = true;
            lblUnitVolume.Font = new Font("Constantia", 12F);
            lblUnitVolume.Location = new Point(734, 278);
            lblUnitVolume.Name = "lblUnitVolume";
            lblUnitVolume.Size = new Size(141, 24);
            lblUnitVolume.TabIndex = 7;
            lblUnitVolume.Text = "Единица изм.:";
            // 
            // cbxUnitVolume
            // 
            cbxUnitVolume.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxUnitVolume.Font = new Font("Arial", 10F);
            cbxUnitVolume.FormattingEnabled = true;
            cbxUnitVolume.Location = new Point(897, 274);
            cbxUnitVolume.Name = "cbxUnitVolume";
            cbxUnitVolume.Size = new Size(177, 27);
            cbxUnitVolume.TabIndex = 4;
            // 
            // lblOilProductDensity
            // 
            lblOilProductDensity.AutoSize = true;
            lblOilProductDensity.Font = new Font("Constantia", 12F);
            lblOilProductDensity.Location = new Point(59, 277);
            lblOilProductDensity.Name = "lblOilProductDensity";
            lblOilProductDensity.Size = new Size(204, 24);
            lblOilProductDensity.TabIndex = 9;
            lblOilProductDensity.Text = "Плотность продукта:";
            // 
            // txtOilProductDensity
            // 
            txtOilProductDensity.Font = new Font("Arial", 10F);
            txtOilProductDensity.Location = new Point(280, 275);
            txtOilProductDensity.Name = "txtOilProductDensity";
            txtOilProductDensity.Size = new Size(406, 27);
            txtOilProductDensity.TabIndex = 5;
            txtOilProductDensity.KeyPress += txtNumeric_KeyPress;
            // 
            // lblUnitDensity
            // 
            lblUnitDensity.AutoSize = true;
            lblUnitDensity.Font = new Font("Constantia", 12F);
            lblUnitDensity.Location = new Point(734, 328);
            lblUnitDensity.Name = "lblUnitDensity";
            lblUnitDensity.Size = new Size(141, 24);
            lblUnitDensity.TabIndex = 11;
            lblUnitDensity.Text = "Единица изм.:";
            // 
            // cbxUnitDensity
            // 
            cbxUnitDensity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxUnitDensity.Font = new Font("Arial", 10F);
            cbxUnitDensity.FormattingEnabled = true;
            cbxUnitDensity.Location = new Point(897, 324);
            cbxUnitDensity.Name = "cbxUnitDensity";
            cbxUnitDensity.Size = new Size(177, 27);
            cbxUnitDensity.TabIndex = 6;
            // 
            // lblOilProductSulfurContent
            // 
            lblOilProductSulfurContent.AutoSize = true;
            lblOilProductSulfurContent.Font = new Font("Constantia", 12F);
            lblOilProductSulfurContent.Location = new Point(59, 327);
            lblOilProductSulfurContent.Name = "lblOilProductSulfurContent";
            lblOilProductSulfurContent.Size = new Size(178, 24);
            lblOilProductSulfurContent.TabIndex = 13;
            lblOilProductSulfurContent.Text = "Содержание серы:";
            // 
            // txtOilProductSulfurContent
            // 
            txtOilProductSulfurContent.Font = new Font("Arial", 10F);
            txtOilProductSulfurContent.Location = new Point(280, 325);
            txtOilProductSulfurContent.Name = "txtOilProductSulfurContent";
            txtOilProductSulfurContent.Size = new Size(406, 27);
            txtOilProductSulfurContent.TabIndex = 7;
            txtOilProductSulfurContent.KeyPress += txtNumeric_KeyPress;
            // 
            // lblUnitSulfur
            // 
            lblUnitSulfur.AutoSize = true;
            lblUnitSulfur.Font = new Font("Constantia", 12F);
            lblUnitSulfur.Location = new Point(734, 378);
            lblUnitSulfur.Name = "lblUnitSulfur";
            lblUnitSulfur.Size = new Size(141, 24);
            lblUnitSulfur.TabIndex = 15;
            lblUnitSulfur.Text = "Единица изм.:";
            // 
            // cbxUnitSulfur
            // 
            cbxUnitSulfur.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxUnitSulfur.Font = new Font("Arial", 10F);
            cbxUnitSulfur.FormattingEnabled = true;
            cbxUnitSulfur.Location = new Point(897, 374);
            cbxUnitSulfur.Name = "cbxUnitSulfur";
            cbxUnitSulfur.Size = new Size(177, 27);
            cbxUnitSulfur.TabIndex = 8;
            // 
            // lblOilProductViscosity
            // 
            lblOilProductViscosity.AutoSize = true;
            lblOilProductViscosity.Font = new Font("Constantia", 12F);
            lblOilProductViscosity.Location = new Point(59, 377);
            lblOilProductViscosity.Name = "lblOilProductViscosity";
            lblOilProductViscosity.Size = new Size(187, 24);
            lblOilProductViscosity.TabIndex = 17;
            lblOilProductViscosity.Text = "Вязкость продукта:";
            // 
            // txtOilProductViscosity
            // 
            txtOilProductViscosity.Font = new Font("Arial", 10F);
            txtOilProductViscosity.Location = new Point(280, 375);
            txtOilProductViscosity.Name = "txtOilProductViscosity";
            txtOilProductViscosity.Size = new Size(406, 27);
            txtOilProductViscosity.TabIndex = 9;
            txtOilProductViscosity.KeyPress += txtNumeric_KeyPress;
            // 
            // lblUnitViscosity
            // 
            lblUnitViscosity.AutoSize = true;
            lblUnitViscosity.Font = new Font("Constantia", 12F);
            lblUnitViscosity.Location = new Point(734, 428);
            lblUnitViscosity.Name = "lblUnitViscosity";
            lblUnitViscosity.Size = new Size(141, 24);
            lblUnitViscosity.TabIndex = 19;
            lblUnitViscosity.Text = "Единица изм.:";
            // 
            // cbxUnitViscosity
            // 
            cbxUnitViscosity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxUnitViscosity.Font = new Font("Arial", 10F);
            cbxUnitViscosity.FormattingEnabled = true;
            cbxUnitViscosity.Location = new Point(897, 424);
            cbxUnitViscosity.Name = "cbxUnitViscosity";
            cbxUnitViscosity.Size = new Size(177, 27);
            cbxUnitViscosity.TabIndex = 10;
            // 
            // lblOilProductFlashPoint
            // 
            lblOilProductFlashPoint.AutoSize = true;
            lblOilProductFlashPoint.Font = new Font("Constantia", 12F);
            lblOilProductFlashPoint.Location = new Point(59, 427);
            lblOilProductFlashPoint.Name = "lblOilProductFlashPoint";
            lblOilProductFlashPoint.Size = new Size(222, 24);
            lblOilProductFlashPoint.TabIndex = 21;
            lblOilProductFlashPoint.Text = "Температура вспышки:";
            // 
            // txtOilProductFlashPoint
            // 
            txtOilProductFlashPoint.Font = new Font("Arial", 10F);
            txtOilProductFlashPoint.Location = new Point(280, 425);
            txtOilProductFlashPoint.Name = "txtOilProductFlashPoint";
            txtOilProductFlashPoint.Size = new Size(406, 27);
            txtOilProductFlashPoint.TabIndex = 11;
            txtOilProductFlashPoint.KeyPress += txtInteger_KeyPress;
            // 
            // lblUnitFlash
            // 
            lblUnitFlash.AutoSize = true;
            lblUnitFlash.Font = new Font("Constantia", 12F);
            lblUnitFlash.Location = new Point(734, 478);
            lblUnitFlash.Name = "lblUnitFlash";
            lblUnitFlash.Size = new Size(141, 24);
            lblUnitFlash.TabIndex = 23;
            lblUnitFlash.Text = "Единица изм.:";
            // 
            // cbxUnitFlash
            // 
            cbxUnitFlash.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxUnitFlash.Font = new Font("Arial", 10F);
            cbxUnitFlash.FormattingEnabled = true;
            cbxUnitFlash.Location = new Point(897, 474);
            cbxUnitFlash.Name = "cbxUnitFlash";
            cbxUnitFlash.Size = new Size(177, 27);
            cbxUnitFlash.TabIndex = 12;
            // 
            // lblOilProductWaterContent
            // 
            lblOilProductWaterContent.AutoSize = true;
            lblOilProductWaterContent.Font = new Font("Constantia", 12F);
            lblOilProductWaterContent.Location = new Point(59, 477);
            lblOilProductWaterContent.Name = "lblOilProductWaterContent";
            lblOilProductWaterContent.Size = new Size(179, 24);
            lblOilProductWaterContent.TabIndex = 25;
            lblOilProductWaterContent.Text = "Содержание воды:";
            // 
            // txtOilProductWaterContent
            // 
            txtOilProductWaterContent.Font = new Font("Arial", 10F);
            txtOilProductWaterContent.Location = new Point(280, 475);
            txtOilProductWaterContent.Name = "txtOilProductWaterContent";
            txtOilProductWaterContent.Size = new Size(406, 27);
            txtOilProductWaterContent.TabIndex = 13;
            txtOilProductWaterContent.KeyPress += txtNumeric_KeyPress;
            // 
            // lblUnitWater
            // 
            lblUnitWater.AutoSize = true;
            lblUnitWater.Font = new Font("Constantia", 12F);
            lblUnitWater.Location = new Point(734, 528);
            lblUnitWater.Name = "lblUnitWater";
            lblUnitWater.Size = new Size(141, 24);
            lblUnitWater.TabIndex = 27;
            lblUnitWater.Text = "Единица изм.:";
            // 
            // cbxUnitWater
            // 
            cbxUnitWater.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxUnitWater.Font = new Font("Arial", 10F);
            cbxUnitWater.FormattingEnabled = true;
            cbxUnitWater.Location = new Point(897, 524);
            cbxUnitWater.Name = "cbxUnitWater";
            cbxUnitWater.Size = new Size(177, 27);
            cbxUnitWater.TabIndex = 14;
            // 
            // lblDateTimeAnalysis
            // 
            lblDateTimeAnalysis.AutoSize = true;
            lblDateTimeAnalysis.Font = new Font("Constantia", 12F);
            lblDateTimeAnalysis.Location = new Point(59, 527);
            lblDateTimeAnalysis.Name = "lblDateTimeAnalysis";
            lblDateTimeAnalysis.Size = new Size(215, 24);
            lblDateTimeAnalysis.TabIndex = 29;
            lblDateTimeAnalysis.Text = "Дата и время анализа:";
            // 
            // dtpDateTimeAnalysis
            // 
            dtpDateTimeAnalysis.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpDateTimeAnalysis.Font = new Font("Arial", 10F);
            dtpDateTimeAnalysis.Format = DateTimePickerFormat.Custom;
            dtpDateTimeAnalysis.Location = new Point(280, 525);
            dtpDateTimeAnalysis.Name = "dtpDateTimeAnalysis";
            dtpDateTimeAnalysis.Size = new Size(406, 27);
            dtpDateTimeAnalysis.TabIndex = 15;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(397, 599);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(163, 55);
            btnSave.TabIndex = 16;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Constantia", 12F);
            btnCancel.Location = new Point(566, 599);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(163, 55);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // LaboratoryAnalysisEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 700);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpDateTimeAnalysis);
            Controls.Add(lblDateTimeAnalysis);
            Controls.Add(cbxUnitWater);
            Controls.Add(lblUnitWater);
            Controls.Add(txtOilProductWaterContent);
            Controls.Add(lblOilProductWaterContent);
            Controls.Add(cbxUnitFlash);
            Controls.Add(lblUnitFlash);
            Controls.Add(txtOilProductFlashPoint);
            Controls.Add(lblOilProductFlashPoint);
            Controls.Add(cbxUnitViscosity);
            Controls.Add(lblUnitViscosity);
            Controls.Add(txtOilProductViscosity);
            Controls.Add(lblOilProductViscosity);
            Controls.Add(cbxUnitSulfur);
            Controls.Add(lblUnitSulfur);
            Controls.Add(txtOilProductSulfurContent);
            Controls.Add(lblOilProductSulfurContent);
            Controls.Add(cbxUnitDensity);
            Controls.Add(lblUnitDensity);
            Controls.Add(txtOilProductDensity);
            Controls.Add(lblOilProductDensity);
            Controls.Add(cbxUnitVolume);
            Controls.Add(lblUnitVolume);
            Controls.Add(txtSampleVolume);
            Controls.Add(lblSampleVolume);
            Controls.Add(cbxEmployee);
            Controls.Add(lblEmployee);
            Controls.Add(cbxOilProduct);
            Controls.Add(lblOilProduct);
            Controls.Add(lblTitle);
            Name = "LaboratoryAnalysisEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Добавление лабораторного анализа";
            Load += LaboratoryAnalysisEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblOilProduct;
        private ComboBox cbxOilProduct;
        private Label lblEmployee;
        private ComboBox cbxEmployee;
        private Label lblSampleVolume;
        private TextBox txtSampleVolume;
        private Label lblUnitVolume;
        private ComboBox cbxUnitVolume;
        private Label lblOilProductDensity;
        private TextBox txtOilProductDensity;
        private Label lblUnitDensity;
        private ComboBox cbxUnitDensity;
        private Label lblOilProductSulfurContent;
        private TextBox txtOilProductSulfurContent;
        private Label lblUnitSulfur;
        private ComboBox cbxUnitSulfur;
        private Label lblOilProductViscosity;
        private TextBox txtOilProductViscosity;
        private Label lblUnitViscosity;
        private ComboBox cbxUnitViscosity;
        private Label lblOilProductFlashPoint;
        private TextBox txtOilProductFlashPoint;
        private Label lblUnitFlash;
        private ComboBox cbxUnitFlash;
        private Label lblOilProductWaterContent;
        private TextBox txtOilProductWaterContent;
        private Label lblUnitWater;
        private ComboBox cbxUnitWater;
        private Label lblDateTimeAnalysis;
        private DateTimePicker dtpDateTimeAnalysis;
        private Button btnSave;
        private Button btnCancel;
    }
}
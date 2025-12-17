namespace Oil
{
    partial class OilLotEditForm
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
            lblLotNumber = new Label();
            txtLotNumber = new TextBox();
            lblExtractionDate = new Label();
            dtpExtractionDate = new DateTimePicker();
            lblOilfield = new Label();
            cbxOilfield = new ComboBox();
            lblColor = new Label();
            cbxColor = new ComboBox();
            lblFraction = new Label();
            cbxFraction = new ComboBox();
            lblDensity = new Label();
            cbxDensity = new ComboBox();
            lblViscosity = new Label();
            cbxViscosity = new ComboBox();
            lblSulfurContent = new Label();
            cbxSulfurContent = new ComboBox();
            lblResinContent = new Label();
            cbxResinContent = new ComboBox();
            lblParaffinContent = new Label();
            cbxParaffinContent = new ComboBox();
            lblFlashPoint = new Label();
            cbxFlashPoint = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(334, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(454, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Партия нефти";
            // 
            // lblLotNumber
            // 
            lblLotNumber.AutoSize = true;
            lblLotNumber.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblLotNumber.Location = new Point(60, 140);
            lblLotNumber.Name = "lblLotNumber";
            lblLotNumber.Size = new Size(178, 29);
            lblLotNumber.TabIndex = 1;
            lblLotNumber.Text = "Номер партии:";
            // 
            // txtLotNumber
            // 
            txtLotNumber.Font = new Font("Arial", 12F);
            txtLotNumber.Location = new Point(266, 140);
            txtLotNumber.Name = "txtLotNumber";
            txtLotNumber.Size = new Size(220, 30);
            txtLotNumber.TabIndex = 1;
            // 
            // lblExtractionDate
            // 
            lblExtractionDate.AutoSize = true;
            lblExtractionDate.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblExtractionDate.Location = new Point(550, 140);
            lblExtractionDate.Name = "lblExtractionDate";
            lblExtractionDate.Size = new Size(159, 29);
            lblExtractionDate.TabIndex = 3;
            lblExtractionDate.Text = "Дата добычи:";
            // 
            // dtpExtractionDate
            // 
            dtpExtractionDate.Font = new Font("Arial", 12F);
            dtpExtractionDate.Format = DateTimePickerFormat.Short;
            dtpExtractionDate.Location = new Point(715, 140);
            dtpExtractionDate.Name = "dtpExtractionDate";
            dtpExtractionDate.Size = new Size(350, 30);
            dtpExtractionDate.TabIndex = 2;
            // 
            // lblOilfield
            // 
            lblOilfield.AutoSize = true;
            lblOilfield.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblOilfield.Location = new Point(60, 190);
            lblOilfield.Name = "lblOilfield";
            lblOilfield.Size = new Size(198, 29);
            lblOilfield.TabIndex = 5;
            lblOilfield.Text = "Месторождение:";
            // 
            // cbxOilfield
            // 
            cbxOilfield.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxOilfield.Font = new Font("Arial", 12F);
            cbxOilfield.FormattingEnabled = true;
            cbxOilfield.Location = new Point(266, 190);
            cbxOilfield.Name = "cbxOilfield";
            cbxOilfield.Size = new Size(799, 31);
            cbxOilfield.TabIndex = 3;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblColor.Location = new Point(60, 240);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(148, 29);
            lblColor.TabIndex = 7;
            lblColor.Text = "Цвет нефти:";
            // 
            // cbxColor
            // 
            cbxColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxColor.Font = new Font("Arial", 12F);
            cbxColor.FormattingEnabled = true;
            cbxColor.Location = new Point(216, 240);
            cbxColor.Name = "cbxColor";
            cbxColor.Size = new Size(849, 31);
            cbxColor.TabIndex = 4;
            // 
            // lblFraction
            // 
            lblFraction.AutoSize = true;
            lblFraction.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFraction.Location = new Point(60, 290);
            lblFraction.Name = "lblFraction";
            lblFraction.Size = new Size(115, 29);
            lblFraction.TabIndex = 9;
            lblFraction.Text = "Фракция:";
            // 
            // cbxFraction
            // 
            cbxFraction.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFraction.Font = new Font("Arial", 12F);
            cbxFraction.FormattingEnabled = true;
            cbxFraction.Location = new Point(187, 290);
            cbxFraction.Name = "cbxFraction";
            cbxFraction.Size = new Size(878, 31);
            cbxFraction.TabIndex = 5;
            // 
            // lblDensity
            // 
            lblDensity.AutoSize = true;
            lblDensity.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblDensity.Location = new Point(60, 350);
            lblDensity.Name = "lblDensity";
            lblDensity.Size = new Size(138, 29);
            lblDensity.TabIndex = 11;
            lblDensity.Text = "Плотность:";
            // 
            // cbxDensity
            // 
            cbxDensity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxDensity.Font = new Font("Arial", 12F);
            cbxDensity.FormattingEnabled = true;
            cbxDensity.Location = new Point(206, 350);
            cbxDensity.Name = "cbxDensity";
            cbxDensity.Size = new Size(300, 31);
            cbxDensity.TabIndex = 6;
            // 
            // lblViscosity
            // 
            lblViscosity.AutoSize = true;
            lblViscosity.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblViscosity.Location = new Point(601, 350);
            lblViscosity.Name = "lblViscosity";
            lblViscosity.Size = new Size(116, 29);
            lblViscosity.TabIndex = 13;
            lblViscosity.Text = "Вязкость:";
            // 
            // cbxViscosity
            // 
            cbxViscosity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxViscosity.Font = new Font("Arial", 12F);
            cbxViscosity.FormattingEnabled = true;
            cbxViscosity.Location = new Point(738, 350);
            cbxViscosity.Name = "cbxViscosity";
            cbxViscosity.Size = new Size(327, 31);
            cbxViscosity.TabIndex = 7;
            // 
            // lblSulfurContent
            // 
            lblSulfurContent.AutoSize = true;
            lblSulfurContent.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblSulfurContent.Location = new Point(60, 410);
            lblSulfurContent.Name = "lblSulfurContent";
            lblSulfurContent.Size = new Size(212, 29);
            lblSulfurContent.TabIndex = 15;
            lblSulfurContent.Text = "Содержание серы:";
            // 
            // cbxSulfurContent
            // 
            cbxSulfurContent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSulfurContent.Font = new Font("Arial", 12F);
            cbxSulfurContent.FormattingEnabled = true;
            cbxSulfurContent.Location = new Point(288, 410);
            cbxSulfurContent.Name = "cbxSulfurContent";
            cbxSulfurContent.Size = new Size(218, 31);
            cbxSulfurContent.TabIndex = 8;
            // 
            // lblResinContent
            // 
            lblResinContent.AutoSize = true;
            lblResinContent.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblResinContent.Location = new Point(601, 410);
            lblResinContent.Name = "lblResinContent";
            lblResinContent.Size = new Size(211, 29);
            lblResinContent.TabIndex = 17;
            lblResinContent.Text = "Содержание смол:";
            // 
            // cbxResinContent
            // 
            cbxResinContent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxResinContent.Font = new Font("Arial", 12F);
            cbxResinContent.FormattingEnabled = true;
            cbxResinContent.Location = new Point(837, 410);
            cbxResinContent.Name = "cbxResinContent";
            cbxResinContent.Size = new Size(228, 31);
            cbxResinContent.TabIndex = 9;
            // 
            // lblParaffinContent
            // 
            lblParaffinContent.AutoSize = true;
            lblParaffinContent.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblParaffinContent.Location = new Point(60, 470);
            lblParaffinContent.Name = "lblParaffinContent";
            lblParaffinContent.Size = new Size(268, 29);
            lblParaffinContent.TabIndex = 19;
            lblParaffinContent.Text = "Содержание парафина:";
            // 
            // cbxParaffinContent
            // 
            cbxParaffinContent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxParaffinContent.Font = new Font("Arial", 12F);
            cbxParaffinContent.FormattingEnabled = true;
            cbxParaffinContent.Location = new Point(334, 468);
            cbxParaffinContent.Name = "cbxParaffinContent";
            cbxParaffinContent.Size = new Size(172, 31);
            cbxParaffinContent.TabIndex = 10;
            // 
            // lblFlashPoint
            // 
            lblFlashPoint.AutoSize = true;
            lblFlashPoint.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFlashPoint.Location = new Point(601, 470);
            lblFlashPoint.Name = "lblFlashPoint";
            lblFlashPoint.Size = new Size(265, 29);
            lblFlashPoint.TabIndex = 21;
            lblFlashPoint.Text = "Температура вспышки:";
            // 
            // cbxFlashPoint
            // 
            cbxFlashPoint.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFlashPoint.Font = new Font("Arial", 12F);
            cbxFlashPoint.FormattingEnabled = true;
            cbxFlashPoint.Location = new Point(892, 470);
            cbxFlashPoint.Name = "cbxFlashPoint";
            cbxFlashPoint.Size = new Size(173, 31);
            cbxFlashPoint.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Constantia", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(395, 547);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 55);
            btnSave.TabIndex = 12;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(585, 547);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 55);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // OilLotEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 630);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbxFlashPoint);
            Controls.Add(lblFlashPoint);
            Controls.Add(cbxParaffinContent);
            Controls.Add(lblParaffinContent);
            Controls.Add(cbxResinContent);
            Controls.Add(lblResinContent);
            Controls.Add(cbxSulfurContent);
            Controls.Add(lblSulfurContent);
            Controls.Add(cbxViscosity);
            Controls.Add(lblViscosity);
            Controls.Add(cbxDensity);
            Controls.Add(lblDensity);
            Controls.Add(cbxFraction);
            Controls.Add(lblFraction);
            Controls.Add(cbxColor);
            Controls.Add(lblColor);
            Controls.Add(cbxOilfield);
            Controls.Add(lblOilfield);
            Controls.Add(dtpExtractionDate);
            Controls.Add(lblExtractionDate);
            Controls.Add(txtLotNumber);
            Controls.Add(lblLotNumber);
            Controls.Add(lblTitle);
            Name = "OilLotEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Редактирование партии нефти";
            Load += OilLotEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblLotNumber;
        private TextBox txtLotNumber;
        private Label lblExtractionDate;
        private DateTimePicker dtpExtractionDate;
        private Label lblOilfield;
        private ComboBox cbxOilfield;
        private Label lblColor;
        private ComboBox cbxColor;
        private Label lblFraction;
        private ComboBox cbxFraction;
        private Label lblDensity;
        private ComboBox cbxDensity;
        private Label lblViscosity;
        private ComboBox cbxViscosity;
        private Label lblSulfurContent;
        private ComboBox cbxSulfurContent;
        private Label lblResinContent;
        private ComboBox cbxResinContent;
        private Label lblParaffinContent;
        private ComboBox cbxParaffinContent;
        private Label lblFlashPoint;
        private ComboBox cbxFlashPoint;
        private Button btnSave;
        private Button btnCancel;
    }
}
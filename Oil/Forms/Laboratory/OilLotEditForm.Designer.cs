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
            lblTitle.Font = new Font("Constantia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(275, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(378, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Добавить партию нефти";
            // 
            // lblLotNumber
            // 
            lblLotNumber.AutoSize = true;
            lblLotNumber.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblLotNumber.Location = new Point(37, 72);
            lblLotNumber.Name = "lblLotNumber";
            lblLotNumber.Size = new Size(126, 21);
            lblLotNumber.TabIndex = 1;
            lblLotNumber.Text = "Номер партии:";
            // 
            // txtLotNumber
            // 
            txtLotNumber.Font = new Font("Arial", 10F);
            txtLotNumber.Location = new Point(225, 72);
            txtLotNumber.Name = "txtLotNumber";
            txtLotNumber.Size = new Size(200, 27);
            txtLotNumber.TabIndex = 1;
            // 
            // lblExtractionDate
            // 
            lblExtractionDate.AutoSize = true;
            lblExtractionDate.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblExtractionDate.Location = new Point(445, 74);
            lblExtractionDate.Name = "lblExtractionDate";
            lblExtractionDate.Size = new Size(111, 21);
            lblExtractionDate.TabIndex = 3;
            lblExtractionDate.Text = "Дата добычи:";
            // 
            // dtpExtractionDate
            // 
            dtpExtractionDate.Font = new Font("Arial", 10F);
            dtpExtractionDate.Format = DateTimePickerFormat.Short;
            dtpExtractionDate.Location = new Point(575, 72);
            dtpExtractionDate.Name = "dtpExtractionDate";
            dtpExtractionDate.Size = new Size(200, 27);
            dtpExtractionDate.TabIndex = 2;
            // 
            // lblOilfield
            // 
            lblOilfield.AutoSize = true;
            lblOilfield.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblOilfield.Location = new Point(37, 122);
            lblOilfield.Name = "lblOilfield";
            lblOilfield.Size = new Size(138, 21);
            lblOilfield.TabIndex = 5;
            lblOilfield.Text = "Месторождение:";
            // 
            // cbxOilfield
            // 
            cbxOilfield.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxOilfield.Font = new Font("Arial", 10F);
            cbxOilfield.FormattingEnabled = true;
            cbxOilfield.Location = new Point(225, 122);
            cbxOilfield.Name = "cbxOilfield";
            cbxOilfield.Size = new Size(550, 27);
            cbxOilfield.TabIndex = 3;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblColor.Location = new Point(37, 172);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(103, 21);
            lblColor.TabIndex = 7;
            lblColor.Text = "Цвет нефти:";
            // 
            // cbxColor
            // 
            cbxColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxColor.Font = new Font("Arial", 10F);
            cbxColor.FormattingEnabled = true;
            cbxColor.Location = new Point(225, 172);
            cbxColor.Name = "cbxColor";
            cbxColor.Size = new Size(550, 27);
            cbxColor.TabIndex = 4;
            // 
            // lblFraction
            // 
            lblFraction.AutoSize = true;
            lblFraction.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFraction.Location = new Point(37, 222);
            lblFraction.Name = "lblFraction";
            lblFraction.Size = new Size(82, 21);
            lblFraction.TabIndex = 9;
            lblFraction.Text = "Фракция:";
            // 
            // cbxFraction
            // 
            cbxFraction.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFraction.Font = new Font("Arial", 10F);
            cbxFraction.FormattingEnabled = true;
            cbxFraction.Location = new Point(225, 222);
            cbxFraction.Name = "cbxFraction";
            cbxFraction.Size = new Size(550, 27);
            cbxFraction.TabIndex = 5;
            // 
            // lblDensity
            // 
            lblDensity.AutoSize = true;
            lblDensity.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblDensity.Location = new Point(37, 274);
            lblDensity.Name = "lblDensity";
            lblDensity.Size = new Size(96, 21);
            lblDensity.TabIndex = 11;
            lblDensity.Text = "Плотность:";
            // 
            // cbxDensity
            // 
            cbxDensity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxDensity.Font = new Font("Arial", 10F);
            cbxDensity.FormattingEnabled = true;
            cbxDensity.Location = new Point(225, 272);
            cbxDensity.Name = "cbxDensity";
            cbxDensity.Size = new Size(250, 27);
            cbxDensity.TabIndex = 6;
            // 
            // lblViscosity
            // 
            lblViscosity.AutoSize = true;
            lblViscosity.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblViscosity.Location = new Point(503, 274);
            lblViscosity.Name = "lblViscosity";
            lblViscosity.Size = new Size(83, 21);
            lblViscosity.TabIndex = 13;
            lblViscosity.Text = "Вязкость:";
            // 
            // cbxViscosity
            // 
            cbxViscosity.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxViscosity.Font = new Font("Arial", 10F);
            cbxViscosity.FormattingEnabled = true;
            cbxViscosity.Location = new Point(605, 272);
            cbxViscosity.Name = "cbxViscosity";
            cbxViscosity.Size = new Size(170, 27);
            cbxViscosity.TabIndex = 7;
            // 
            // lblSulfurContent
            // 
            lblSulfurContent.AutoSize = true;
            lblSulfurContent.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblSulfurContent.Location = new Point(37, 322);
            lblSulfurContent.Name = "lblSulfurContent";
            lblSulfurContent.Size = new Size(151, 21);
            lblSulfurContent.TabIndex = 15;
            lblSulfurContent.Text = "Содержание серы:";
            // 
            // cbxSulfurContent
            // 
            cbxSulfurContent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSulfurContent.Font = new Font("Arial", 10F);
            cbxSulfurContent.FormattingEnabled = true;
            cbxSulfurContent.Location = new Point(225, 322);
            cbxSulfurContent.Name = "cbxSulfurContent";
            cbxSulfurContent.Size = new Size(250, 27);
            cbxSulfurContent.TabIndex = 8;
            // 
            // lblResinContent
            // 
            lblResinContent.AutoSize = true;
            lblResinContent.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblResinContent.Location = new Point(503, 324);
            lblResinContent.Name = "lblResinContent";
            lblResinContent.Size = new Size(150, 21);
            lblResinContent.TabIndex = 17;
            lblResinContent.Text = "Содержание смол:";
            // 
            // cbxResinContent
            // 
            cbxResinContent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxResinContent.Font = new Font("Arial", 10F);
            cbxResinContent.FormattingEnabled = true;
            cbxResinContent.Location = new Point(659, 322);
            cbxResinContent.Name = "cbxResinContent";
            cbxResinContent.Size = new Size(116, 27);
            cbxResinContent.TabIndex = 9;
            // 
            // lblParaffinContent
            // 
            lblParaffinContent.AutoSize = true;
            lblParaffinContent.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblParaffinContent.Location = new Point(37, 372);
            lblParaffinContent.Name = "lblParaffinContent";
            lblParaffinContent.Size = new Size(189, 21);
            lblParaffinContent.TabIndex = 19;
            lblParaffinContent.Text = "Содержание парафина:";
            // 
            // cbxParaffinContent
            // 
            cbxParaffinContent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxParaffinContent.Font = new Font("Arial", 10F);
            cbxParaffinContent.FormattingEnabled = true;
            cbxParaffinContent.Location = new Point(225, 372);
            cbxParaffinContent.Name = "cbxParaffinContent";
            cbxParaffinContent.Size = new Size(250, 27);
            cbxParaffinContent.TabIndex = 10;
            // 
            // lblFlashPoint
            // 
            lblFlashPoint.AutoSize = true;
            lblFlashPoint.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFlashPoint.Location = new Point(503, 374);
            lblFlashPoint.Name = "lblFlashPoint";
            lblFlashPoint.Size = new Size(188, 21);
            lblFlashPoint.TabIndex = 21;
            lblFlashPoint.Text = "Температура вспышки:";
            // 
            // cbxFlashPoint
            // 
            cbxFlashPoint.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFlashPoint.Font = new Font("Arial", 10F);
            cbxFlashPoint.FormattingEnabled = true;
            cbxFlashPoint.Location = new Point(695, 372);
            cbxFlashPoint.Name = "cbxFlashPoint";
            cbxFlashPoint.Size = new Size(80, 27);
            cbxFlashPoint.TabIndex = 11;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SeaGreen;
            btnSave.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(525, 424);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 45);
            btnSave.TabIndex = 12;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(655, 424);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 45);
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
            ClientSize = new Size(822, 500);
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
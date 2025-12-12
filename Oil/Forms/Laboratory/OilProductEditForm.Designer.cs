namespace Oil.Forms.Laboratory
{
    partial class OilProductEditForm
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
            cbxProductName = new ComboBox();
            lblMark = new Label();
            cbxMark = new ComboBox();
            lblApplication = new Label();
            cbxApplication = new ComboBox();
            lblClassOfDanger = new Label();
            cbxClassOfDanger = new ComboBox();
            lblFraction = new Label();
            cbxFraction = new ComboBox();
            lblManufactureDate = new Label();
            dtpManufactureDate = new DateTimePicker();
            lblExpirationDate = new Label();
            dtpExpirationDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(250, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 36);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Добавить нефтепродукт";
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblProductName.Location = new Point(50, 80);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(140, 21);
            lblProductName.TabIndex = 1;
            lblProductName.Text = "Наименование:";
            // 
            // cbxProductName
            // 
            cbxProductName.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxProductName.Font = new Font("Arial", 10F);
            cbxProductName.FormattingEnabled = true;
            cbxProductName.Location = new Point(200, 78);
            cbxProductName.Name = "cbxProductName";
            cbxProductName.Size = new Size(550, 27);
            cbxProductName.TabIndex = 1;
            // 
            // lblMark
            // 
            lblMark.AutoSize = true;
            lblMark.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblMark.Location = new Point(50, 130);
            lblMark.Name = "lblMark";
            lblMark.Size = new Size(70, 21);
            lblMark.TabIndex = 3;
            lblMark.Text = "Марка:";
            // 
            // cbxMark
            // 
            cbxMark.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMark.Font = new Font("Arial", 10F);
            cbxMark.FormattingEnabled = true;
            cbxMark.Location = new Point(200, 128);
            cbxMark.Name = "cbxMark";
            cbxMark.Size = new Size(550, 27);
            cbxMark.TabIndex = 2;
            // 
            // lblApplication
            // 
            lblApplication.AutoSize = true;
            lblApplication.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblApplication.Location = new Point(50, 180);
            lblApplication.Name = "lblApplication";
            lblApplication.Size = new Size(110, 21);
            lblApplication.TabIndex = 5;
            lblApplication.Text = "Применение:";
            // 
            // cbxApplication
            // 
            cbxApplication.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxApplication.Font = new Font("Arial", 10F);
            cbxApplication.FormattingEnabled = true;
            cbxApplication.Location = new Point(200, 178);
            cbxApplication.Name = "cbxApplication";
            cbxApplication.Size = new Size(550, 27);
            cbxApplication.TabIndex = 3;
            // 
            // lblClassOfDanger
            // 
            lblClassOfDanger.AutoSize = true;
            lblClassOfDanger.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblClassOfDanger.Location = new Point(50, 230);
            lblClassOfDanger.Name = "lblClassOfDanger";
            lblClassOfDanger.Size = new Size(150, 21);
            lblClassOfDanger.TabIndex = 7;
            lblClassOfDanger.Text = "Класс опасности:";
            // 
            // cbxClassOfDanger
            // 
            cbxClassOfDanger.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxClassOfDanger.Font = new Font("Arial", 10F);
            cbxClassOfDanger.FormattingEnabled = true;
            cbxClassOfDanger.Location = new Point(200, 228);
            cbxClassOfDanger.Name = "cbxClassOfDanger";
            cbxClassOfDanger.Size = new Size(550, 27);
            cbxClassOfDanger.TabIndex = 4;
            // 
            // lblFraction
            // 
            lblFraction.AutoSize = true;
            lblFraction.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFraction.Location = new Point(50, 280);
            lblFraction.Name = "lblFraction";
            lblFraction.Size = new Size(80, 21);
            lblFraction.TabIndex = 9;
            lblFraction.Text = "Фракция:";
            // 
            // cbxFraction
            // 
            cbxFraction.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFraction.Font = new Font("Arial", 10F);
            cbxFraction.FormattingEnabled = true;
            cbxFraction.Location = new Point(200, 278);
            cbxFraction.Name = "cbxFraction";
            cbxFraction.Size = new Size(550, 27);
            cbxFraction.TabIndex = 5;
            // 
            // lblManufactureDate
            // 
            lblManufactureDate.AutoSize = true;
            lblManufactureDate.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblManufactureDate.Location = new Point(50, 330);
            lblManufactureDate.Name = "lblManufactureDate";
            lblManufactureDate.Size = new Size(170, 21);
            lblManufactureDate.TabIndex = 11;
            lblManufactureDate.Text = "Дата производства:";
            // 
            // dtpManufactureDate
            // 
            dtpManufactureDate.Font = new Font("Arial", 10F);
            dtpManufactureDate.Format = DateTimePickerFormat.Short;
            dtpManufactureDate.Location = new Point(230, 328);
            dtpManufactureDate.Name = "dtpManufactureDate";
            dtpManufactureDate.Size = new Size(200, 27);
            dtpManufactureDate.TabIndex = 6;
            // 
            // lblExpirationDate
            // 
            lblExpirationDate.AutoSize = true;
            lblExpirationDate.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblExpirationDate.Location = new Point(450, 330);
            lblExpirationDate.Name = "lblExpirationDate";
            lblExpirationDate.Size = new Size(140, 21);
            lblExpirationDate.TabIndex = 13;
            lblExpirationDate.Text = "Срок годности:";
            // 
            // dtpExpirationDate
            // 
            dtpExpirationDate.Font = new Font("Arial", 10F);
            dtpExpirationDate.Format = DateTimePickerFormat.Short;
            dtpExpirationDate.Location = new Point(600, 328);
            dtpExpirationDate.Name = "dtpExpirationDate";
            dtpExpirationDate.Size = new Size(150, 27);
            dtpExpirationDate.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SeaGreen;
            btnSave.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(500, 400);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 45);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(630, 400);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 45);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // OilProductEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 470);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpExpirationDate);
            Controls.Add(lblExpirationDate);
            Controls.Add(dtpManufactureDate);
            Controls.Add(lblManufactureDate);
            Controls.Add(cbxFraction);
            Controls.Add(lblFraction);
            Controls.Add(cbxClassOfDanger);
            Controls.Add(lblClassOfDanger);
            Controls.Add(cbxApplication);
            Controls.Add(lblApplication);
            Controls.Add(cbxMark);
            Controls.Add(lblMark);
            Controls.Add(cbxProductName);
            Controls.Add(lblProductName);
            Controls.Add(lblTitle);
            Name = "OilProductEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Добавление нефтепродукта";
            Load += OilProductEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblProductName;
        private ComboBox cbxProductName;
        private Label lblMark;
        private ComboBox cbxMark;
        private Label lblApplication;
        private ComboBox cbxApplication;
        private Label lblClassOfDanger;
        private ComboBox cbxClassOfDanger;
        private Label lblFraction;
        private ComboBox cbxFraction;
        private Label lblManufactureDate;
        private DateTimePicker dtpManufactureDate;
        private Label lblExpirationDate;
        private DateTimePicker dtpExpirationDate;
        private Button btnSave;
        private Button btnCancel;
    }
}
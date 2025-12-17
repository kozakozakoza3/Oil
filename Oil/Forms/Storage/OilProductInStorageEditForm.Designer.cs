namespace Oil
{
    partial class OilProductInStorageEditForm
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
            lblProduct = new Label();
            lblFormationDate = new Label();
            lblSize = new Label();
            lblUnit = new Label();
            txtSize = new TextBox();
            txtUnit = new TextBox();
            cbProduct = new ComboBox();
            dtpFormationDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(200, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(750, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Партия нефтепродукта";
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblProduct.Location = new Point(60, 140);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(116, 29);
            lblProduct.TabIndex = 1;
            lblProduct.Text = "Продукт:";
            // 
            // lblFormationDate
            // 
            lblFormationDate.AutoSize = true;
            lblFormationDate.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFormationDate.Location = new Point(60, 190);
            lblFormationDate.Name = "lblFormationDate";
            lblFormationDate.Size = new Size(240, 29);
            lblFormationDate.TabIndex = 2;
            lblFormationDate.Text = "Дата формирования:";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblSize.Location = new Point(60, 240);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(99, 29);
            lblSize.TabIndex = 3;
            lblSize.Text = "Объем:";
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUnit.Location = new Point(550, 240);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(198, 29);
            lblUnit.TabIndex = 4;
            lblUnit.Text = "Ед. измерения:";
            // 
            // txtSize
            // 
            txtSize.Font = new Font("Arial", 12F);
            txtSize.Location = new Point(165, 240);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(250, 30);
            txtSize.TabIndex = 3;
            // 
            // txtUnit
            // 
            txtUnit.Font = new Font("Arial", 12F);
            txtUnit.Location = new Point(754, 240);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(266, 30);
            txtUnit.TabIndex = 4;
            txtUnit.Text = "м³";
            // 
            // cbProduct
            // 
            cbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProduct.Font = new Font("Arial", 12F);
            cbProduct.FormattingEnabled = true;
            cbProduct.Location = new Point(182, 140);
            cbProduct.Name = "cbProduct";
            cbProduct.Size = new Size(838, 31);
            cbProduct.TabIndex = 1;
            // 
            // dtpFormationDate
            // 
            dtpFormationDate.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpFormationDate.Font = new Font("Arial", 12F);
            dtpFormationDate.Format = DateTimePickerFormat.Custom;
            dtpFormationDate.Location = new Point(306, 190);
            dtpFormationDate.Name = "dtpFormationDate";
            dtpFormationDate.Size = new Size(714, 30);
            dtpFormationDate.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Constantia", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(395, 320);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 55);
            btnSave.TabIndex = 5;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(585, 320);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 55);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // OilProductInStorageEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 400);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpFormationDate);
            Controls.Add(cbProduct);
            Controls.Add(txtUnit);
            Controls.Add(txtSize);
            Controls.Add(lblUnit);
            Controls.Add(lblSize);
            Controls.Add(lblFormationDate);
            Controls.Add(lblProduct);
            Controls.Add(lblTitle);
            Name = "OilProductInStorageEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Партия нефтепродукта";
            Load += OilProductInStorageEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblProduct;
        private Label lblFormationDate;
        private Label lblSize;
        private Label lblUnit;
        private TextBox txtSize;
        private TextBox txtUnit;
        private ComboBox cbProduct;
        private DateTimePicker dtpFormationDate;
        private Button btnSave;
        private Button btnCancel;
    }
}
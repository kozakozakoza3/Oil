namespace Oil
{
    partial class OilProductInStorageEditForm
    {
        private System.ComponentModel.IContainer components = null;
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

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

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
            lblTitle.Font = new Font("Constantia", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(117, 43);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(531, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Партия нефтепродукта";
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Constantia", 12F);
            lblProduct.Location = new Point(75, 143);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(93, 24);
            lblProduct.TabIndex = 1;
            lblProduct.Text = "Продукт:";
            // 
            // lblFormationDate
            // 
            lblFormationDate.AutoSize = true;
            lblFormationDate.Font = new Font("Constantia", 12F);
            lblFormationDate.Location = new Point(75, 192);
            lblFormationDate.Name = "lblFormationDate";
            lblFormationDate.Size = new Size(202, 24);
            lblFormationDate.TabIndex = 2;
            lblFormationDate.Text = "Дата формирования:";
            // 
            // lblSize
            // 
            lblSize.AutoSize = true;
            lblSize.Font = new Font("Constantia", 12F);
            lblSize.Location = new Point(75, 246);
            lblSize.Name = "lblSize";
            lblSize.Size = new Size(78, 24);
            lblSize.TabIndex = 3;
            lblSize.Text = "Объем:";
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.Font = new Font("Constantia", 12F);
            lblUnit.Location = new Point(374, 242);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(148, 24);
            lblUnit.TabIndex = 4;
            lblUnit.Text = "Ед. измерения:";
            // 
            // txtSize
            // 
            txtSize.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtSize.Location = new Point(164, 242);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(160, 28);
            txtSize.TabIndex = 5;
            // 
            // txtUnit
            // 
            txtUnit.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtUnit.Location = new Point(539, 238);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(136, 28);
            txtUnit.TabIndex = 6;
            txtUnit.Text = "м³";
            // 
            // cbProduct
            // 
            cbProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProduct.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cbProduct.FormattingEnabled = true;
            cbProduct.Location = new Point(174, 138);
            cbProduct.Name = "cbProduct";
            cbProduct.Size = new Size(501, 29);
            cbProduct.TabIndex = 7;
            // 
            // dtpFormationDate
            // 
            dtpFormationDate.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpFormationDate.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dtpFormationDate.Format = DateTimePickerFormat.Custom;
            dtpFormationDate.Location = new Point(283, 189);
            dtpFormationDate.Name = "dtpFormationDate";
            dtpFormationDate.Size = new Size(392, 28);
            dtpFormationDate.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SeaGreen;
            btnSave.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(201, 329);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 45);
            btnSave.TabIndex = 9;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(383, 329);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 45);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // OilProductInStorageEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(744, 410);
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
    }
}
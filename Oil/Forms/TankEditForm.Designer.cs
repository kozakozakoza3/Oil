namespace Oil
{
    partial class TankEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtCapacity;
        private TextBox txtUnit;
        private ComboBox cbMaterial;
        private ComboBox cbProduct;
        private ComboBox cbStorage;
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtCapacity = new TextBox();
            txtUnit = new TextBox();
            cbMaterial = new ComboBox();
            cbProduct = new ComboBox();
            cbStorage = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();

            // label1 (Емкость)
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 0;
            label1.Text = "Емкость:";

            // label2 (Ед. измерения)
            label2.AutoSize = true;
            label2.Location = new Point(200, 30);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 1;
            label2.Text = "Ед. измерения:";

            // label3 (Материал)
            label3.AutoSize = true;
            label3.Location = new Point(30, 70);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 2;
            label3.Text = "Материал:";

            // label4 (Продукт)
            label4.AutoSize = true;
            label4.Location = new Point(30, 110);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 3;
            label4.Text = "Продукт:";

            // label5 (Хранилище)
            label5.AutoSize = true;
            label5.Location = new Point(30, 150);
            label5.Name = "label5";
            label5.Size = new Size(75, 15);
            label5.TabIndex = 4;
            label5.Text = "Хранилище:";

            // txtCapacity
            txtCapacity.Location = new Point(110, 27);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(80, 23);
            txtCapacity.TabIndex = 5;

            // txtUnit
            txtUnit.Location = new Point(300, 27);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(80, 23);
            txtUnit.TabIndex = 6;
            txtUnit.Text = "м³";

            // cbMaterial
            cbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaterial.FormattingEnabled = true;
            cbMaterial.Location = new Point(110, 67);
            cbMaterial.Name = "cbMaterial";
            cbMaterial.Size = new Size(270, 23);
            cbMaterial.TabIndex = 7;

            // cbProduct
            cbMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProduct.FormattingEnabled = true;
            cbProduct.Location = new Point(110, 107);
            cbProduct.Name = "cbProduct";
            cbProduct.Size = new Size(270, 23);
            cbProduct.TabIndex = 8;

            // cbStorage
            cbStorage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStorage.FormattingEnabled = true;
            cbStorage.Location = new Point(110, 147);
            cbStorage.Name = "cbStorage";
            cbStorage.Size = new Size(270, 23);
            cbStorage.TabIndex = 9;

            // btnSave
            btnSave.Location = new Point(110, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 10;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // btnCancel
            btnCancel.Location = new Point(220, 200);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // TankEditForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 250);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbStorage);
            Controls.Add(cbProduct);
            Controls.Add(cbMaterial);
            Controls.Add(txtUnit);
            Controls.Add(txtCapacity);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TankEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Резервуар";
            Load += TankEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
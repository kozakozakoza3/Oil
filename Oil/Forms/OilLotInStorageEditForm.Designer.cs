namespace Oil
{
    partial class OilLotInStorageEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtSize;
        private TextBox txtUnit;
        private ComboBox cbOilLot;
        private ComboBox cbTank;
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
            txtSize = new TextBox();
            txtUnit = new TextBox();
            cbOilLot = new ComboBox();
            cbTank = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();

            // label1 (Партия нефти)
            label1.AutoSize = true;
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(80, 15);
            label1.TabIndex = 0;
            label1.Text = "Партия нефти:";

            // label2 (Резервуар)
            label2.AutoSize = true;
            label2.Location = new Point(30, 70);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "Резервуар:";

            // label3 (Объем)
            label3.AutoSize = true;
            label3.Location = new Point(30, 110);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 2;
            label3.Text = "Объем:";

            // label4 (Ед. измерения)
            label4.AutoSize = true;
            label4.Location = new Point(200, 110);
            label4.Name = "label4";
            label4.Size = new Size(90, 15);
            label4.TabIndex = 3;
            label4.Text = "Ед. измерения:";

            // txtSize
            txtSize.Location = new Point(120, 107);
            txtSize.Name = "txtSize";
            txtSize.Size = new Size(70, 23);
            txtSize.TabIndex = 4;

            // txtUnit
            txtUnit.Location = new Point(300, 107);
            txtUnit.Name = "txtUnit";
            txtUnit.Size = new Size(80, 23);
            txtUnit.TabIndex = 5;
            txtUnit.Text = "м³";

            // cbOilLot
            cbOilLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOilLot.FormattingEnabled = true;
            cbOilLot.Location = new Point(120, 27);
            cbOilLot.Name = "cbOilLot";
            cbOilLot.Size = new Size(260, 23);
            cbOilLot.TabIndex = 6;

            // cbTank
            cbTank.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTank.FormattingEnabled = true;
            cbTank.Location = new Point(120, 67);
            cbTank.Name = "cbTank";
            cbTank.Size = new Size(260, 23);
            cbTank.TabIndex = 7;

            // btnSave
            btnSave.Location = new Point(120, 160);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // btnCancel
            btnCancel.Location = new Point(230, 160);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 30);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;

            // OilLotInStorageEditForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 210);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbTank);
            Controls.Add(cbOilLot);
            Controls.Add(txtUnit);
            Controls.Add(txtSize);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "OilLotInStorageEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Партия нефти на складе";
            Load += OilLotInStorageEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
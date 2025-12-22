namespace Oil
{
    partial class OilLotInStorageEditForm
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
            lblOilLot = new Label();
            lblTank = new Label();
            lblLotSize = new Label();
            lblUnitMeasure = new Label();
            cbxOilLot = new ComboBox();
            cbxTank = new ComboBox();
            txtLotSize = new TextBox();
            txtUnitMeasure = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.WhiteSmoke;
            lblTitle.Font = new Font("Constantia", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(245, 83);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(660, 58);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Партия нефти в резервуаре";
            // 
            // lblOilLot
            // 
            lblOilLot.AutoSize = true;
            lblOilLot.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblOilLot.Location = new Point(83, 187);
            lblOilLot.Name = "lblOilLot";
            lblOilLot.Size = new Size(177, 29);
            lblOilLot.TabIndex = 1;
            lblOilLot.Text = "Партия нефти:";
            // 
            // lblTank
            // 
            lblTank.AutoSize = true;
            lblTank.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTank.Location = new Point(83, 251);
            lblTank.Name = "lblTank";
            lblTank.Size = new Size(129, 29);
            lblTank.TabIndex = 2;
            lblTank.Text = "Резервуар:";
            // 
            // lblLotSize
            // 
            lblLotSize.AutoSize = true;
            lblLotSize.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblLotSize.Location = new Point(83, 317);
            lblLotSize.Name = "lblLotSize";
            lblLotSize.Size = new Size(180, 29);
            lblLotSize.TabIndex = 3;
            lblLotSize.Text = "Объем партии:";
            // 
            // lblUnitMeasure
            // 
            lblUnitMeasure.AutoSize = true;
            lblUnitMeasure.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUnitMeasure.Location = new Point(573, 317);
            lblUnitMeasure.Name = "lblUnitMeasure";
            lblUnitMeasure.Size = new Size(178, 29);
            lblUnitMeasure.TabIndex = 4;
            lblUnitMeasure.Text = "Ед. измерения:";
            // 
            // cbxOilLot
            // 
            cbxOilLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxOilLot.Font = new Font("Arial", 12F);
            cbxOilLot.FormattingEnabled = true;
            cbxOilLot.Location = new Point(259, 187);
            cbxOilLot.Name = "cbxOilLot";
            cbxOilLot.Size = new Size(784, 31);
            cbxOilLot.TabIndex = 1;
            // 
            // cbxTank
            // 
            cbxTank.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTank.Font = new Font("Arial", 12F);
            cbxTank.FormattingEnabled = true;
            cbxTank.Location = new Point(227, 251);
            cbxTank.Name = "cbxTank";
            cbxTank.Size = new Size(816, 31);
            cbxTank.TabIndex = 2;
            // 
            // txtLotSize
            // 
            txtLotSize.Font = new Font("Arial", 12F);
            txtLotSize.Location = new Point(271, 317);
            txtLotSize.Name = "txtLotSize";
            txtLotSize.Size = new Size(250, 30);
            txtLotSize.TabIndex = 3;
            // 
            // txtUnitMeasure
            // 
            txtUnitMeasure.Font = new Font("Arial", 12F);
            txtUnitMeasure.Location = new Point(777, 317);
            txtUnitMeasure.Name = "txtUnitMeasure";
            txtUnitMeasure.Size = new Size(266, 30);
            txtUnitMeasure.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Constantia", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(418, 397);
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
            btnCancel.Location = new Point(608, 397);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 55);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // OilLotInStorageEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 550);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtUnitMeasure);
            Controls.Add(txtLotSize);
            Controls.Add(cbxTank);
            Controls.Add(cbxOilLot);
            Controls.Add(lblUnitMeasure);
            Controls.Add(lblLotSize);
            Controls.Add(lblTank);
            Controls.Add(lblOilLot);
            Controls.Add(lblTitle);
            Name = "OilLotInStorageEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Редактирование партии нефти в резервуаре";
            Load += OilLotInStorageEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblOilLot;
        private Label lblTank;
        private Label lblLotSize;
        private Label lblUnitMeasure;
        private ComboBox cbxOilLot;
        private ComboBox cbxTank;
        private TextBox txtLotSize;
        private TextBox txtUnitMeasure;
        private Button btnSave;
        private Button btnCancel;
    }
}
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
            lblTitle.Font = new Font("Constantia", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(40, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(680, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Партия нефти в резервуаре";
            // 
            // lblOilLot
            // 
            lblOilLot.AutoSize = true;
            lblOilLot.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblOilLot.Location = new Point(50, 100);
            lblOilLot.Name = "lblOilLot";
            lblOilLot.Size = new Size(130, 24);
            lblOilLot.TabIndex = 1;
            lblOilLot.Text = "Партия нефти:";
            // 
            // lblTank
            // 
            lblTank.AutoSize = true;
            lblTank.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTank.Location = new Point(50, 150);
            lblTank.Name = "lblTank";
            lblTank.Size = new Size(105, 24);
            lblTank.TabIndex = 2;
            lblTank.Text = "Резервуар:";
            // 
            // lblLotSize
            // 
            lblLotSize.AutoSize = true;
            lblLotSize.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblLotSize.Location = new Point(50, 200);
            lblLotSize.Name = "lblLotSize";
            lblLotSize.Size = new Size(150, 24);
            lblLotSize.TabIndex = 3;
            lblLotSize.Text = "Объем партии:";
            // 
            // lblUnitMeasure
            // 
            lblUnitMeasure.AutoSize = true;
            lblUnitMeasure.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblUnitMeasure.Location = new Point(400, 200);
            lblUnitMeasure.Name = "lblUnitMeasure";
            lblUnitMeasure.Size = new Size(128, 24);
            lblUnitMeasure.TabIndex = 4;
            lblUnitMeasure.Text = "Ед. измерения:";
            // 
            // cbxOilLot
            // 
            cbxOilLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxOilLot.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cbxOilLot.FormattingEnabled = true;
            cbxOilLot.Location = new Point(210, 100);
            cbxOilLot.Name = "cbxOilLot";
            cbxOilLot.Size = new Size(450, 29);
            cbxOilLot.TabIndex = 5;
            // 
            // cbxTank
            // 
            cbxTank.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTank.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cbxTank.FormattingEnabled = true;
            cbxTank.Location = new Point(210, 150);
            cbxTank.Name = "cbxTank";
            cbxTank.Size = new Size(450, 29);
            cbxTank.TabIndex = 6;
            // 
            // txtLotSize
            // 
            txtLotSize.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtLotSize.Location = new Point(210, 200);
            txtLotSize.Name = "txtLotSize";
            txtLotSize.Size = new Size(170, 28);
            txtLotSize.TabIndex = 7;
            // 
            // txtUnitMeasure
            // 
            txtUnitMeasure.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtUnitMeasure.Location = new Point(540, 200);
            txtUnitMeasure.Name = "txtUnitMeasure";
            txtUnitMeasure.Size = new Size(120, 28);
            txtUnitMeasure.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SeaGreen;
            btnSave.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(150, 280);
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
            btnCancel.Location = new Point(320, 280);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 45);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // OilLotInStorageEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(700, 350);
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
            Text = "Oil System - Партия нефти в резервуаре";
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
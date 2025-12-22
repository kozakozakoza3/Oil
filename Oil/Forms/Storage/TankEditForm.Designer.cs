namespace Oil
{
    partial class TankEditForm
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
            lblCapacity = new Label();
            lblUnitMeasure = new Label();
            lblProduct = new Label();
            lblMaterial = new Label();
            txtCapacity = new TextBox();
            txtUnitMeasure = new TextBox();
            cbxProduct = new ComboBox();
            cbxMaterial = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblStorage = new Label();
            cbxStorage = new ComboBox();
            lblStorageInfo = new Label();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(423, 77);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(331, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Резервуар";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblCapacity.Location = new Point(83, 213);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(109, 29);
            lblCapacity.TabIndex = 1;
            lblCapacity.Text = "Емкость:";
            // 
            // lblUnitMeasure
            // 
            lblUnitMeasure.AutoSize = true;
            lblUnitMeasure.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUnitMeasure.Location = new Point(573, 213);
            lblUnitMeasure.Name = "lblUnitMeasure";
            lblUnitMeasure.Size = new Size(178, 29);
            lblUnitMeasure.TabIndex = 2;
            lblUnitMeasure.Text = "Ед. измерения:";
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblProduct.Location = new Point(83, 286);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(179, 29);
            lblProduct.TabIndex = 3;
            lblProduct.Text = "Нефтепродукт:";
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblMaterial.Location = new Point(86, 407);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(129, 29);
            lblMaterial.TabIndex = 5;
            lblMaterial.Text = "Материал:";
            // 
            // txtCapacity
            // 
            txtCapacity.Font = new Font("Arial", 12F);
            txtCapacity.Location = new Point(202, 213);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(250, 30);
            txtCapacity.TabIndex = 1;
            // 
            // txtUnitMeasure
            // 
            txtUnitMeasure.Font = new Font("Arial", 12F);
            txtUnitMeasure.Location = new Point(777, 213);
            txtUnitMeasure.Name = "txtUnitMeasure";
            txtUnitMeasure.Size = new Size(266, 30);
            txtUnitMeasure.TabIndex = 2;
            // 
            // cbxProduct
            // 
            cbxProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxProduct.Font = new Font("Arial", 12F);
            cbxProduct.FormattingEnabled = true;
            cbxProduct.Location = new Point(273, 286);
            cbxProduct.Name = "cbxProduct";
            cbxProduct.Size = new Size(770, 31);
            cbxProduct.TabIndex = 3;
            // 
            // cbxMaterial
            // 
            cbxMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMaterial.Font = new Font("Arial", 12F);
            cbxMaterial.FormattingEnabled = true;
            cbxMaterial.Location = new Point(221, 407);
            cbxMaterial.Name = "cbxMaterial";
            cbxMaterial.Size = new Size(822, 31);
            cbxMaterial.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Constantia", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(384, 470);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 55);
            btnSave.TabIndex = 7;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(574, 470);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 55);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblStorage
            // 
            lblStorage.AutoSize = true;
            lblStorage.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblStorage.Location = new Point(83, 337);
            lblStorage.Name = "lblStorage";
            lblStorage.Size = new Size(86, 29);
            lblStorage.TabIndex = 9;
            lblStorage.Text = "Склад:";
            // 
            // cbxStorage
            // 
            cbxStorage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxStorage.Font = new Font("Arial", 12F);
            cbxStorage.FormattingEnabled = true;
            cbxStorage.Location = new Point(221, 337);
            cbxStorage.Name = "cbxStorage";
            cbxStorage.Size = new Size(822, 31);
            cbxStorage.TabIndex = 4;
            cbxStorage.SelectedIndexChanged += cbxStorage_SelectedIndexChanged;
            // 
            // lblStorageInfo
            // 
            lblStorageInfo.AutoSize = true;
            lblStorageInfo.Font = new Font("Arial", 10F, FontStyle.Italic, GraphicsUnit.Point, 204);
            lblStorageInfo.ForeColor = Color.DimGray;
            lblStorageInfo.Location = new Point(221, 371);
            lblStorageInfo.Name = "lblStorageInfo";
            lblStorageInfo.Size = new Size(143, 20);
            lblStorageInfo.TabIndex = 10;
            lblStorageInfo.Text = "Выберите склад";
            // 
            // TankEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 550);
            Controls.Add(lblStorageInfo);
            Controls.Add(cbxStorage);
            Controls.Add(lblStorage);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbxMaterial);
            Controls.Add(cbxProduct);
            Controls.Add(txtUnitMeasure);
            Controls.Add(txtCapacity);
            Controls.Add(lblMaterial);
            Controls.Add(lblProduct);
            Controls.Add(lblUnitMeasure);
            Controls.Add(lblCapacity);
            Controls.Add(lblTitle);
            Name = "TankEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Редактирование резервуара";
            Load += TankEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCapacity;
        private Label lblUnitMeasure;
        private Label lblProduct;
        private Label lblMaterial;
        private TextBox txtCapacity;
        private TextBox txtUnitMeasure;
        private ComboBox cbxProduct;
        private ComboBox cbxMaterial;
        private Button btnSave;
        private Button btnCancel;
        private Label lblStorage;
        private ComboBox cbxStorage;
        private Label lblStorageInfo;
    }
}
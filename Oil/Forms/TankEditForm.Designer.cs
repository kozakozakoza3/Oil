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
            lblStorage = new Label();
            lblMaterial = new Label();
            txtCapacity = new TextBox();
            txtUnitMeasure = new TextBox();
            cbxProduct = new ComboBox();
            cbxStorage = new ComboBox();
            cbxMaterial = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(120, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(290, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Резервуар";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblCapacity.Location = new Point(50, 100);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(86, 24);
            lblCapacity.TabIndex = 1;
            lblCapacity.Text = "Емкость:";
            // 
            // lblUnitMeasure
            // 
            lblUnitMeasure.AutoSize = true;
            lblUnitMeasure.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblUnitMeasure.Location = new Point(350, 100);
            lblUnitMeasure.Name = "lblUnitMeasure";
            lblUnitMeasure.Size = new Size(128, 24);
            lblUnitMeasure.TabIndex = 2;
            lblUnitMeasure.Text = "Ед. измерения:";
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblProduct.Location = new Point(50, 150);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(130, 24);
            lblProduct.TabIndex = 3;
            lblProduct.Text = "Нефтепродукт:";
            // 
            // lblStorage
            // 
            lblStorage.AutoSize = true;
            lblStorage.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblStorage.Location = new Point(50, 200);
            lblStorage.Name = "lblStorage";
            lblStorage.Size = new Size(105, 24);
            lblStorage.TabIndex = 4;
            lblStorage.Text = "Хранилище:";
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblMaterial.Location = new Point(50, 250);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(98, 24);
            lblMaterial.TabIndex = 5;
            lblMaterial.Text = "Материал:";
            // 
            // txtCapacity
            // 
            txtCapacity.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtCapacity.Location = new Point(160, 100);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(170, 28);
            txtCapacity.TabIndex = 6;
            // 
            // txtUnitMeasure
            // 
            txtUnitMeasure.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtUnitMeasure.Location = new Point(490, 100);
            txtUnitMeasure.Name = "txtUnitMeasure";
            txtUnitMeasure.Size = new Size(100, 28);
            txtUnitMeasure.TabIndex = 7;
            // 
            // cbxProduct
            // 
            cbxProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxProduct.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cbxProduct.FormattingEnabled = true;
            cbxProduct.Location = new Point(190, 150);
            cbxProduct.Name = "cbxProduct";
            cbxProduct.Size = new Size(400, 29);
            cbxProduct.TabIndex = 8;
            // 
            // cbxStorage
            // 
            cbxStorage.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxStorage.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cbxStorage.FormattingEnabled = true;
            cbxStorage.Location = new Point(190, 200);
            cbxStorage.Name = "cbxStorage";
            cbxStorage.Size = new Size(400, 29);
            cbxStorage.TabIndex = 9;
            // 
            // cbxMaterial
            // 
            cbxMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxMaterial.Font = new Font("Constantia", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            cbxMaterial.FormattingEnabled = true;
            cbxMaterial.Location = new Point(190, 250);
            cbxMaterial.Name = "cbxMaterial";
            cbxMaterial.Size = new Size(400, 29);
            cbxMaterial.TabIndex = 10;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SeaGreen;
            btnSave.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(150, 320);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 45);
            btnSave.TabIndex = 11;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(320, 320);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 45);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // TankEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(650, 400);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbxMaterial);
            Controls.Add(cbxStorage);
            Controls.Add(cbxProduct);
            Controls.Add(txtUnitMeasure);
            Controls.Add(txtCapacity);
            Controls.Add(lblMaterial);
            Controls.Add(lblStorage);
            Controls.Add(lblProduct);
            Controls.Add(lblUnitMeasure);
            Controls.Add(lblCapacity);
            Controls.Add(lblTitle);
            Name = "TankEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Резервуар";
            Load += TankEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCapacity;
        private Label lblUnitMeasure;
        private Label lblProduct;
        private Label lblStorage;
        private Label lblMaterial;
        private TextBox txtCapacity;
        private TextBox txtUnitMeasure;
        private ComboBox cbxProduct;
        private ComboBox cbxStorage;
        private ComboBox cbxMaterial;
        private Button btnSave;
        private Button btnCancel;
    }
}
namespace Oil
{
    partial class OilProductForm
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
            lblName = new Label();
            txtName = new TextBox();
            lblMark = new Label();
            txtMark = new TextBox();
            lblApplication = new Label();
            txtApplication = new TextBox();
            lblDangerClass = new Label();
            txtDangerClass = new TextBox();
            lblFraction = new Label();
            txtFraction = new TextBox();
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
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(182, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(238, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "НЕФТЕПРОДУКТ";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblName.Location = new Point(70, 80);
            lblName.Name = "lblName";
            lblName.Size = new Size(87, 19);
            lblName.TabIndex = 1;
            lblName.Text = "Название:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtName.Location = new Point(219, 72);
            txtName.Name = "txtName";
            txtName.Size = new Size(335, 27);
            txtName.TabIndex = 1;
            // 
            // lblMark
            // 
            lblMark.AutoSize = true;
            lblMark.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblMark.Location = new Point(70, 120);
            lblMark.Name = "lblMark";
            lblMark.Size = new Size(61, 19);
            lblMark.TabIndex = 3;
            lblMark.Text = "Марка:";
            // 
            // txtMark
            // 
            txtMark.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtMark.Location = new Point(219, 112);
            txtMark.Name = "txtMark";
            txtMark.Size = new Size(335, 27);
            txtMark.TabIndex = 2;
            // 
            // lblApplication
            // 
            lblApplication.AutoSize = true;
            lblApplication.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblApplication.Location = new Point(70, 160);
            lblApplication.Name = "lblApplication";
            lblApplication.Size = new Size(108, 19);
            lblApplication.TabIndex = 5;
            lblApplication.Text = "Применение:";
            // 
            // txtApplication
            // 
            txtApplication.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtApplication.Location = new Point(219, 152);
            txtApplication.Name = "txtApplication";
            txtApplication.Size = new Size(335, 27);
            txtApplication.TabIndex = 3;
            // 
            // lblDangerClass
            // 
            lblDangerClass.AutoSize = true;
            lblDangerClass.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblDangerClass.Location = new Point(70, 200);
            lblDangerClass.Name = "lblDangerClass";
            lblDangerClass.Size = new Size(146, 19);
            lblDangerClass.TabIndex = 7;
            lblDangerClass.Text = "Класс опасности:";
            // 
            // txtDangerClass
            // 
            txtDangerClass.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtDangerClass.Location = new Point(219, 192);
            txtDangerClass.Name = "txtDangerClass";
            txtDangerClass.Size = new Size(335, 27);
            txtDangerClass.TabIndex = 4;
            // 
            // lblFraction
            // 
            lblFraction.AutoSize = true;
            lblFraction.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFraction.Location = new Point(70, 240);
            lblFraction.Name = "lblFraction";
            lblFraction.Size = new Size(80, 19);
            lblFraction.TabIndex = 9;
            lblFraction.Text = "Фракция:";
            // 
            // txtFraction
            // 
            txtFraction.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtFraction.Location = new Point(219, 232);
            txtFraction.Name = "txtFraction";
            txtFraction.Size = new Size(335, 27);
            txtFraction.TabIndex = 5;
            // 
            // lblManufactureDate
            // 
            lblManufactureDate.AutoSize = true;
            lblManufactureDate.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblManufactureDate.Location = new Point(70, 280);
            lblManufactureDate.Name = "lblManufactureDate";
            lblManufactureDate.Size = new Size(103, 19);
            lblManufactureDate.TabIndex = 11;
            lblManufactureDate.Text = "Изготовлен:";
            // 
            // dtpManufactureDate
            // 
            dtpManufactureDate.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dtpManufactureDate.Location = new Point(219, 272);
            dtpManufactureDate.Name = "dtpManufactureDate";
            dtpManufactureDate.Size = new Size(335, 27);
            dtpManufactureDate.TabIndex = 6;
            // 
            // lblExpirationDate
            // 
            lblExpirationDate.AutoSize = true;
            lblExpirationDate.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblExpirationDate.Location = new Point(70, 320);
            lblExpirationDate.Name = "lblExpirationDate";
            lblExpirationDate.Size = new Size(95, 19);
            lblExpirationDate.TabIndex = 13;
            lblExpirationDate.Text = "Срок годн.:";
            // 
            // dtpExpirationDate
            // 
            dtpExpirationDate.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dtpExpirationDate.Location = new Point(219, 312);
            dtpExpirationDate.Name = "dtpExpirationDate";
            dtpExpirationDate.Size = new Size(335, 27);
            dtpExpirationDate.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SeaGreen;
            btnSave.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(160, 369);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 35);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(300, 369);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 35);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // OilProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(613, 430);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpExpirationDate);
            Controls.Add(lblExpirationDate);
            Controls.Add(dtpManufactureDate);
            Controls.Add(lblManufactureDate);
            Controls.Add(txtFraction);
            Controls.Add(lblFraction);
            Controls.Add(txtDangerClass);
            Controls.Add(lblDangerClass);
            Controls.Add(txtApplication);
            Controls.Add(lblApplication);
            Controls.Add(txtMark);
            Controls.Add(lblMark);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            Name = "OilProductForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Нефтепродукт";
            Load += OilProductForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblMark;
        private TextBox txtMark;
        private Label lblApplication;
        private TextBox txtApplication;
        private Label lblDangerClass;
        private TextBox txtDangerClass;
        private Label lblFraction;
        private TextBox txtFraction;
        private Label lblManufactureDate;
        private DateTimePicker dtpManufactureDate;
        private Label lblExpirationDate;
        private DateTimePicker dtpExpirationDate;
        private Button btnSave;
        private Button btnCancel;
    }
}
namespace Oil.Forms.Transport
{
    partial class CarriageEditForm
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
            lblVinNumber = new Label();
            txtVinNumber = new TextBox();
            lblLoadCapacity = new Label();
            txtLoadCapacity = new TextBox();
            lblUnitMeasure = new Label();
            txtUnitMeasure = new TextBox();
            lblType = new Label();
            cbxType = new ComboBox();
            lblTrain = new Label();
            cbxTrain = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(465, 39);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(207, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Вагон";
            // 
            // lblVinNumber
            // 
            lblVinNumber.AutoSize = true;
            lblVinNumber.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblVinNumber.Location = new Point(100, 180);
            lblVinNumber.Name = "lblVinNumber";
            lblVinNumber.Size = new Size(138, 29);
            lblVinNumber.TabIndex = 1;
            lblVinNumber.Text = "VIN-номер:";
            // 
            // txtVinNumber
            // 
            txtVinNumber.CharacterCasing = CharacterCasing.Upper;
            txtVinNumber.Font = new Font("Arial", 12F);
            txtVinNumber.Location = new Point(245, 180);
            txtVinNumber.MaxLength = 8;
            txtVinNumber.Name = "txtVinNumber";
            txtVinNumber.Size = new Size(200, 30);
            txtVinNumber.TabIndex = 1;
            txtVinNumber.TextChanged += txtVinNumber_TextChanged;
            // 
            // lblLoadCapacity
            // 
            lblLoadCapacity.AutoSize = true;
            lblLoadCapacity.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblLoadCapacity.Location = new Point(100, 230);
            lblLoadCapacity.Name = "lblLoadCapacity";
            lblLoadCapacity.Size = new Size(222, 29);
            lblLoadCapacity.TabIndex = 3;
            lblLoadCapacity.Text = "Грузоподъемность:";
            // 
            // txtLoadCapacity
            // 
            txtLoadCapacity.Font = new Font("Arial", 12F);
            txtLoadCapacity.Location = new Point(328, 229);
            txtLoadCapacity.Name = "txtLoadCapacity";
            txtLoadCapacity.Size = new Size(359, 30);
            txtLoadCapacity.TabIndex = 2;
            // 
            // lblUnitMeasure
            // 
            lblUnitMeasure.AutoSize = true;
            lblUnitMeasure.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblUnitMeasure.Location = new Point(712, 230);
            lblUnitMeasure.Name = "lblUnitMeasure";
            lblUnitMeasure.Size = new Size(178, 29);
            lblUnitMeasure.TabIndex = 5;
            lblUnitMeasure.Text = "Ед. измерения:";
            // 
            // txtUnitMeasure
            // 
            txtUnitMeasure.Font = new Font("Arial", 12F);
            txtUnitMeasure.Location = new Point(913, 230);
            txtUnitMeasure.Name = "txtUnitMeasure";
            txtUnitMeasure.Size = new Size(150, 30);
            txtUnitMeasure.TabIndex = 3;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblType.Location = new Point(100, 280);
            lblType.Name = "lblType";
            lblType.Size = new Size(62, 29);
            lblType.TabIndex = 7;
            lblType.Text = "Тип:";
            // 
            // cbxType
            // 
            cbxType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxType.Font = new Font("Arial", 12F);
            cbxType.FormattingEnabled = true;
            cbxType.Location = new Point(163, 280);
            cbxType.Name = "cbxType";
            cbxType.Size = new Size(900, 31);
            cbxType.TabIndex = 4;
            // 
            // lblTrain
            // 
            lblTrain.AutoSize = true;
            lblTrain.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTrain.Location = new Point(100, 330);
            lblTrain.Name = "lblTrain";
            lblTrain.Size = new Size(87, 29);
            lblTrain.TabIndex = 9;
            lblTrain.Text = "Поезд:";
            // 
            // cbxTrain
            // 
            cbxTrain.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTrain.Font = new Font("Arial", 12F);
            cbxTrain.FormattingEnabled = true;
            cbxTrain.Location = new Point(196, 330);
            cbxTrain.Name = "cbxTrain";
            cbxTrain.Size = new Size(867, 31);
            cbxTrain.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Constantia", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(350, 400);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 55);
            btnSave.TabIndex = 6;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(550, 400);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 55);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // CarriageEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 500);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbxTrain);
            Controls.Add(lblTrain);
            Controls.Add(cbxType);
            Controls.Add(lblType);
            Controls.Add(txtUnitMeasure);
            Controls.Add(lblUnitMeasure);
            Controls.Add(txtLoadCapacity);
            Controls.Add(lblLoadCapacity);
            Controls.Add(txtVinNumber);
            Controls.Add(lblVinNumber);
            Controls.Add(lblTitle);
            Name = "CarriageEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Редактирование вагона";
            Load += CarriageEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblVinNumber;
        private TextBox txtVinNumber;
        private Label lblLoadCapacity;
        private TextBox txtLoadCapacity;
        private Label lblUnitMeasure;
        private TextBox txtUnitMeasure;
        private Label lblType;
        private ComboBox cbxType;
        private Label lblTrain;
        private ComboBox cbxTrain;
        private Button btnSave;
        private Button btnCancel;
    }
}
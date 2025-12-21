namespace Oil.Forms.Transport
{
    partial class LocomotiveEditForm
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
            lblStateNumber = new Label();
            txtStateNumber = new TextBox();
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
            lblTitle.Location = new Point(367, 46);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(363, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Локомотив";
            // 
            // lblStateNumber
            // 
            lblStateNumber.AutoSize = true;
            lblStateNumber.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblStateNumber.Location = new Point(100, 180);
            lblStateNumber.Name = "lblStateNumber";
            lblStateNumber.Size = new Size(283, 29);
            lblStateNumber.TabIndex = 1;
            lblStateNumber.Text = "Государственный номер:";
            // 
            // txtStateNumber
            // 
            txtStateNumber.CharacterCasing = CharacterCasing.Upper;
            txtStateNumber.Font = new Font("Arial", 12F);
            txtStateNumber.Location = new Point(389, 179);
            txtStateNumber.MaxLength = 8;
            txtStateNumber.Name = "txtStateNumber";
            txtStateNumber.Size = new Size(200, 30);
            txtStateNumber.TabIndex = 1;
            txtStateNumber.TextChanged += txtStateNumber_TextChanged;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblType.Location = new Point(100, 230);
            lblType.Name = "lblType";
            lblType.Size = new Size(62, 29);
            lblType.TabIndex = 3;
            lblType.Text = "Тип:";
            // 
            // cbxType
            // 
            cbxType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxType.Font = new Font("Arial", 12F);
            cbxType.FormattingEnabled = true;
            cbxType.Location = new Point(163, 230);
            cbxType.Name = "cbxType";
            cbxType.Size = new Size(900, 31);
            cbxType.TabIndex = 2;
            // 
            // lblTrain
            // 
            lblTrain.AutoSize = true;
            lblTrain.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblTrain.Location = new Point(100, 280);
            lblTrain.Name = "lblTrain";
            lblTrain.Size = new Size(87, 29);
            lblTrain.TabIndex = 5;
            lblTrain.Text = "Поезд:";
            // 
            // cbxTrain
            // 
            cbxTrain.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTrain.Font = new Font("Arial", 12F);
            cbxTrain.FormattingEnabled = true;
            cbxTrain.Location = new Point(196, 280);
            cbxTrain.Name = "cbxTrain";
            cbxTrain.Size = new Size(867, 31);
            cbxTrain.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Constantia", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(350, 380);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 55);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(550, 380);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 55);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // LocomotiveEditForm
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
            Controls.Add(txtStateNumber);
            Controls.Add(lblStateNumber);
            Controls.Add(lblTitle);
            Name = "LocomotiveEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Редактирование локомотива";
            Load += LocomotiveEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblStateNumber;
        private TextBox txtStateNumber;
        private Label lblType;
        private ComboBox cbxType;
        private Label lblTrain;
        private ComboBox cbxTrain;
        private Button btnSave;
        private Button btnCancel;
    }
}
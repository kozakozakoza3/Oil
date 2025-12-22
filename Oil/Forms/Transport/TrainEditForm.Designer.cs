namespace Oil.Forms.Transport
{
    partial class TrainEditForm
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
            lblStatus = new Label();
            cbxStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(475, 66);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(210, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Поезд";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblName.Location = new Point(200, 200);
            lblName.Name = "lblName";
            lblName.Size = new Size(126, 29);
            lblName.TabIndex = 1;
            lblName.Text = "Название:";
            // 
            // txtName
            // 
            txtName.Font = new Font("Arial", 12F);
            txtName.Location = new Point(325, 200);
            txtName.Name = "txtName";
            txtName.Size = new Size(600, 30);
            txtName.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Constantia", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblStatus.Location = new Point(200, 260);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(91, 29);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Статус:";
            // 
            // cbxStatus
            // 
            cbxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxStatus.Font = new Font("Arial", 12F);
            cbxStatus.FormattingEnabled = true;
            cbxStatus.Location = new Point(296, 260);
            cbxStatus.Name = "cbxStatus";
            cbxStatus.Size = new Size(629, 31);
            cbxStatus.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Constantia", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(388, 343);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 55);
            btnSave.TabIndex = 3;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(588, 343);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 55);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // TrainEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbxStatus);
            Controls.Add(lblStatus);
            Controls.Add(txtName);
            Controls.Add(lblName);
            Controls.Add(lblTitle);
            Name = "TrainEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Редактирование поезда";
            Load += TrainEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblName;
        private TextBox txtName;
        private Label lblStatus;
        private ComboBox cbxStatus;
        private Button btnSave;
        private Button btnCancel;
    }
}
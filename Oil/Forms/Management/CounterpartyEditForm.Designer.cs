namespace Oil.Forms.Management
{
    partial class CounterpartyEditForm
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
            lblCounterpartyType = new Label();
            cbxCounterpartyType = new ComboBox();
            lblOKFS = new Label();
            cbxOKFS = new ComboBox();
            lblOrganization = new Label();
            cbxOrganization = new ComboBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblINN = new Label();
            txtINN = new TextBox();
            lblKPP = new Label();
            txtKPP = new TextBox();
            lblOGRN = new Label();
            txtOGRN = new TextBox();
            lblStatutoryAddress = new Label();
            txtStatutoryAddress = new TextBox();
            lblPhysicalAddress = new Label();
            txtPhysicalAddress = new TextBox();
            btnNewOrganization = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(396, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Контрагент";
            // 
            // lblCounterpartyType
            // 
            lblCounterpartyType.AutoSize = true;
            lblCounterpartyType.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblCounterpartyType.Location = new Point(30, 120);
            lblCounterpartyType.Name = "lblCounterpartyType";
            lblCounterpartyType.Size = new Size(145, 24);
            lblCounterpartyType.TabIndex = 1;
            lblCounterpartyType.Text = "Тип контрагента:";
            // 
            // cbxCounterpartyType
            // 
            cbxCounterpartyType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCounterpartyType.Font = new Font("Arial", 12F);
            cbxCounterpartyType.FormattingEnabled = true;
            cbxCounterpartyType.Location = new Point(200, 113);
            cbxCounterpartyType.Name = "cbxCounterpartyType";
            cbxCounterpartyType.Size = new Size(315, 31);
            cbxCounterpartyType.TabIndex = 1;
            // 
            // lblOKFS
            // 
            lblOKFS.AutoSize = true;
            lblOKFS.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblOKFS.Location = new Point(30, 170);
            lblOKFS.Name = "lblOKFS";
            lblOKFS.Size = new Size(83, 24);
            lblOKFS.TabIndex = 3;
            lblOKFS.Text = "Код ОКФС:";
            // 
            // cbxOKFS
            // 
            cbxOKFS.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxOKFS.Font = new Font("Arial", 12F);
            cbxOKFS.FormattingEnabled = true;
            cbxOKFS.Location = new Point(119, 163);
            cbxOKFS.Name = "cbxOKFS";
            cbxOKFS.Size = new Size(396, 31);
            cbxOKFS.TabIndex = 2;
            // 
            // lblOrganization
            // 
            lblOrganization.AutoSize = true;
            lblOrganization.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblOrganization.Location = new Point(30, 220);
            lblOrganization.Name = "lblOrganization";
            lblOrganization.Size = new Size(180, 24);
            lblOrganization.TabIndex = 5;
            lblOrganization.Text = "Название организации:";
            // 
            // cbxOrganization
            // 
            cbxOrganization.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxOrganization.Font = new Font("Arial", 12F);
            cbxOrganization.FormattingEnabled = true;
            cbxOrganization.Location = new Point(216, 213);
            cbxOrganization.Name = "cbxOrganization";
            cbxOrganization.Size = new Size(299, 31);
            cbxOrganization.TabIndex = 3;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPhone.Location = new Point(614, 120);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(93, 24);
            lblPhone.TabIndex = 7;
            lblPhone.Text = "Телефон:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Arial", 12F);
            txtPhone.Location = new Point(713, 113);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(353, 30);
            txtPhone.TabIndex = 7;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblEmail.Location = new Point(614, 170);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(66, 24);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Arial", 12F);
            txtEmail.Location = new Point(686, 163);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(380, 30);
            txtEmail.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Constantia", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(396, 584);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 55);
            btnSave.TabIndex = 15;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(586, 584);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 55);
            btnCancel.TabIndex = 16;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblINN
            // 
            lblINN.AutoSize = true;
            lblINN.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblINN.Location = new Point(30, 320);
            lblINN.Name = "lblINN";
            lblINN.Size = new Size(49, 24);
            lblINN.TabIndex = 13;
            lblINN.Text = "ИНН:";
            // 
            // txtINN
            // 
            txtINN.Font = new Font("Arial", 12F);
            txtINN.Location = new Point(85, 313);
            txtINN.MaxLength = 10;
            txtINN.Name = "txtINN";
            txtINN.Size = new Size(430, 30);
            txtINN.TabIndex = 4;
            txtINN.KeyPress += txtINN_KeyPress;
            // 
            // lblKPP
            // 
            lblKPP.AutoSize = true;
            lblKPP.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblKPP.Location = new Point(30, 370);
            lblKPP.Name = "lblKPP";
            lblKPP.Size = new Size(50, 24);
            lblKPP.TabIndex = 15;
            lblKPP.Text = "КПП:";
            // 
            // txtKPP
            // 
            txtKPP.Font = new Font("Arial", 12F);
            txtKPP.Location = new Point(86, 363);
            txtKPP.MaxLength = 9;
            txtKPP.Name = "txtKPP";
            txtKPP.Size = new Size(429, 30);
            txtKPP.TabIndex = 5;
            txtKPP.KeyPress += txtKPP_KeyPress;
            // 
            // lblOGRN
            // 
            lblOGRN.AutoSize = true;
            lblOGRN.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblOGRN.Location = new Point(30, 420);
            lblOGRN.Name = "lblOGRN";
            lblOGRN.Size = new Size(64, 24);
            lblOGRN.TabIndex = 17;
            lblOGRN.Text = "ОГРН:";
            // 
            // txtOGRN
            // 
            txtOGRN.Font = new Font("Arial", 12F);
            txtOGRN.Location = new Point(100, 413);
            txtOGRN.MaxLength = 13;
            txtOGRN.Name = "txtOGRN";
            txtOGRN.Size = new Size(415, 30);
            txtOGRN.TabIndex = 6;
            txtOGRN.KeyPress += txtOGRN_KeyPress;
            // 
            // lblStatutoryAddress
            // 
            lblStatutoryAddress.AutoSize = true;
            lblStatutoryAddress.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblStatutoryAddress.Location = new Point(614, 220);
            lblStatutoryAddress.Name = "lblStatutoryAddress";
            lblStatutoryAddress.Size = new Size(170, 24);
            lblStatutoryAddress.TabIndex = 19;
            lblStatutoryAddress.Text = "Юридический адрес:";
            // 
            // txtStatutoryAddress
            // 
            txtStatutoryAddress.Font = new Font("Arial", 12F);
            txtStatutoryAddress.Location = new Point(790, 213);
            txtStatutoryAddress.Multiline = true;
            txtStatutoryAddress.Name = "txtStatutoryAddress";
            txtStatutoryAddress.Size = new Size(276, 80);
            txtStatutoryAddress.TabIndex = 9;
            // 
            // lblPhysicalAddress
            // 
            lblPhysicalAddress.AutoSize = true;
            lblPhysicalAddress.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPhysicalAddress.Location = new Point(614, 320);
            lblPhysicalAddress.Name = "lblPhysicalAddress";
            lblPhysicalAddress.Size = new Size(157, 24);
            lblPhysicalAddress.TabIndex = 21;
            lblPhysicalAddress.Text = "Физический адрес:";
            // 
            // txtPhysicalAddress
            // 
            txtPhysicalAddress.Font = new Font("Arial", 12F);
            txtPhysicalAddress.Location = new Point(790, 313);
            txtPhysicalAddress.Multiline = true;
            txtPhysicalAddress.Name = "txtPhysicalAddress";
            txtPhysicalAddress.Size = new Size(276, 80);
            txtPhysicalAddress.TabIndex = 10;
            // 
            // CounterpartyEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 651);
            Controls.Add(btnNewOrganization);
            Controls.Add(txtPhysicalAddress);
            Controls.Add(lblPhysicalAddress);
            Controls.Add(txtStatutoryAddress);
            Controls.Add(lblStatutoryAddress);
            Controls.Add(txtOGRN);
            Controls.Add(lblOGRN);
            Controls.Add(txtKPP);
            Controls.Add(lblKPP);
            Controls.Add(txtINN);
            Controls.Add(lblINN);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(cbxOrganization);
            Controls.Add(lblOrganization);
            Controls.Add(cbxOKFS);
            Controls.Add(lblOKFS);
            Controls.Add(cbxCounterpartyType);
            Controls.Add(lblCounterpartyType);
            Controls.Add(lblTitle);
            Name = "CounterpartyEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Редактирование контрагента";
            Load += CounterpartyEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblCounterpartyType;
        private ComboBox cbxCounterpartyType;
        private Label lblOKFS;
        private ComboBox cbxOKFS;
        private Label lblOrganization;
        private ComboBox cbxOrganization;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnSave;
        private Button btnCancel;
        private Label lblINN;
        private TextBox txtINN;
        private Label lblKPP;
        private TextBox txtKPP;
        private Label lblOGRN;
        private TextBox txtOGRN;
        private Label lblStatutoryAddress;
        private TextBox txtStatutoryAddress;
        private Label lblPhysicalAddress;
        private TextBox txtPhysicalAddress;
        private Button btnNewOrganization;
    }
}
using System.Windows.Forms;
using System.Xml.Linq;

namespace Oil.Forms.Management
{
    partial class EmployeeEditForm
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
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblMiddleName = new Label();
            txtMiddleName = new TextBox();
            lblDepartment = new Label();
            cbxDepartment = new ComboBox();
            lblPost = new Label();
            cbxPost = new ComboBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            lblSex = new Label();
            cbxSex = new ComboBox();
            lblEducation = new Label();
            cbxEducation = new ComboBox();
            lblInstitution = new Label();
            cbxInstitution = new ComboBox();
            lblQualification = new Label();
            cbxQualification = new ComboBox();
            lblPassportSeries = new Label();
            txtPassportSeries = new TextBox();
            lblPassportNumber = new Label();
            txtPassportNumber = new TextBox();
            lblPassportDate = new Label();
            dtpPassportDate = new DateTimePicker();
            lblWhoIssuedPassport = new Label();
            txtWhoIssuedPassport = new TextBox();
            lblSubdivisionCode = new Label();
            txtSubdivisionCode = new TextBox();
            lblResidentialAddress = new Label();
            txtResidentialAddress = new TextBox();
            lblRegistrationAddress = new Label();
            txtRegistrationAddress = new TextBox();
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
            lblTitle.Text = "Сотрудник";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblLastName.Location = new Point(30, 120);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(98, 24);
            lblLastName.TabIndex = 1;
            lblLastName.Text = "Фамилия:";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Arial", 12F);
            txtLastName.Location = new Point(150, 113);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(365, 30);
            txtLastName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFirstName.Location = new Point(30, 170);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(55, 24);
            lblFirstName.TabIndex = 3;
            lblFirstName.Text = "Имя:";
            // 
            // txtFirstName
            // 
            txtFirstName.Font = new Font("Arial", 12F);
            txtFirstName.Location = new Point(91, 163);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(424, 30);
            txtFirstName.TabIndex = 2;
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblMiddleName.Location = new Point(30, 220);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new Size(102, 24);
            lblMiddleName.TabIndex = 5;
            lblMiddleName.Text = "Отчество:";
            // 
            // txtMiddleName
            // 
            txtMiddleName.Font = new Font("Arial", 12F);
            txtMiddleName.Location = new Point(150, 213);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(365, 30);
            txtMiddleName.TabIndex = 3;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblDepartment.Location = new Point(30, 320);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(72, 24);
            lblDepartment.TabIndex = 7;
            lblDepartment.Text = "Отдел:";
            // 
            // cbxDepartment
            // 
            cbxDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxDepartment.Font = new Font("Arial", 12F);
            cbxDepartment.FormattingEnabled = true;
            cbxDepartment.Location = new Point(108, 313);
            cbxDepartment.Name = "cbxDepartment";
            cbxDepartment.Size = new Size(407, 31);
            cbxDepartment.TabIndex = 6;
            // 
            // lblPost
            // 
            lblPost.AutoSize = true;
            lblPost.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPost.Location = new Point(30, 370);
            lblPost.Name = "lblPost";
            lblPost.Size = new Size(117, 24);
            lblPost.TabIndex = 9;
            lblPost.Text = "Должность:";
            // 
            // cbxPost
            // 
            cbxPost.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxPost.Font = new Font("Arial", 12F);
            cbxPost.FormattingEnabled = true;
            cbxPost.Location = new Point(153, 363);
            cbxPost.Name = "cbxPost";
            cbxPost.Size = new Size(362, 31);
            cbxPost.TabIndex = 7;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPhone.Location = new Point(614, 116);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(93, 24);
            lblPhone.TabIndex = 11;
            lblPhone.Text = "Телефон:";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Arial", 12F);
            txtPhone.Location = new Point(713, 113);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(353, 30);
            txtPhone.TabIndex = 13;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblEmail.Location = new Point(614, 166);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(66, 24);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Arial", 12F);
            txtEmail.Location = new Point(686, 163);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(380, 30);
            txtEmail.TabIndex = 14;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Constantia", 14F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(396, 634);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(180, 55);
            btnSave.TabIndex = 21;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Arial", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnCancel.Location = new Point(586, 634);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(180, 55);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblSex
            // 
            lblSex.AutoSize = true;
            lblSex.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblSex.Location = new Point(30, 270);
            lblSex.Name = "lblSex";
            lblSex.Size = new Size(51, 24);
            lblSex.TabIndex = 17;
            lblSex.Text = "Пол:";
            // 
            // cbxSex
            // 
            cbxSex.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxSex.Font = new Font("Arial", 12F);
            cbxSex.FormattingEnabled = true;
            cbxSex.Location = new Point(102, 263);
            cbxSex.Name = "cbxSex";
            cbxSex.Size = new Size(413, 31);
            cbxSex.TabIndex = 4;
            // 
            // lblEducation
            // 
            lblEducation.AutoSize = true;
            lblEducation.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblEducation.Location = new Point(30, 420);
            lblEducation.Name = "lblEducation";
            lblEducation.Size = new Size(137, 24);
            lblEducation.TabIndex = 19;
            lblEducation.Text = "Образование:";
            // 
            // cbxEducation
            // 
            cbxEducation.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEducation.Font = new Font("Arial", 12F);
            cbxEducation.FormattingEnabled = true;
            cbxEducation.Location = new Point(172, 413);
            cbxEducation.Name = "cbxEducation";
            cbxEducation.Size = new Size(343, 31);
            cbxEducation.TabIndex = 8;
            // 
            // lblInstitution
            // 
            lblInstitution.AutoSize = true;
            lblInstitution.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblInstitution.Location = new Point(28, 470);
            lblInstitution.Name = "lblInstitution";
            lblInstitution.Size = new Size(191, 24);
            lblInstitution.TabIndex = 21;
            lblInstitution.Text = "Учебное заведение:";
            // 
            // cbxInstitution
            // 
            cbxInstitution.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxInstitution.Font = new Font("Arial", 12F);
            cbxInstitution.FormattingEnabled = true;
            cbxInstitution.Location = new Point(225, 467);
            cbxInstitution.Name = "cbxInstitution";
            cbxInstitution.Size = new Size(290, 31);
            cbxInstitution.TabIndex = 15;
            cbxInstitution.SelectedIndexChanged += cbxInstitution_SelectedIndexChanged;
            // 
            // lblQualification
            // 
            lblQualification.AutoSize = true;
            lblQualification.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblQualification.Location = new Point(28, 520);
            lblQualification.Name = "lblQualification";
            lblQualification.Size = new Size(152, 24);
            lblQualification.TabIndex = 23;
            lblQualification.Text = "Квалификация:";
            // 
            // cbxQualification
            // 
            cbxQualification.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxQualification.Font = new Font("Arial", 12F);
            cbxQualification.FormattingEnabled = true;
            cbxQualification.Location = new Point(182, 517);
            cbxQualification.Name = "cbxQualification";
            cbxQualification.Size = new Size(333, 31);
            cbxQualification.TabIndex = 16;
            // 
            // lblPassportSeries
            // 
            lblPassportSeries.AutoSize = true;
            lblPassportSeries.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPassportSeries.Location = new Point(614, 213);
            lblPassportSeries.Name = "lblPassportSeries";
            lblPassportSeries.Size = new Size(161, 24);
            lblPassportSeries.TabIndex = 25;
            lblPassportSeries.Text = "Серия паспорта:";
            // 
            // txtPassportSeries
            // 
            txtPassportSeries.Font = new Font("Arial", 12F);
            txtPassportSeries.Location = new Point(787, 210);
            txtPassportSeries.MaxLength = 4;
            txtPassportSeries.Name = "txtPassportSeries";
            txtPassportSeries.Size = new Size(279, 30);
            txtPassportSeries.TabIndex = 9;
            // 
            // lblPassportNumber
            // 
            lblPassportNumber.AutoSize = true;
            lblPassportNumber.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPassportNumber.Location = new Point(614, 263);
            lblPassportNumber.Name = "lblPassportNumber";
            lblPassportNumber.Size = new Size(167, 24);
            lblPassportNumber.TabIndex = 27;
            lblPassportNumber.Text = "Номер паспорта:";
            // 
            // txtPassportNumber
            // 
            txtPassportNumber.Font = new Font("Arial", 12F);
            txtPassportNumber.Location = new Point(787, 257);
            txtPassportNumber.MaxLength = 6;
            txtPassportNumber.Name = "txtPassportNumber";
            txtPassportNumber.Size = new Size(279, 30);
            txtPassportNumber.TabIndex = 10;
            // 
            // lblPassportDate
            // 
            lblPassportDate.AutoSize = true;
            lblPassportDate.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblPassportDate.Location = new Point(614, 317);
            lblPassportDate.Name = "lblPassportDate";
            lblPassportDate.Size = new Size(131, 24);
            lblPassportDate.TabIndex = 29;
            lblPassportDate.Text = "Дата выдачи:";
            // 
            // dtpPassportDate
            // 
            dtpPassportDate.Font = new Font("Arial", 12F);
            dtpPassportDate.Format = DateTimePickerFormat.Short;
            dtpPassportDate.Location = new Point(768, 314);
            dtpPassportDate.Name = "dtpPassportDate";
            dtpPassportDate.Size = new Size(298, 30);
            dtpPassportDate.TabIndex = 17;
            // 
            // lblWhoIssuedPassport
            // 
            lblWhoIssuedPassport.AutoSize = true;
            lblWhoIssuedPassport.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblWhoIssuedPassport.Location = new Point(614, 367);
            lblWhoIssuedPassport.Name = "lblWhoIssuedPassport";
            lblWhoIssuedPassport.Size = new Size(194, 24);
            lblWhoIssuedPassport.TabIndex = 31;
            lblWhoIssuedPassport.Text = "Кем выдан паспорт:";
            // 
            // txtWhoIssuedPassport
            // 
            txtWhoIssuedPassport.Font = new Font("Arial", 12F);
            txtWhoIssuedPassport.Location = new Point(819, 364);
            txtWhoIssuedPassport.Name = "txtWhoIssuedPassport";
            txtWhoIssuedPassport.Size = new Size(247, 30);
            txtWhoIssuedPassport.TabIndex = 18;
            // 
            // lblSubdivisionCode
            // 
            lblSubdivisionCode.AutoSize = true;
            lblSubdivisionCode.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblSubdivisionCode.Location = new Point(615, 420);
            lblSubdivisionCode.Name = "lblSubdivisionCode";
            lblSubdivisionCode.Size = new Size(193, 24);
            lblSubdivisionCode.TabIndex = 33;
            lblSubdivisionCode.Text = "Код подразделения:";
            // 
            // txtSubdivisionCode
            // 
            txtSubdivisionCode.Font = new Font("Arial", 12F);
            txtSubdivisionCode.Location = new Point(819, 417);
            txtSubdivisionCode.Name = "txtSubdivisionCode";
            txtSubdivisionCode.Size = new Size(247, 30);
            txtSubdivisionCode.TabIndex = 11;
            // 
            // lblResidentialAddress
            // 
            lblResidentialAddress.AutoSize = true;
            lblResidentialAddress.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblResidentialAddress.Location = new Point(614, 473);
            lblResidentialAddress.Name = "lblResidentialAddress";
            lblResidentialAddress.Size = new Size(189, 24);
            lblResidentialAddress.TabIndex = 35;
            lblResidentialAddress.Text = "Адрес проживания:";
            // 
            // txtResidentialAddress
            // 
            txtResidentialAddress.Font = new Font("Arial", 12F);
            txtResidentialAddress.Location = new Point(834, 470);
            txtResidentialAddress.Multiline = true;
            txtResidentialAddress.Name = "txtResidentialAddress";
            txtResidentialAddress.Size = new Size(232, 60);
            txtResidentialAddress.TabIndex = 19;
            // 
            // lblRegistrationAddress
            // 
            lblRegistrationAddress.AutoSize = true;
            lblRegistrationAddress.Font = new Font("Constantia", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblRegistrationAddress.Location = new Point(614, 543);
            lblRegistrationAddress.Name = "lblRegistrationAddress";
            lblRegistrationAddress.Size = new Size(192, 24);
            lblRegistrationAddress.TabIndex = 37;
            lblRegistrationAddress.Text = "Адрес регистрации:";
            // 
            // txtRegistrationAddress
            // 
            txtRegistrationAddress.Font = new Font("Arial", 12F);
            txtRegistrationAddress.Location = new Point(834, 540);
            txtRegistrationAddress.Multiline = true;
            txtRegistrationAddress.Name = "txtRegistrationAddress";
            txtRegistrationAddress.Size = new Size(232, 60);
            txtRegistrationAddress.TabIndex = 20;
            // 
            // EmployeeEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 701);
            Controls.Add(txtRegistrationAddress);
            Controls.Add(lblRegistrationAddress);
            Controls.Add(txtResidentialAddress);
            Controls.Add(lblResidentialAddress);
            Controls.Add(txtSubdivisionCode);
            Controls.Add(lblSubdivisionCode);
            Controls.Add(txtWhoIssuedPassport);
            Controls.Add(lblWhoIssuedPassport);
            Controls.Add(dtpPassportDate);
            Controls.Add(lblPassportDate);
            Controls.Add(txtPassportNumber);
            Controls.Add(lblPassportNumber);
            Controls.Add(txtPassportSeries);
            Controls.Add(lblPassportSeries);
            Controls.Add(cbxQualification);
            Controls.Add(lblQualification);
            Controls.Add(cbxInstitution);
            Controls.Add(lblInstitution);
            Controls.Add(cbxEducation);
            Controls.Add(lblEducation);
            Controls.Add(cbxSex);
            Controls.Add(lblSex);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(cbxPost);
            Controls.Add(lblPost);
            Controls.Add(cbxDepartment);
            Controls.Add(lblDepartment);
            Controls.Add(txtMiddleName);
            Controls.Add(lblMiddleName);
            Controls.Add(txtFirstName);
            Controls.Add(lblFirstName);
            Controls.Add(txtLastName);
            Controls.Add(lblLastName);
            Controls.Add(lblTitle);
            Name = "EmployeeEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Редактирование сотрудника";
            Load += EmployeeEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblMiddleName;
        private TextBox txtMiddleName;
        private Label lblDepartment;
        private ComboBox cbxDepartment;
        private Label lblPost;
        private ComboBox cbxPost;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnSave;
        private Button btnCancel;
        private Label lblSex;
        private ComboBox cbxSex;
        private Label lblEducation;
        private ComboBox cbxEducation;
        private Label lblInstitution;
        private ComboBox cbxInstitution;
        private Label lblQualification;
        private ComboBox cbxQualification;
        private Label lblPassportSeries;
        private TextBox txtPassportSeries;
        private Label lblPassportNumber;
        private TextBox txtPassportNumber;
        private Label lblPassportDate;
        private DateTimePicker dtpPassportDate;
        private Label lblWhoIssuedPassport;
        private TextBox txtWhoIssuedPassport;
        private Label lblSubdivisionCode;
        private TextBox txtSubdivisionCode;
        private Label lblResidentialAddress;
        private TextBox txtResidentialAddress;
        private Label lblRegistrationAddress;
        private TextBox txtRegistrationAddress;
    }
}
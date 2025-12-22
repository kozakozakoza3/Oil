using System.Windows.Forms;
using System.Xml.Linq;

namespace Oil.Forms.Transport
{
    partial class RouteEditForm
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
            lblRouteStatus = new Label();
            cbxRouteStatus = new ComboBox();
            lblDateSending = new Label();
            dtpDateSending = new DateTimePicker();
            lblDateArrival = new Label();
            dtpDateArrival = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(465, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(240, 58);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Маршрут";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblRouteStatus
            // 
            lblRouteStatus.AutoSize = true;
            lblRouteStatus.Font = new Font("Constantia", 14F);
            lblRouteStatus.Location = new Point(80, 150);
            lblRouteStatus.Name = "lblRouteStatus";
            lblRouteStatus.Size = new Size(205, 29);
            lblRouteStatus.TabIndex = 1;
            lblRouteStatus.Text = "Статус маршрута:";
            // 
            // cbxRouteStatus
            // 
            cbxRouteStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxRouteStatus.Font = new Font("Arial", 12F);
            cbxRouteStatus.FormattingEnabled = true;
            cbxRouteStatus.Location = new Point(320, 150);
            cbxRouteStatus.Name = "cbxRouteStatus";
            cbxRouteStatus.Size = new Size(750, 31);
            cbxRouteStatus.TabIndex = 1;
            // 
            // lblDateSending
            // 
            lblDateSending.AutoSize = true;
            lblDateSending.Font = new Font("Constantia", 14F);
            lblDateSending.Location = new Point(80, 220);
            lblDateSending.Name = "lblDateSending";
            lblDateSending.Size = new Size(271, 29);
            lblDateSending.TabIndex = 3;
            lblDateSending.Text = "Дата и время отправки:";
            // 
            // dtpDateSending
            // 
            dtpDateSending.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpDateSending.Font = new Font("Arial", 12F);
            dtpDateSending.Format = DateTimePickerFormat.Custom;
            dtpDateSending.Location = new Point(365, 220);
            dtpDateSending.Name = "dtpDateSending";
            dtpDateSending.Size = new Size(705, 30);
            dtpDateSending.TabIndex = 2;
            dtpDateSending.ValueChanged += dtpDateSending_ValueChanged;
            // 
            // lblDateArrival
            // 
            lblDateArrival.AutoSize = true;
            lblDateArrival.Font = new Font("Constantia", 14F);
            lblDateArrival.Location = new Point(80, 290);
            lblDateArrival.Name = "lblDateArrival";
            lblDateArrival.Size = new Size(279, 29);
            lblDateArrival.TabIndex = 5;
            lblDateArrival.Text = "Дата и время прибытия:";
            // 
            // dtpDateArrival
            // 
            dtpDateArrival.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpDateArrival.Font = new Font("Arial", 12F);
            dtpDateArrival.Format = DateTimePickerFormat.Custom;
            dtpDateArrival.Location = new Point(365, 290);
            dtpDateArrival.Name = "dtpDateArrival";
            dtpDateArrival.Size = new Size(705, 30);
            dtpDateArrival.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(397, 400);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(163, 55);
            btnSave.TabIndex = 4;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Constantia", 12F);
            btnCancel.Location = new Point(566, 400);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(163, 55);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // RouteEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 500);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dtpDateArrival);
            Controls.Add(lblDateArrival);
            Controls.Add(dtpDateSending);
            Controls.Add(lblDateSending);
            Controls.Add(cbxRouteStatus);
            Controls.Add(lblRouteStatus);
            Controls.Add(lblTitle);
            Name = "RouteEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ф";
            Load += RouteEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblRouteStatus;
        private ComboBox cbxRouteStatus;
        private Label lblDateSending;
        private DateTimePicker dtpDateSending;
        private Label lblDateArrival;
        private DateTimePicker dtpDateArrival;
        private Button btnSave;
        private Button btnCancel;
    }
}
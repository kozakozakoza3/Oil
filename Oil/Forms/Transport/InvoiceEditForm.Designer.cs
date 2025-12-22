using System.Windows.Forms;
using System.Xml.Linq;

namespace Oil.Forms.Transport
{
    partial class InvoiceEditForm
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
            lblOilProductLot = new Label();
            cbxOilProductLot = new ComboBox();
            lblProductInfo = new Label();
            lblCounterparty = new Label();
            cbxCounterparty = new ComboBox();
            lblEmployee = new Label();
            cbxEmployee = new ComboBox();
            lblTrain = new Label();
            cbxTrain = new ComboBox();
            lblFinalPoint = new Label();
            cbxFinalPoint = new ComboBox();
            lblStartingPoint = new Label();
            txtStartingPoint = new TextBox();
            lblDistance = new Label();
            txtDistance = new TextBox();
            lblUnitDistance = new Label();
            cbxUnitDistance = new ComboBox();
            lblInvoiceDateTime = new Label();
            dtpInvoiceDateTime = new DateTimePicker();
            lblSendingDateTime = new Label();
            dtpSendingDateTime = new DateTimePicker();
            lblArrivalDateTime = new Label();
            dtpArrivalDateTime = new DateTimePicker();
            lblRouteStatus = new Label();
            cbxRouteStatus = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(182, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(816, 58);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Товарно-транспортная накладная";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblOilProductLot
            // 
            lblOilProductLot.AutoSize = true;
            lblOilProductLot.Font = new Font("Constantia", 12F);
            lblOilProductLot.Location = new Point(59, 127);
            lblOilProductLot.Name = "lblOilProductLot";
            lblOilProductLot.Size = new Size(173, 24);
            lblOilProductLot.TabIndex = 1;
            lblOilProductLot.Text = "Партия продукта:";
            // 
            // cbxOilProductLot
            // 
            cbxOilProductLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxOilProductLot.Font = new Font("Arial", 10F);
            cbxOilProductLot.FormattingEnabled = true;
            cbxOilProductLot.Location = new Point(247, 127);
            cbxOilProductLot.Name = "cbxOilProductLot";
            cbxOilProductLot.Size = new Size(827, 27);
            cbxOilProductLot.TabIndex = 1;
            cbxOilProductLot.SelectedIndexChanged += cbxOilProductLot_SelectedIndexChanged;
            // 
            // lblProductInfo
            // 
            lblProductInfo.AutoSize = true;
            lblProductInfo.Font = new Font("Arial", 9F, FontStyle.Italic);
            lblProductInfo.ForeColor = Color.DarkSlateGray;
            lblProductInfo.Location = new Point(247, 157);
            lblProductInfo.Name = "lblProductInfo";
            lblProductInfo.Size = new Size(168, 17);
            lblProductInfo.TabIndex = 3;
            lblProductInfo.Text = "Информация о партии";
            // 
            // lblCounterparty
            // 
            lblCounterparty.AutoSize = true;
            lblCounterparty.Font = new Font("Constantia", 12F);
            lblCounterparty.Location = new Point(59, 187);
            lblCounterparty.Name = "lblCounterparty";
            lblCounterparty.Size = new Size(123, 24);
            lblCounterparty.TabIndex = 4;
            lblCounterparty.Text = "Контрагент:";
            // 
            // cbxCounterparty
            // 
            cbxCounterparty.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxCounterparty.Font = new Font("Arial", 10F);
            cbxCounterparty.FormattingEnabled = true;
            cbxCounterparty.Location = new Point(247, 187);
            cbxCounterparty.Name = "cbxCounterparty";
            cbxCounterparty.Size = new Size(827, 27);
            cbxCounterparty.TabIndex = 2;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Font = new Font("Constantia", 12F);
            lblEmployee.Location = new Point(59, 354);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(261, 24);
            lblEmployee.TabIndex = 6;
            lblEmployee.Text = "Ответственный сотрудник:";
            // 
            // cbxEmployee
            // 
            cbxEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxEmployee.Font = new Font("Arial", 10F);
            cbxEmployee.FormattingEnabled = true;
            cbxEmployee.Location = new Point(326, 354);
            cbxEmployee.Name = "cbxEmployee";
            cbxEmployee.Size = new Size(748, 27);
            cbxEmployee.TabIndex = 3;
            // 
            // lblTrain
            // 
            lblTrain.AutoSize = true;
            lblTrain.Font = new Font("Constantia", 12F);
            lblTrain.Location = new Point(59, 227);
            lblTrain.Name = "lblTrain";
            lblTrain.Size = new Size(71, 24);
            lblTrain.TabIndex = 8;
            lblTrain.Text = "Поезд:";
            // 
            // cbxTrain
            // 
            cbxTrain.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxTrain.Font = new Font("Arial", 10F);
            cbxTrain.FormattingEnabled = true;
            cbxTrain.Location = new Point(247, 227);
            cbxTrain.Name = "cbxTrain";
            cbxTrain.Size = new Size(827, 27);
            cbxTrain.TabIndex = 4;
            // 
            // lblFinalPoint
            // 
            lblFinalPoint.AutoSize = true;
            lblFinalPoint.Font = new Font("Constantia", 12F);
            lblFinalPoint.Location = new Point(59, 267);
            lblFinalPoint.Name = "lblFinalPoint";
            lblFinalPoint.Size = new Size(185, 24);
            lblFinalPoint.TabIndex = 10;
            lblFinalPoint.Text = "Пункт назначения:";
            // 
            // cbxFinalPoint
            // 
            cbxFinalPoint.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxFinalPoint.Font = new Font("Arial", 10F);
            cbxFinalPoint.FormattingEnabled = true;
            cbxFinalPoint.Location = new Point(247, 267);
            cbxFinalPoint.Name = "cbxFinalPoint";
            cbxFinalPoint.Size = new Size(827, 27);
            cbxFinalPoint.TabIndex = 5;
            // 
            // lblStartingPoint
            // 
            lblStartingPoint.AutoSize = true;
            lblStartingPoint.Font = new Font("Constantia", 12F);
            lblStartingPoint.Location = new Point(59, 307);
            lblStartingPoint.Name = "lblStartingPoint";
            lblStartingPoint.Size = new Size(196, 24);
            lblStartingPoint.TabIndex = 12;
            lblStartingPoint.Text = "Пункт отправления:";
            // 
            // txtStartingPoint
            // 
            txtStartingPoint.Font = new Font("Arial", 10F);
            txtStartingPoint.Location = new Point(247, 307);
            txtStartingPoint.Name = "txtStartingPoint";
            txtStartingPoint.Size = new Size(827, 27);
            txtStartingPoint.TabIndex = 6;
            // 
            // lblDistance
            // 
            lblDistance.AutoSize = true;
            lblDistance.Font = new Font("Constantia", 12F);
            lblDistance.Location = new Point(63, 392);
            lblDistance.Name = "lblDistance";
            lblDistance.Size = new Size(120, 24);
            lblDistance.TabIndex = 14;
            lblDistance.Text = "Расстояние:";
            // 
            // txtDistance
            // 
            txtDistance.Font = new Font("Arial", 10F);
            txtDistance.Location = new Point(189, 392);
            txtDistance.Name = "txtDistance";
            txtDistance.Size = new Size(489, 27);
            txtDistance.TabIndex = 7;
            txtDistance.KeyPress += txtNumeric_KeyPress;
            // 
            // lblUnitDistance
            // 
            lblUnitDistance.AutoSize = true;
            lblUnitDistance.Font = new Font("Constantia", 12F);
            lblUnitDistance.Location = new Point(705, 395);
            lblUnitDistance.Name = "lblUnitDistance";
            lblUnitDistance.Size = new Size(141, 24);
            lblUnitDistance.TabIndex = 16;
            lblUnitDistance.Text = "Единица изм.:";
            // 
            // cbxUnitDistance
            // 
            cbxUnitDistance.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxUnitDistance.Font = new Font("Arial", 10F);
            cbxUnitDistance.FormattingEnabled = true;
            cbxUnitDistance.Location = new Point(852, 396);
            cbxUnitDistance.Name = "cbxUnitDistance";
            cbxUnitDistance.Size = new Size(222, 27);
            cbxUnitDistance.TabIndex = 8;
            // 
            // lblInvoiceDateTime
            // 
            lblInvoiceDateTime.AutoSize = true;
            lblInvoiceDateTime.Font = new Font("Constantia", 12F);
            lblInvoiceDateTime.Location = new Point(63, 432);
            lblInvoiceDateTime.Name = "lblInvoiceDateTime";
            lblInvoiceDateTime.Size = new Size(222, 24);
            lblInvoiceDateTime.TabIndex = 18;
            lblInvoiceDateTime.Text = "Дата составления ТТН:";
            // 
            // dtpInvoiceDateTime
            // 
            dtpInvoiceDateTime.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpInvoiceDateTime.Font = new Font("Arial", 10F);
            dtpInvoiceDateTime.Format = DateTimePickerFormat.Custom;
            dtpInvoiceDateTime.Location = new Point(284, 432);
            dtpInvoiceDateTime.Name = "dtpInvoiceDateTime";
            dtpInvoiceDateTime.Size = new Size(406, 27);
            dtpInvoiceDateTime.TabIndex = 9;
            // 
            // lblSendingDateTime
            // 
            lblSendingDateTime.AutoSize = true;
            lblSendingDateTime.Font = new Font("Constantia", 12F);
            lblSendingDateTime.Location = new Point(63, 472);
            lblSendingDateTime.Name = "lblSendingDateTime";
            lblSendingDateTime.Size = new Size(151, 24);
            lblSendingDateTime.TabIndex = 20;
            lblSendingDateTime.Text = "Дата отправки:";
            // 
            // dtpSendingDateTime
            // 
            dtpSendingDateTime.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpSendingDateTime.Font = new Font("Arial", 10F);
            dtpSendingDateTime.Format = DateTimePickerFormat.Custom;
            dtpSendingDateTime.Location = new Point(284, 472);
            dtpSendingDateTime.Name = "dtpSendingDateTime";
            dtpSendingDateTime.Size = new Size(406, 27);
            dtpSendingDateTime.TabIndex = 10;
            // 
            // lblArrivalDateTime
            // 
            lblArrivalDateTime.AutoSize = true;
            lblArrivalDateTime.Font = new Font("Constantia", 12F);
            lblArrivalDateTime.Location = new Point(63, 512);
            lblArrivalDateTime.Name = "lblArrivalDateTime";
            lblArrivalDateTime.Size = new Size(156, 24);
            lblArrivalDateTime.TabIndex = 22;
            lblArrivalDateTime.Text = "Дата прибытия:";
            // 
            // dtpArrivalDateTime
            // 
            dtpArrivalDateTime.CustomFormat = "dd.MM.yyyy HH:mm";
            dtpArrivalDateTime.Font = new Font("Arial", 10F);
            dtpArrivalDateTime.Format = DateTimePickerFormat.Custom;
            dtpArrivalDateTime.Location = new Point(284, 512);
            dtpArrivalDateTime.Name = "dtpArrivalDateTime";
            dtpArrivalDateTime.Size = new Size(406, 27);
            dtpArrivalDateTime.TabIndex = 11;
            // 
            // lblRouteStatus
            // 
            lblRouteStatus.AutoSize = true;
            lblRouteStatus.Font = new Font("Constantia", 12F);
            lblRouteStatus.Location = new Point(63, 552);
            lblRouteStatus.Name = "lblRouteStatus";
            lblRouteStatus.Size = new Size(173, 24);
            lblRouteStatus.TabIndex = 24;
            lblRouteStatus.Text = "Статус маршрута:";
            // 
            // cbxRouteStatus
            // 
            cbxRouteStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxRouteStatus.Font = new Font("Arial", 10F);
            cbxRouteStatus.FormattingEnabled = true;
            cbxRouteStatus.Location = new Point(284, 552);
            cbxRouteStatus.Name = "cbxRouteStatus";
            cbxRouteStatus.Size = new Size(406, 27);
            cbxRouteStatus.TabIndex = 12;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.CadetBlue;
            btnSave.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(401, 604);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(163, 55);
            btnSave.TabIndex = 13;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.LightGray;
            btnCancel.Font = new Font("Constantia", 12F);
            btnCancel.Location = new Point(570, 604);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(163, 55);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // InvoiceEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 700);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbxRouteStatus);
            Controls.Add(lblRouteStatus);
            Controls.Add(dtpArrivalDateTime);
            Controls.Add(lblArrivalDateTime);
            Controls.Add(dtpSendingDateTime);
            Controls.Add(lblSendingDateTime);
            Controls.Add(dtpInvoiceDateTime);
            Controls.Add(lblInvoiceDateTime);
            Controls.Add(cbxUnitDistance);
            Controls.Add(lblUnitDistance);
            Controls.Add(txtDistance);
            Controls.Add(lblDistance);
            Controls.Add(txtStartingPoint);
            Controls.Add(lblStartingPoint);
            Controls.Add(cbxFinalPoint);
            Controls.Add(lblFinalPoint);
            Controls.Add(cbxTrain);
            Controls.Add(lblTrain);
            Controls.Add(cbxEmployee);
            Controls.Add(lblEmployee);
            Controls.Add(cbxCounterparty);
            Controls.Add(lblCounterparty);
            Controls.Add(lblProductInfo);
            Controls.Add(cbxOilProductLot);
            Controls.Add(lblOilProductLot);
            Controls.Add(lblTitle);
            Name = "InvoiceEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Редактирование товарно-транспортной накладной";
            Load += InvoiceEditForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblOilProductLot;
        private ComboBox cbxOilProductLot;
        private Label lblProductInfo;
        private Label lblCounterparty;
        private ComboBox cbxCounterparty;
        private Label lblEmployee;
        private ComboBox cbxEmployee;
        private Label lblTrain;
        private ComboBox cbxTrain;
        private Label lblFinalPoint;
        private ComboBox cbxFinalPoint;
        private Label lblStartingPoint;
        private TextBox txtStartingPoint;
        private Label lblDistance;
        private TextBox txtDistance;
        private Label lblUnitDistance;
        private ComboBox cbxUnitDistance;
        private Label lblInvoiceDateTime;
        private DateTimePicker dtpInvoiceDateTime;
        private Label lblSendingDateTime;
        private DateTimePicker dtpSendingDateTime;
        private Label lblArrivalDateTime;
        private DateTimePicker dtpArrivalDateTime;
        private Label lblRouteStatus;
        private ComboBox cbxRouteStatus;
        private Button btnSave;
        private Button btnCancel;
    }
}
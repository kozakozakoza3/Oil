namespace Oil
{
    partial class OilLotForm
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
            lblLotNumber = new Label();
            txtLotNumber = new TextBox();
            lblExtractionDate = new Label();
            dtpExtractionDate = new DateTimePicker();
            lblColor = new Label();
            txtColor = new TextBox();
            lblFraction = new Label();
            txtFraction = new TextBox();
            lblDensity = new Label();
            txtDensity = new TextBox();
            lblViscosity = new Label();
            txtViscosity = new TextBox();
            lblSulfurContent = new Label();
            txtSulfurContent = new TextBox();
            lblOilfield = new Label();
            txtOilfield = new TextBox();
            lblRegion = new Label();
            txtRegion = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(200, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(230, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ПАРТИЯ НЕФТИ";
            // 
            // lblLotNumber
            // 
            lblLotNumber.AutoSize = true;
            lblLotNumber.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblLotNumber.Location = new Point(70, 80);
            lblLotNumber.Name = "lblLotNumber";
            lblLotNumber.Size = new Size(121, 19);
            lblLotNumber.TabIndex = 1;
            lblLotNumber.Text = "Номер партии:";
            // 
            // txtLotNumber
            // 
            txtLotNumber.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtLotNumber.Location = new Point(237, 72);
            txtLotNumber.Name = "txtLotNumber";
            txtLotNumber.Size = new Size(323, 27);
            txtLotNumber.TabIndex = 1;
            // 
            // lblExtractionDate
            // 
            lblExtractionDate.AutoSize = true;
            lblExtractionDate.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblExtractionDate.Location = new Point(70, 120);
            lblExtractionDate.Name = "lblExtractionDate";
            lblExtractionDate.Size = new Size(115, 19);
            lblExtractionDate.TabIndex = 3;
            lblExtractionDate.Text = "Дата добычи:";
            // 
            // dtpExtractionDate
            // 
            dtpExtractionDate.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dtpExtractionDate.Location = new Point(237, 112);
            dtpExtractionDate.Name = "dtpExtractionDate";
            dtpExtractionDate.Size = new Size(323, 27);
            dtpExtractionDate.TabIndex = 2;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblColor.Location = new Point(70, 160);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(52, 19);
            lblColor.TabIndex = 5;
            lblColor.Text = "Цвет:";
            // 
            // txtColor
            // 
            txtColor.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtColor.Location = new Point(237, 152);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(323, 27);
            txtColor.TabIndex = 3;
            // 
            // lblFraction
            // 
            lblFraction.AutoSize = true;
            lblFraction.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblFraction.Location = new Point(70, 200);
            lblFraction.Name = "lblFraction";
            lblFraction.Size = new Size(80, 19);
            lblFraction.TabIndex = 7;
            lblFraction.Text = "Фракция:";
            // 
            // txtFraction
            // 
            txtFraction.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtFraction.Location = new Point(237, 192);
            txtFraction.Name = "txtFraction";
            txtFraction.Size = new Size(323, 27);
            txtFraction.TabIndex = 4;
            // 
            // lblDensity
            // 
            lblDensity.AutoSize = true;
            lblDensity.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblDensity.Location = new Point(70, 240);
            lblDensity.Name = "lblDensity";
            lblDensity.Size = new Size(96, 19);
            lblDensity.TabIndex = 9;
            lblDensity.Text = "Плотность:";
            // 
            // txtDensity
            // 
            txtDensity.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtDensity.Location = new Point(237, 232);
            txtDensity.Name = "txtDensity";
            txtDensity.Size = new Size(323, 27);
            txtDensity.TabIndex = 5;
            // 
            // lblViscosity
            // 
            lblViscosity.AutoSize = true;
            lblViscosity.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblViscosity.Location = new Point(70, 280);
            lblViscosity.Name = "lblViscosity";
            lblViscosity.Size = new Size(84, 19);
            lblViscosity.TabIndex = 11;
            lblViscosity.Text = "Вязкость:";
            // 
            // txtViscosity
            // 
            txtViscosity.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtViscosity.Location = new Point(237, 272);
            txtViscosity.Name = "txtViscosity";
            txtViscosity.Size = new Size(323, 27);
            txtViscosity.TabIndex = 6;
            // 
            // lblSulfurContent
            // 
            lblSulfurContent.AutoSize = true;
            lblSulfurContent.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblSulfurContent.Location = new Point(70, 320);
            lblSulfurContent.Name = "lblSulfurContent";
            lblSulfurContent.Size = new Size(154, 19);
            lblSulfurContent.TabIndex = 13;
            lblSulfurContent.Text = "Содержание серы:";
            // 
            // txtSulfurContent
            // 
            txtSulfurContent.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtSulfurContent.Location = new Point(237, 312);
            txtSulfurContent.Name = "txtSulfurContent";
            txtSulfurContent.Size = new Size(323, 27);
            txtSulfurContent.TabIndex = 7;
            // 
            // lblOilfield
            // 
            lblOilfield.AutoSize = true;
            lblOilfield.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblOilfield.Location = new Point(70, 360);
            lblOilfield.Name = "lblOilfield";
            lblOilfield.Size = new Size(137, 19);
            lblOilfield.TabIndex = 15;
            lblOilfield.Text = "Месторождение:";
            // 
            // txtOilfield
            // 
            txtOilfield.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtOilfield.Location = new Point(237, 352);
            txtOilfield.Name = "txtOilfield";
            txtOilfield.Size = new Size(323, 27);
            txtOilfield.TabIndex = 8;
            // 
            // lblRegion
            // 
            lblRegion.AutoSize = true;
            lblRegion.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            lblRegion.Location = new Point(70, 400);
            lblRegion.Name = "lblRegion";
            lblRegion.Size = new Size(66, 19);
            lblRegion.TabIndex = 17;
            lblRegion.Text = "Регион:";
            // 
            // txtRegion
            // 
            txtRegion.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtRegion.Location = new Point(237, 392);
            txtRegion.Name = "txtRegion";
            txtRegion.Size = new Size(323, 27);
            txtRegion.TabIndex = 9;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.SeaGreen;
            btnSave.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(170, 451);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 35);
            btnSave.TabIndex = 10;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.IndianRed;
            btnCancel.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(310, 451);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 35);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // OilLotForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(620, 510);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtRegion);
            Controls.Add(lblRegion);
            Controls.Add(txtOilfield);
            Controls.Add(lblOilfield);
            Controls.Add(txtSulfurContent);
            Controls.Add(lblSulfurContent);
            Controls.Add(txtViscosity);
            Controls.Add(lblViscosity);
            Controls.Add(txtDensity);
            Controls.Add(lblDensity);
            Controls.Add(txtFraction);
            Controls.Add(lblFraction);
            Controls.Add(txtColor);
            Controls.Add(lblColor);
            Controls.Add(dtpExtractionDate);
            Controls.Add(lblExtractionDate);
            Controls.Add(txtLotNumber);
            Controls.Add(lblLotNumber);
            Controls.Add(lblTitle);
            Name = "OilLotForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Партия нефти";
            Load += OilLotForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblLotNumber;
        private TextBox txtLotNumber;
        private Label lblExtractionDate;
        private DateTimePicker dtpExtractionDate;
        private Label lblColor;
        private TextBox txtColor;
        private Label lblFraction;
        private TextBox txtFraction;
        private Label lblDensity;
        private TextBox txtDensity;
        private Label lblViscosity;
        private TextBox txtViscosity;
        private Label lblSulfurContent;
        private TextBox txtSulfurContent;
        private Label lblOilfield;
        private TextBox txtOilfield;
        private Label lblRegion;
        private TextBox txtRegion;
        private Button btnSave;
        private Button btnCancel;
    }
}
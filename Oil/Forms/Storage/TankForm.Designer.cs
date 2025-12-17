namespace Oil
{
    partial class TankForm
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
            dgvTanks = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTanks).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(391, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(380, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Резервуары";
            // 
            // dgvTanks
            // 
            dgvTanks.AllowUserToAddRows = false;
            dgvTanks.AllowUserToDeleteRows = false;
            dgvTanks.BackgroundColor = Color.White;
            dgvTanks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTanks.Location = new Point(60, 106);
            dgvTanks.Name = "dgvTanks";
            dgvTanks.ReadOnly = true;
            dgvTanks.RowHeadersWidth = 51;
            dgvTanks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTanks.Size = new Size(1030, 424);
            dgvTanks.TabIndex = 2;
            dgvTanks.CellDoubleClick += dgvTanks_CellDoubleClick;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.MediumSeaGreen;
            btnAdd.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(60, 550);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(136, 55);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Goldenrod;
            btnEdit.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(274, 550);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(176, 55);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(542, 550);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(136, 55);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightGray;
            btnBack.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnBack.Location = new Point(954, 550);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(136, 55);
            btnBack.TabIndex = 7;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.CadetBlue;
            btnRefresh.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(759, 550);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(136, 55);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // TankForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 630);
            Controls.Add(btnRefresh);
            Controls.Add(btnBack);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvTanks);
            Controls.Add(lblTitle);
            Name = "TankForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Резервуары";
            Load += TankForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTanks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvTanks;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnBack;
        private Button btnRefresh;
    }
}
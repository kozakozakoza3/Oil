namespace Oil.Forms
{
    partial class LaboratoryAnalysisForm
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
            dgvAnalyses = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            btnRefresh = new Button();
            btnPrint = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAnalyses).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(127, 48);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(544, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Лабораторные анализы";
            // 
            // dgvAnalyses
            // 
            dgvAnalyses.AllowUserToAddRows = false;
            dgvAnalyses.AllowUserToDeleteRows = false;
            dgvAnalyses.BackgroundColor = Color.White;
            dgvAnalyses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnalyses.Location = new Point(50, 140);
            dgvAnalyses.Name = "dgvAnalyses";
            dgvAnalyses.ReadOnly = true;
            dgvAnalyses.RowHeadersWidth = 51;
            dgvAnalyses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnalyses.Size = new Size(700, 250);
            dgvAnalyses.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SeaGreen;
            btnAdd.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(35, 420);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 45);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.CadetBlue;
            btnEdit.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(171, 420);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(149, 45);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(330, 420);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 45);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightGray;
            btnBack.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnBack.Location = new Point(620, 420);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(130, 45);
            btnBack.TabIndex = 7;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.CadetBlue;
            btnRefresh.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(470, 420);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(140, 45);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.SteelBlue;
            btnPrint.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(470, 420);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(140, 45);
            btnPrint.TabIndex = 8;
            btnPrint.Text = "Печать";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // LaboratoryAnalysisForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 500);
            Controls.Add(btnPrint);
            Controls.Add(btnRefresh);
            Controls.Add(btnBack);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvAnalyses);
            Controls.Add(lblTitle);
            Name = "LaboratoryAnalysisForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Лабораторные анализы";
            Load += LaboratoryAnalysisForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAnalyses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private DataGridView dgvAnalyses;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnBack;
        private Button btnRefresh;
        private Button btnPrint;
    }
}
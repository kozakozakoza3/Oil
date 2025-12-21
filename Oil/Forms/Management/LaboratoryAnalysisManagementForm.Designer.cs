namespace Oil.Forms.Management
{
    partial class LaboratoryAnalysisManagementForm
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
            btnBack = new Button();
            btnRefresh = new Button();
            btnPrint = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAnalyses).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Constantia", 36F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(200, 30);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(738, 73);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Лабораторные анализы";
            // 
            // dgvAnalyses
            // 
            dgvAnalyses.AllowUserToAddRows = false;
            dgvAnalyses.AllowUserToDeleteRows = false;
            dgvAnalyses.BackgroundColor = Color.White;
            dgvAnalyses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnalyses.Location = new Point(51, 106);
            dgvAnalyses.Name = "dgvAnalyses";
            dgvAnalyses.ReadOnly = true;
            dgvAnalyses.RowHeadersWidth = 51;
            dgvAnalyses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnalyses.Size = new Size(1054, 408);
            dgvAnalyses.TabIndex = 2;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.LightGray;
            btnBack.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnBack.Location = new Point(713, 520);
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
            btnRefresh.Location = new Point(287, 520);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(136, 55);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.SteelBlue;
            btnPrint.Font = new Font("Constantia", 12F, FontStyle.Bold);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(496, 520);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(136, 55);
            btnPrint.TabIndex = 8;
            btnPrint.Text = "Печать";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // LaboratoryAnalysisManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1150, 600);
            Controls.Add(btnPrint);
            Controls.Add(btnRefresh);
            Controls.Add(btnBack);
            Controls.Add(dgvAnalyses);
            Controls.Add(lblTitle);
            Name = "LaboratoryAnalysisManagementForm";
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
        private Button btnBack;
        private Button btnRefresh;
        private Button btnPrint;
    }
}
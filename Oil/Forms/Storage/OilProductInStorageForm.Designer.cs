namespace Oil
{
    partial class OilProductInStorageForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblInfo;
        private DataGridView dgvOilProducts;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnBack;
        private Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblInfo = new Label();
            dgvOilProducts = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnBack = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOilProducts).BeginInit();
            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = false;
            lblTitle.Font = new Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(0, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Партии нефтепродуктов на складе";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblInfo
            lblInfo.AutoSize = false;
            lblInfo.Font = new Font("Constantia", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblInfo.Location = new Point(0, 84);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(800, 24);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "Список партий нефтепродуктов, находящихся на складе";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;

            // dgvOilProducts
            dgvOilProducts.AllowUserToAddRows = false;
            dgvOilProducts.AllowUserToDeleteRows = false;
            dgvOilProducts.BackgroundColor = Color.White;
            dgvOilProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOilProducts.Location = new Point(50, 130);
            dgvOilProducts.Name = "dgvOilProducts";
            dgvOilProducts.ReadOnly = true;
            dgvOilProducts.RowHeadersWidth = 51;
            dgvOilProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOilProducts.Size = new Size(700, 250);
            dgvOilProducts.TabIndex = 2;

            // btnAdd
            btnAdd.BackColor = Color.SeaGreen;
            btnAdd.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(50, 410);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(130, 45);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;

            // btnEdit
            btnEdit.BackColor = Color.CadetBlue;
            btnEdit.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(186, 410);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(130, 45);
            btnEdit.TabIndex = 4;
            btnEdit.Text = "Изменить";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;

            // btnDelete
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(322, 410);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 45);
            btnDelete.TabIndex = 5;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;

            // btnRefresh
            btnRefresh.BackColor = Color.CadetBlue;
            btnRefresh.Font = new Font("Constantia", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(458, 410);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 45);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;

            // btnBack
            btnBack.BackColor = Color.LightGray;
            btnBack.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            btnBack.Location = new Point(620, 410);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(130, 45);
            btnBack.TabIndex = 7;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;

            // OilProductInStorageForm
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 500);
            Controls.Add(btnBack);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvOilProducts);
            Controls.Add(lblInfo);
            Controls.Add(lblTitle);
            Name = "OilProductInStorageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Oil System - Партии нефтепродуктов на складе";
            Load += OilProductInStorageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOilProducts).EndInit();
            ResumeLayout(false);
        }
    }
}
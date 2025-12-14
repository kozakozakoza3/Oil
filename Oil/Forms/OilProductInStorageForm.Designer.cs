namespace Oil
{
    partial class OilProductInStorageForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgvOilProducts;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private Button btnBack;

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
            dgvOilProducts = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOilProducts).BeginInit();
            SuspendLayout();

            // lblTitle
            lblTitle.Font = new Font("Microsoft Sans Serif", 16F);
            lblTitle.Location = new Point(0, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(800, 40);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Партии нефтепродуктов на складе";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // dgvOilProducts
            dgvOilProducts.Location = new Point(20, 60);
            dgvOilProducts.Name = "dgvOilProducts";
            dgvOilProducts.Size = new Size(760, 300);
            dgvOilProducts.TabIndex = 1;

            // btnAdd
            btnAdd.Location = new Point(20, 380);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 30);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // btnEdit
            btnEdit.Location = new Point(130, 380);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 30);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Изменить";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;

            // btnDelete
            btnDelete.Location = new Point(240, 380);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 30);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            // btnRefresh
            btnRefresh.Location = new Point(350, 380);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;

            // btnBack
            btnBack.Location = new Point(680, 380);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(100, 30);
            btnBack.TabIndex = 6;
            btnBack.Text = "Назад";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;

            // OilProductInStorageForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnBack);
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvOilProducts);
            Controls.Add(lblTitle);
            Name = "OilProductInStorageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Партии нефтепродуктов на складе";
            Load += OilProductInStorageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOilProducts).EndInit();
            ResumeLayout(false);
        }
    }
}
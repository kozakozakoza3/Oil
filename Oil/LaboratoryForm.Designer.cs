namespace Oil
{
    partial class LaboratoryForm
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
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnRefresh = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            mainTabControl = new TabControl();
            tabOil = new TabPage();
            oilGridView = new DataGridView();
            tabProducts = new TabPage();
            productsGridView = new DataGridView();
            tabAnalysis = new TabPage();
            analysisGridView = new DataGridView();
            mainTabControl.SuspendLayout();
            tabOil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)oilGridView).BeginInit();
            tabProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productsGridView).BeginInit();
            tabAnalysis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)analysisGridView).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Arial", 16F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblTitle.Location = new Point(50, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(730, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ЛАБОРАТОРНЫЙ УЧЕТ НЕФТИ И НЕФТЕПРОДУКТОВ";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            txtSearch.Location = new Point(50, 70);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Поиск...";
            txtSearch.Size = new Size(300, 27);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.CadetBlue;
            btnSearch.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(360, 70);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 27);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Найти";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.LightSeaGreen;
            btnRefresh.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(450, 70);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(105, 27);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Обновить";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.SeaGreen;
            btnAdd.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(563, 69);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(107, 27);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.SteelBlue;
            btnEdit.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(676, 69);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(108, 27);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Изменить";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, 204);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(790, 69);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 27);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // mainTabControl
            // 
            mainTabControl.Controls.Add(tabOil);
            mainTabControl.Controls.Add(tabProducts);
            mainTabControl.Controls.Add(tabAnalysis);
            mainTabControl.Font = new Font("Arial", 10F, FontStyle.Regular, GraphicsUnit.Point, 204);
            mainTabControl.Location = new Point(50, 110);
            mainTabControl.Name = "mainTabControl";
            mainTabControl.SelectedIndex = 0;
            mainTabControl.Size = new Size(900, 500);
            mainTabControl.TabIndex = 7;
            // 
            // tabOil
            // 
            tabOil.Controls.Add(oilGridView);
            tabOil.Location = new Point(4, 28);
            tabOil.Name = "tabOil";
            tabOil.Padding = new Padding(3);
            tabOil.Size = new Size(892, 468);
            tabOil.TabIndex = 0;
            tabOil.Text = "Нефть";
            tabOil.UseVisualStyleBackColor = true;
            // 
            // oilGridView
            // 
            oilGridView.AllowUserToAddRows = false;
            oilGridView.AllowUserToDeleteRows = false;
            oilGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            oilGridView.BackgroundColor = SystemColors.Window;
            oilGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            oilGridView.Dock = DockStyle.Fill;
            oilGridView.Location = new Point(3, 3);
            oilGridView.Name = "oilGridView";
            oilGridView.ReadOnly = true;
            oilGridView.RowHeadersWidth = 51;
            oilGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            oilGridView.Size = new Size(886, 462);
            oilGridView.TabIndex = 0;
            oilGridView.CellDoubleClick += oilGridView_CellDoubleClick;
            // 
            // tabProducts
            // 
            tabProducts.Controls.Add(productsGridView);
            tabProducts.Location = new Point(4, 28);
            tabProducts.Name = "tabProducts";
            tabProducts.Padding = new Padding(3);
            tabProducts.Size = new Size(892, 468);
            tabProducts.TabIndex = 1;
            tabProducts.Text = "Нефтепродукты";
            tabProducts.UseVisualStyleBackColor = true;
            // 
            // productsGridView
            // 
            productsGridView.AllowUserToAddRows = false;
            productsGridView.AllowUserToDeleteRows = false;
            productsGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            productsGridView.BackgroundColor = SystemColors.Window;
            productsGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productsGridView.Dock = DockStyle.Fill;
            productsGridView.Location = new Point(3, 3);
            productsGridView.Name = "productsGridView";
            productsGridView.ReadOnly = true;
            productsGridView.RowHeadersWidth = 51;
            productsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            productsGridView.Size = new Size(886, 462);
            productsGridView.TabIndex = 0;
            productsGridView.CellDoubleClick += productsGridView_CellDoubleClick;
            // 
            // tabAnalysis
            // 
            tabAnalysis.Controls.Add(analysisGridView);
            tabAnalysis.Location = new Point(4, 28);
            tabAnalysis.Name = "tabAnalysis";
            tabAnalysis.Padding = new Padding(3);
            tabAnalysis.Size = new Size(892, 468);
            tabAnalysis.TabIndex = 2;
            tabAnalysis.Text = "Лабораторные анализы";
            tabAnalysis.UseVisualStyleBackColor = true;
            // 
            // analysisGridView
            // 
            analysisGridView.AllowUserToAddRows = false;
            analysisGridView.AllowUserToDeleteRows = false;
            analysisGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            analysisGridView.BackgroundColor = SystemColors.Window;
            analysisGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            analysisGridView.Dock = DockStyle.Fill;
            analysisGridView.Location = new Point(3, 3);
            analysisGridView.Name = "analysisGridView";
            analysisGridView.ReadOnly = true;
            analysisGridView.RowHeadersWidth = 51;
            analysisGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            analysisGridView.Size = new Size(886, 462);
            analysisGridView.TabIndex = 0;
            analysisGridView.CellDoubleClick += analysisGridView_CellDoubleClick;
            // 
            // LaboratoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1000, 650);
            Controls.Add(mainTabControl);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(btnRefresh);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblTitle);
            Name = "LaboratoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Лабораторная система";
            Load += LaboratoryForm_Load;
            mainTabControl.ResumeLayout(false);
            tabOil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)oilGridView).EndInit();
            tabProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)productsGridView).EndInit();
            tabAnalysis.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)analysisGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private TabControl mainTabControl;
        private TabPage tabOil;
        private DataGridView oilGridView;
        private TabPage tabProducts;
        private DataGridView productsGridView;
        private TabPage tabAnalysis;
        private DataGridView analysisGridView;
    }
}
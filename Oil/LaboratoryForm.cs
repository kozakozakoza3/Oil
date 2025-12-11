using Oil.Models;
using Oil.Helpers;
using System;
using System.Data;
using System.Windows.Forms;


namespace Oil
{
    public partial class LaboratoryForm : Form
    {
        public string Login { get; internal set; }

        public LaboratoryForm()
        {
            InitializeComponent();
        }

        private void LaboratoryForm_Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        // Загрузка всех данных
        private void LoadAllData()
        {
            try
            {
                oilGridView.DataSource = DbMethods.GetAll("oil_lot");
                productsGridView.DataSource = DbMethods.GetAll("oil_products");
                analysisGridView.DataSource = DbMethods.GetAll("laboratory_analysis");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обновить данные
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAllData();
            txtSearch.Text = "";
        }

        // Поиск
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Введите текст для поиска", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string query = "";
                switch (mainTabControl.SelectedIndex)
                {
                    case 0: // Нефть
                        query = $"SELECT * FROM oil_lot WHERE " +
                               $"lot_number ILIKE '%{searchText}%' OR " +
                               $"oilfield ILIKE '%{searchText}%' OR " +
                               $"region ILIKE '%{searchText}%'";
                        oilGridView.DataSource = DbMethods.GetData(query);
                        break;
                    case 1: // Нефтепродукты
                        query = $"SELECT * FROM oil_products WHERE " +
                               $"name ILIKE '%{searchText}%' OR " +
                               $"mark ILIKE '%{searchText}%' OR " +
                               $"application ILIKE '%{searchText}%'";
                        productsGridView.DataSource = DbMethods.GetData(query);
                        break;
                    case 2: // Анализы
                        query = $"SELECT * FROM laboratory_analysis WHERE " +
                               $"product_name ILIKE '%{searchText}%' OR " +
                               $"analyst ILIKE '%{searchText}%'";
                        analysisGridView.DataSource = DbMethods.GetData(query);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка поиска: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Добавить запись
        private void btnAdd_Click(object sender, EventArgs e)
        {
            switch (mainTabControl.SelectedIndex)
            {
                case 0: // Нефть
                    using (var form = new OilLotForm())
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadAllData();
                        }
                    }
                    break;
                case 1: // Нефтепродукты
                    using (var form = new OilProductForm())
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadAllData();
                        }
                    }
                    break;
                case 2: // Анализы
                    using (var form = new LaboratoryAnalysisForm())
                    {
                        form.Analyst = Login;
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            LoadAllData();
                        }
                    }
                    break;
            }
        }

        // Редактировать запись
        private void btnEdit_Click(object sender, EventArgs e)
        {
            switch (mainTabControl.SelectedIndex)
            {
                case 0: // Нефть
                    if (oilGridView.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Выберите запись для редактирования", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    EditOilLot();
                    break;
                case 1: // Нефтепродукты
                    if (productsGridView.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Выберите запись для редактирования", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    EditOilProduct();
                    break;
                case 2: // Анализы
                    if (analysisGridView.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Выберите запись для редактирования", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    EditLaboratoryAnalysis();
                    break;
            }
        }

        // Удалить запись
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить выбранную запись?", "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                switch (mainTabControl.SelectedIndex)
                {
                    case 0: // Нефть
                        if (oilGridView.SelectedRows.Count == 0) return;
                        var oilRow = (DataRowView)oilGridView.SelectedRows[0].DataBoundItem;
                        int oilId = Convert.ToInt32(oilRow["oil_lot_id"]);
                        if (DbMethods.Delete("oil_lot", oilId))
                            LoadAllData();
                        break;
                    case 1: // Нефтепродукты
                        if (productsGridView.SelectedRows.Count == 0) return;
                        var productRow = (DataRowView)productsGridView.SelectedRows[0].DataBoundItem;
                        int productId = Convert.ToInt32(productRow["oil_product_id"]);
                        if (DbMethods.Delete("oil_products", productId))
                            LoadAllData();
                        break;
                    case 2: // Анализы
                        if (analysisGridView.SelectedRows.Count == 0) return;
                        var analysisRow = (DataRowView)analysisGridView.SelectedRows[0].DataBoundItem;
                        int analysisId = Convert.ToInt32(analysisRow["analysis_id"]);
                        if (DbMethods.Delete("laboratory_analysis", analysisId))
                            LoadAllData();
                        break;
                }
            }
        }

        // Редактирование партии нефти
        private void EditOilLot()
        {
            var row = (DataRowView)oilGridView.SelectedRows[0].DataBoundItem;
            var oilLot = new OilLot
            {
                Id = Convert.ToInt32(row["oil_lot_id"]),
                LotNumber = row["lot_number"].ToString(),
                ExtractionDate = Convert.ToDateTime(row["extraction_date"]),
                Color = row["color"].ToString(),
                Fraction = row["fraction"].ToString(),
                Density = row["density"].ToString(),
                Viscosity = row["viscosity"].ToString(),
                SulfurContent = row["sulfur_content"].ToString(),
                Oilfield = row["oilfield"].ToString(),
                Region = row["region"].ToString()
            };

            using (var form = new OilLotForm())
            {
                form.OilLot = oilLot;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllData();
                }
            }
        }

        // Редактирование нефтепродукта
        private void EditOilProduct()
        {
            var row = (DataRowView)productsGridView.SelectedRows[0].DataBoundItem;
            var product = new OilProduct
            {
                Id = Convert.ToInt32(row["oil_product_id"]),
                Name = row["name"].ToString(),
                Mark = row["mark"].ToString(),
                Application = row["application"].ToString(),
                DangerClass = row["danger_class"].ToString(),
                Fraction = row["fraction"].ToString(),
                ManufactureDate = Convert.ToDateTime(row["manufacture_date"]),
                ExpirationDate = Convert.ToDateTime(row["expiration_date"])
            };

            using (var form = new OilProductForm())
            {
                form.OilProduct = product;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllData();
                }
            }
        }

        // Редактирование анализа
        private void EditLaboratoryAnalysis()
        {
            var row = (DataRowView)analysisGridView.SelectedRows[0].DataBoundItem;
            var analysis = new LaboratoryAnalysis
            {
                Id = Convert.ToInt32(row["analysis_id"]),
                ProductName = row["product_name"].ToString(),
                Analyst = row["analyst"].ToString(),
                Density = Convert.ToDouble(row["density"]),
                SulfurContent = Convert.ToDouble(row["sulfur_content"]),
                WaterContent = row["water_content"] != DBNull.Value ? Convert.ToDouble(row["water_content"]) : (double?)null,
                Viscosity = Convert.ToDouble(row["viscosity"]),
                FlashPoint = Convert.ToInt32(row["flash_point"]),
                AnalysisDate = Convert.ToDateTime(row["analysis_date"])
            };

            using (var form = new LaboratoryAnalysisForm())
            {
                form.Analysis = analysis;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadAllData();
                }
            }
        }

        // Двойной клик для редактирования
        private void oilGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnEdit.PerformClick();
        }

        private void productsGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnEdit.PerformClick();
        }

        private void analysisGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) btnEdit.PerformClick();
        }

        // Поиск по Enter
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.Handled = true;
            }
        }
    }
}

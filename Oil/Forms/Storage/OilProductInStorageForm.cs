using System;
using System.Data;
using System.Windows.Forms;
using Oil.Helpers;

namespace Oil
{
    public partial class OilProductInStorageForm : Form
    {
        public OilProductInStorageForm()
        {
            InitializeComponent();
        }

        private void LoadOilProductsInStorage()
        {
            try
            {
                string query = @"
                    SELECT 
                        opl.oil_product_lot_id,
                        opn.product_name,
                        m.mark_name,
                        opl.lot_size || ' ' || opl.unit_of_measure as lot_size,
                        opl.date_time_formation_lot,
                        op.manufacture_date,
                        op.expiration_date
                    FROM oil_product_lot opl
                    JOIN oil_product op ON opl.oil_product_id = op.oil_product_id
                    JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
                    JOIN mark m ON op.mark_id = m.mark_id
                    ORDER BY opn.product_name";

                DataTable dt = DbMethods.GetData(query);
                dgvOilProducts.DataSource = dt;

                // Простые настройки таблицы
                if (dgvOilProducts.Columns.Count > 0)
                {
                    dgvOilProducts.Columns["oil_product_lot_id"].HeaderText = "Номер";
                    dgvOilProducts.Columns["product_name"].HeaderText = "Продукт";
                    dgvOilProducts.Columns["mark_name"].HeaderText = "Марка";
                    dgvOilProducts.Columns["lot_size"].HeaderText = "Объем партии";
                    dgvOilProducts.Columns["date_time_formation_lot"].HeaderText = "Дата формирования";
                    dgvOilProducts.Columns["manufacture_date"].HeaderText = "Дата производства";
                    dgvOilProducts.Columns["expiration_date"].HeaderText = "Срок годности";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void OilProductInStorageForm_Load(object sender, EventArgs e)
        {
            LoadOilProductsInStorage();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OilProductInStorageEditForm editForm = new OilProductInStorageEditForm();
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadOilProductsInStorage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOilProducts.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvOilProducts.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["oil_product_lot_id"].Value);

                    OilProductInStorageEditForm editForm = new OilProductInStorageEditForm(id);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadOilProductsInStorage();
                    }
                }
                else
                {
                    MessageBox.Show("Сначала выберите запись");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOilProducts.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvOilProducts.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["oil_product_lot_id"].Value);
                    string productName = row.Cells["product_name"].Value.ToString();

                    DialogResult result = MessageBox.Show(
                        $"Удалить партию продукта {productName}?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo
                    );

                    if (result == DialogResult.Yes)
                    {
                        bool success = DbMethods.Delete("oil_product_lot", id);
                        if (success)
                        {
                            MessageBox.Show("Партия удалена");
                            LoadOilProductsInStorage();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Сначала выберите запись");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOilProductsInStorage();
        }
    }
}
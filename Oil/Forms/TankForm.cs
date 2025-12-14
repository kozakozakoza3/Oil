using System;
using System.Data;
using System.Windows.Forms;
using Oil.Helpers;

namespace Oil
{
    public partial class TankForm : Form
    {
        public TankForm()
        {
            InitializeComponent();
        }

        private void LoadTanks()
        {
            try
            {
                string query = @"
                    SELECT 
                        t.tank_id,
                        t.tank_capacity || ' ' || t.unit_of_measure as capacity,
                        tm.material_name,
                        opn.product_name
                    FROM tank t
                    LEFT JOIN tank_material tm ON t.tank_material_id = tm.tank_material_id
                    LEFT JOIN oil_product op ON t.oil_product_id = op.oil_product_id
                    LEFT JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
                    ORDER BY t.tank_id";

                DataTable dt = DbMethods.GetData(query);
                dgvTanks.DataSource = dt;

                // Простые настройки таблицы
                if (dgvTanks.Columns.Count > 0)
                {
                    dgvTanks.Columns["tank_id"].HeaderText = "Номер";
                    dgvTanks.Columns["capacity"].HeaderText = "Емкость";
                    dgvTanks.Columns["material_name"].HeaderText = "Материал";
                    dgvTanks.Columns["product_name"].HeaderText = "Продукт";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void TankForm_Load(object sender, EventArgs e)
        {
            LoadTanks();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                TankEditForm editForm = new TankEditForm();
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTanks();
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
                if (dgvTanks.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvTanks.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["tank_id"].Value);

                    TankEditForm editForm = new TankEditForm(id);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadTanks();
                    }
                }
                else
                {
                    MessageBox.Show("Сначала выберите резервуар");
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
                if (dgvTanks.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvTanks.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["tank_id"].Value);

                    DialogResult result = MessageBox.Show(
                        "Удалить этот резервуар?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo
                    );

                    if (result == DialogResult.Yes)
                    {
                        bool success = DbMethods.Delete("tank", id);
                        if (success)
                        {
                            MessageBox.Show("Резервуар удален");
                            LoadTanks();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Сначала выберите резервуар");
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
            LoadTanks();
        }
    }
}
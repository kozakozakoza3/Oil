using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using Oil.Helpers;
using Oil.Models;

namespace Oil
{
    partial class TankForm : Form
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
                        s.storage_id,
                        opn.product_name,
                        op.manufacture_date,
                        op.expiration_date
                    FROM tank t
                    LEFT JOIN tank_material tm ON t.tank_material_id = tm.tank_material_id
                    LEFT JOIN storage s ON t.storage_id = s.storage_id
                    LEFT JOIN oil_product op ON t.oil_product_id = op.oil_product_id
                    LEFT JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
                    ORDER BY t.tank_id";

                DataTable dt = DbMethods.GetData(query);
                dgvTanks.DataSource = dt;

                // Настройка заголовков колонок
                if (dgvTanks.Columns.Count > 0)
                {
                    dgvTanks.Columns["tank_id"].Visible = false; // Скрываем ID
                    dgvTanks.Columns["capacity"].HeaderText = "Емкость";
                    dgvTanks.Columns["material_name"].HeaderText = "Материал";
                    dgvTanks.Columns["storage_id"].HeaderText = "Хранилище";
                    dgvTanks.Columns["product_name"].HeaderText = "Нефтепродукт";
                    dgvTanks.Columns["manufacture_date"].HeaderText = "Дата производства";
                    dgvTanks.Columns["expiration_date"].HeaderText = "Срок годности";

                    // Настройка ширины колонок
                    dgvTanks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Форматирование дат
                    dgvTanks.Columns["manufacture_date"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    dgvTanks.Columns["expiration_date"].DefaultCellStyle.Format = "dd.MM.yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TankForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadTanks();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке формы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show($"Ошибка при добавлении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Выберите запись для редактирования", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string capacity = row.Cells["capacity"].Value?.ToString() ?? "неизвестно";

                    var result = MessageBox.Show($"Вы уверены, что хотите удалить резервуар ({capacity})?",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Проверяем, есть ли связанные записи
                        string checkQuery = $"SELECT COUNT(*) FROM oil_lot_in_tank WHERE tank_id = {id}";
                        DataTable dt = DbMethods.GetData(checkQuery);
                        int count = Convert.ToInt32(dt.Rows[0][0]);

                        if (count > 0)
                        {
                            MessageBox.Show("Невозможно удалить резервуар, так как в нем находятся партии нефти!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        bool success = DbMethods.Delete("tank", id);
                        if (success)
                        {
                            MessageBox.Show("Резервуар успешно удален", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadTanks();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите запись для удаления", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvTanks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }
    }
}
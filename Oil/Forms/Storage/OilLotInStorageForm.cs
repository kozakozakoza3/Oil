using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using Oil.Helpers;
using Oil.Models;

namespace Oil
{
    partial class OilLotInStorageForm : Form
    {
        public OilLotInStorageForm()
        {
            InitializeComponent();
        }

        private void LoadOilLotsInStorage()
        {
            try
            {
                string query = @"
                    SELECT 
                        olt.oil_lot_in_tank_id,
                        ol.number_of_oil_lot,
                        ol.date_of_extraction,
                        nof.oilfield_name,
                        r.region_name,
                        t.tank_id,
                        t.tank_capacity || ' ' || t.unit_of_measure as tank_capacity,
                        olt.oil_lot_size || ' ' || olt.unit_of_measure as lot_size
                    FROM oil_lot_in_tank olt
                    JOIN oil_lot ol ON olt.oil_lot_id = ol.oil_lot_id
                    JOIN oilfield o ON ol.oilfield_id = o.oilfield_id
                    JOIN name_of_oilfield nof ON o.name_of_oilfield_id = nof.name_of_oilfield_id
                    JOIN region r ON o.region_id = r.region_id
                    JOIN tank t ON olt.tank_id = t.tank_id
                    ORDER BY ol.number_of_oil_lot";

                DataTable dt = DbMethods.GetData(query);
                dgvOilLots.DataSource = dt;

                // Настройка заголовков колонок
                if (dgvOilLots.Columns.Count > 0)
                {
                    dgvOilLots.Columns["oil_lot_in_tank_id"].Visible = false; // Скрываем ID
                    dgvOilLots.Columns["number_of_oil_lot"].HeaderText = "Номер партии";
                    dgvOilLots.Columns["date_of_extraction"].HeaderText = "Дата добычи";
                    dgvOilLots.Columns["oilfield_name"].HeaderText = "Месторождение";
                    dgvOilLots.Columns["region_name"].HeaderText = "Регион";
                    dgvOilLots.Columns["tank_id"].HeaderText = "Номер резервуара";
                    dgvOilLots.Columns["tank_capacity"].HeaderText = "Емкость резервуара";
                    dgvOilLots.Columns["lot_size"].HeaderText = "Объем в резервуаре";

                    // Настройка ширины колонок
                    dgvOilLots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Форматирование даты
                    dgvOilLots.Columns["date_of_extraction"].DefaultCellStyle.Format = "dd.MM.yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OilLotInStorageForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadOilLotsInStorage();
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
                OilLotInStorageEditForm editForm = new OilLotInStorageEditForm();
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadOilLotsInStorage();
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
                if (dgvOilLots.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvOilLots.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["oil_lot_in_tank_id"].Value);

                    OilLotInStorageEditForm editForm = new OilLotInStorageEditForm(id);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadOilLotsInStorage();
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
                if (dgvOilLots.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvOilLots.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["oil_lot_in_tank_id"].Value);
                    string lotNumber = row.Cells["number_of_oil_lot"].Value.ToString();

                    var result = MessageBox.Show($"Вы уверены, что хотите удалить партию {lotNumber} из резервуара?",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bool success = DbMethods.Delete("oil_lot_in_tank", id);
                        if (success)
                        {
                            MessageBox.Show("Партия успешно удалена из резервуара", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOilLotsInStorage();
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
            LoadOilLotsInStorage();
        }

        private void dgvOilLots_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }
    }
}
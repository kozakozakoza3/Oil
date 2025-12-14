using System;
using System.Data;
using System.Windows.Forms;
using Oil.Helpers;

namespace Oil
{
    public partial class OilLotInStorageForm : Form
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
                        t.tank_id,
                        t.tank_capacity || ' ' || t.unit_of_measure as tank_info,
                        olt.oil_lot_size || ' ' || olt.unit_of_measure as lot_size
                    FROM oil_lot_in_tank olt
                    JOIN oil_lot ol ON olt.oil_lot_id = ol.oil_lot_id
                    JOIN tank t ON olt.tank_id = t.tank_id
                    ORDER BY ol.number_of_oil_lot";

                DataTable dt = DbMethods.GetData(query);
                dgvOilLots.DataSource = dt;

                // Простые настройки таблицы
                if (dgvOilLots.Columns.Count > 0)
                {
                    dgvOilLots.Columns["oil_lot_in_tank_id"].HeaderText = "Номер";
                    dgvOilLots.Columns["number_of_oil_lot"].HeaderText = "Номер партии";
                    dgvOilLots.Columns["date_of_extraction"].HeaderText = "Дата добычи";
                    dgvOilLots.Columns["tank_id"].HeaderText = "Резервуар";
                    dgvOilLots.Columns["tank_info"].HeaderText = "Емкость резервуара";
                    dgvOilLots.Columns["lot_size"].HeaderText = "Объем в резервуаре";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
            }
        }

        private void OilLotInStorageForm_Load(object sender, EventArgs e)
        {
            LoadOilLotsInStorage();
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
                MessageBox.Show("Ошибка: " + ex.Message);
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
                if (dgvOilLots.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvOilLots.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["oil_lot_in_tank_id"].Value);
                    string lotNumber = row.Cells["number_of_oil_lot"].Value.ToString();

                    DialogResult result = MessageBox.Show(
                        $"Удалить партию {lotNumber} из резервуара?",
                        "Подтверждение",
                        MessageBoxButtons.YesNo
                    );

                    if (result == DialogResult.Yes)
                    {
                        bool success = DbMethods.Delete("oil_lot_in_tank", id);
                        if (success)
                        {
                            MessageBox.Show("Запись удалена");
                            LoadOilLotsInStorage();
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
            LoadOilLotsInStorage();
        }
    }
}
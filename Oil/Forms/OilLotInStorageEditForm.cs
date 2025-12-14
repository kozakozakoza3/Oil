using System;
using System.Data;
using System.Windows.Forms;
using Oil.Helpers;

namespace Oil
{
    public partial class OilLotInStorageEditForm : Form
    {
        private int recordId = -1; // -1 = новый

        public OilLotInStorageEditForm()
        {
            InitializeComponent();
            Text = "Новая запись";
        }

        public OilLotInStorageEditForm(int id)
        {
            InitializeComponent();
            recordId = id;
            Text = "Изменение записи";
        }

        private void OilLotInStorageEditForm_Load(object sender, EventArgs e)
        {
            LoadData();

            if (recordId != -1)
            {
                LoadRecordInfo();
            }
        }

        private void LoadData()
        {
            try
            {
                // Партии нефти
                DataTable oilLots = DbMethods.GetData("SELECT oil_lot_id, number_of_oil_lot FROM oil_lot");
                cbOilLot.DataSource = oilLots;
                cbOilLot.DisplayMember = "number_of_oil_lot";
                cbOilLot.ValueMember = "oil_lot_id";

                // Резервуары
                DataTable tanks = DbMethods.GetData("SELECT tank_id, tank_id || ' (' || tank_capacity || ')' as info FROM tank");
                cbTank.DataSource = tanks;
                cbTank.DisplayMember = "info";
                cbTank.ValueMember = "tank_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }

        private void LoadRecordInfo()
        {
            try
            {
                string query = $"SELECT * FROM oil_lot_in_tank WHERE oil_lot_in_tank_id = {recordId}";
                DataTable dt = DbMethods.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtSize.Text = row["oil_lot_size"].ToString();
                    txtUnit.Text = row["unit_of_measure"].ToString();

                    // Простой выбор в комбобоксах
                    SelectComboBoxValue(cbOilLot, row["oil_lot_id"]);
                    SelectComboBoxValue(cbTank, row["tank_id"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }

        private void SelectComboBoxValue(ComboBox cb, object value)
        {
            try
            {
                for (int i = 0; i < cb.Items.Count; i++)
                {
                    DataRowView item = (DataRowView)cb.Items[i];
                    if (item.Row[0].ToString() == value.ToString())
                    {
                        cb.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch
            {
                // Игнорируем ошибки
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Простые проверки
                if (txtSize.Text == "")
                {
                    MessageBox.Show("Введите объем");
                    return;
                }

                if (cbOilLot.SelectedIndex < 0 || cbTank.SelectedIndex < 0)
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }

                int size = Convert.ToInt32(txtSize.Text);
                string unit = txtUnit.Text;
                int oilLotId = Convert.ToInt32(cbOilLot.SelectedValue);
                int tankId = Convert.ToInt32(cbTank.SelectedValue);

                string sql;
                if (recordId == -1)
                {
                    // Добавление
                    sql = $@"
                        INSERT INTO oil_lot_in_tank (oil_lot_id, tank_id, oil_lot_size, unit_of_measure)
                        VALUES ({oilLotId}, {tankId}, {size}, '{unit}')";
                }
                else
                {
                    // Обновление
                    sql = $@"
                        UPDATE oil_lot_in_tank SET
                            oil_lot_id = {oilLotId},
                            tank_id = {tankId},
                            oil_lot_size = {size},
                            unit_of_measure = '{unit}'
                        WHERE oil_lot_in_tank_id = {recordId}";
                }

                bool result = DbMethods.Execute(sql);
                if (result)
                {
                    MessageBox.Show("Сохранено успешно");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
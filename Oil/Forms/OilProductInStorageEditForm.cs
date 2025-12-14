using System;
using System.Data;
using System.Windows.Forms;
using Oil.Helpers;

namespace Oil
{
    public partial class OilProductInStorageEditForm : Form
    {
        private int recordId = -1; // -1 = новый

        public OilProductInStorageEditForm()
        {
            InitializeComponent();
            Text = "Новая партия";
        }

        public OilProductInStorageEditForm(int id)
        {
            InitializeComponent();
            recordId = id;
            Text = "Изменение партии";
        }

        private void OilProductInStorageEditForm_Load(object sender, EventArgs e)
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
                // Нефтепродукты
                DataTable products = DbMethods.GetData(@"
                    SELECT op.oil_product_id, 
                           opn.product_name || ' (' || m.mark_name || ')' as display_name
                    FROM oil_product op
                    JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
                    JOIN mark m ON op.mark_id = m.mark_id
                    ORDER BY opn.product_name");

                cbProduct.DataSource = products;
                cbProduct.DisplayMember = "display_name";
                cbProduct.ValueMember = "oil_product_id";
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
                string query = $"SELECT * FROM oil_product_lot WHERE oil_product_lot_id = {recordId}";
                DataTable dt = DbMethods.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtSize.Text = row["lot_size"].ToString();
                    txtUnit.Text = row["unit_of_measure"].ToString();

                    DateTime date;
                    if (DateTime.TryParse(row["date_time_formation_lot"].ToString(), out date))
                    {
                        dtpFormationDate.Value = date;
                    }

                    // Простой выбор в комбобоксе
                    SelectComboBoxValue(cbProduct, row["oil_product_id"]);
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

                if (cbProduct.SelectedIndex < 0)
                {
                    MessageBox.Show("Выберите продукт");
                    return;
                }

                int size = Convert.ToInt32(txtSize.Text);
                string unit = txtUnit.Text;
                string date = dtpFormationDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                int productId = Convert.ToInt32(cbProduct.SelectedValue);

                string sql;
                if (recordId == -1)
                {
                    // Добавление
                    sql = $@"
                        INSERT INTO oil_product_lot (oil_product_id, date_time_formation_lot, lot_size, unit_of_measure)
                        VALUES ({productId}, '{date}', {size}, '{unit}')";
                }
                else
                {
                    // Обновление
                    sql = $@"
                        UPDATE oil_product_lot SET
                            oil_product_id = {productId},
                            date_time_formation_lot = '{date}',
                            lot_size = {size},
                            unit_of_measure = '{unit}'
                        WHERE oil_product_lot_id = {recordId}";
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
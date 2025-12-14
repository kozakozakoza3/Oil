using System;
using System.Data;
using System.Windows.Forms;
using Oil.Helpers;

namespace Oil
{
    public partial class TankEditForm : Form
    {
        private int tankId = -1; // -1 = новый

        public TankEditForm()
        {
            InitializeComponent();
            Text = "Новый резервуар";
        }

        public TankEditForm(int id)
        {
            InitializeComponent();
            tankId = id;
            Text = "Изменение резервуара";
        }

        private void TankEditForm_Load(object sender, EventArgs e)
        {
            LoadData();

            if (tankId != -1)
            {
                LoadTankInfo();
            }
        }

        private void LoadData()
        {
            try
            {
                // Материалы
                DataTable materials = DbMethods.GetData("SELECT tank_material_id, material_name FROM tank_material");
                cbMaterial.DataSource = materials;
                cbMaterial.DisplayMember = "material_name";
                cbMaterial.ValueMember = "tank_material_id";

                // Продукты
                DataTable products = DbMethods.GetData("SELECT oil_product_id, product_name FROM oil_product_name");
                cbProduct.DataSource = products;
                cbProduct.DisplayMember = "product_name";
                cbProduct.ValueMember = "oil_product_id";

                // Хранилища
                DataTable storage = DbMethods.GetData("SELECT storage_id, number_of_tanks FROM storage");
                cbStorage.DataSource = storage;
                cbStorage.DisplayMember = "number_of_tanks";
                cbStorage.ValueMember = "storage_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }

        private void LoadTankInfo()
        {
            try
            {
                string query = $"SELECT * FROM tank WHERE tank_id = {tankId}";
                DataTable dt = DbMethods.GetData(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtCapacity.Text = row["tank_capacity"].ToString();
                    txtUnit.Text = row["unit_of_measure"].ToString();

                    // Простой выбор в комбобоксах
                    SelectComboBoxValue(cbMaterial, row["tank_material_id"]);
                    SelectComboBoxValue(cbProduct, row["oil_product_id"]);
                    SelectComboBoxValue(cbStorage, row["storage_id"]);
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
                if (txtCapacity.Text == "")
                {
                    MessageBox.Show("Введите емкость");
                    return;
                }

                if (cbMaterial.SelectedIndex < 0 || cbStorage.SelectedIndex < 0)
                {
                    MessageBox.Show("Заполните все поля");
                    return;
                }

                int capacity = Convert.ToInt32(txtCapacity.Text);
                string unit = txtUnit.Text;
                int materialId = Convert.ToInt32(cbMaterial.SelectedValue);
                int storageId = Convert.ToInt32(cbStorage.SelectedValue);
                int productId = cbProduct.SelectedIndex >= 0 ? Convert.ToInt32(cbProduct.SelectedValue) : 0;

                string sql;
                if (tankId == -1)
                {
                    // Добавление
                    sql = $@"
                        INSERT INTO tank (tank_capacity, unit_of_measure, tank_material_id, storage_id, oil_product_id)
                        VALUES ({capacity}, '{unit}', {materialId}, {storageId}, {productId})";
                }
                else
                {
                    // Обновление
                    sql = $@"
                        UPDATE tank SET
                            tank_capacity = {capacity},
                            unit_of_measure = '{unit}',
                            tank_material_id = {materialId},
                            storage_id = {storageId},
                            oil_product_id = {productId}
                        WHERE tank_id = {tankId}";
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
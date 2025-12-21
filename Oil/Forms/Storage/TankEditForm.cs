using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using Oil.Helpers;
using Oil.Models;

namespace Oil
{
    partial class TankEditForm : Form
    {
        private int _tankId = -1; // -1 = новый резервуар
        private bool _isEditMode = false;

        // КОНСТРУКТОР 1: Для добавления нового резервуара
        public TankEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавить резервуар";
            Text = "Oil System - Добавление резервуара";
        }

        // КОНСТРУКТОР 2: Для редактирования существующего резервуара
        public TankEditForm(int tankId)
        {
            InitializeComponent();
            _tankId = tankId;
            _isEditMode = true;
            lblTitle.Text = "Редактировать резервуар";
            Text = "Oil System - Редактирование резервуара";
        }

        private void TankEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                // Проверка подключения к БД
                if (!DbMethods.TestConnection())
                {
                    MessageBox.Show("Нет подключения к базе данных!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Переименовываем label
                lblStorage.Text = "Склад:";

                // Загружаем данные в выпадающие списки
                LoadComboBoxData();

                // Если редактируем, загружаем данные резервуара
                if (_isEditMode)
                {
                    LoadTankData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке формы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadComboBoxData()
        {
            try
            {
                // 1. Загружаем нефтепродукты (можно выбрать "пусто")
                string productQuery = @"
                    SELECT op.oil_product_id, 
                           opn.product_name || ' (' || m.mark_name || ')' as display_name
                    FROM oil_product op
                    JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
                    JOIN mark m ON op.mark_id = m.mark_id
                    ORDER BY opn.product_name";

                DataTable products = DbMethods.GetData(productQuery);
                cbxProduct.DataSource = products;
                cbxProduct.DisplayMember = "display_name";
                cbxProduct.ValueMember = "oil_product_id";

                // 2. Загружаем склады (хранилища)
                string storageQuery = @"
                    SELECT 
                        storage_id,
                        'Склад №' || storage_id || ' (' || number_of_tanks || ' резервуаров)' as display_name,
                        number_of_tanks
                    FROM storage 
                    ORDER BY storage_id";

                DataTable storages = DbMethods.GetData(storageQuery);
                cbxStorage.DataSource = storages;
                cbxStorage.DisplayMember = "display_name";
                cbxStorage.ValueMember = "storage_id";

                // 3. Загружаем материалы резервуаров
                DataTable materials = DbMethods.GetData("SELECT tank_material_id, material_name FROM tank_material ORDER BY material_name");
                cbxMaterial.DataSource = materials;
                cbxMaterial.DisplayMember = "material_name";
                cbxMaterial.ValueMember = "tank_material_id";

                // Устанавливаем единицы измерения по умолчанию
                txtUnitMeasure.Text = "м³";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTankData()
        {
            try
            {
                string query = $@"
                    SELECT 
                        tank_capacity,
                        unit_of_measure,
                        oil_product_id,
                        storage_id,
                        tank_material_id
                    FROM tank 
                    WHERE tank_id = {_tankId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtCapacity.Text = row["tank_capacity"].ToString();
                    txtUnitMeasure.Text = row["unit_of_measure"].ToString();

                    // Устанавливаем значения в комбобоксы
                    SetComboBoxValue(cbxProduct, row["oil_product_id"]);
                    SetComboBoxValue(cbxStorage, row["storage_id"]);
                    SetComboBoxValue(cbxMaterial, row["tank_material_id"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных резервуара: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetComboBoxValue(ComboBox comboBox, object value)
        {
            try
            {
                if (value == DBNull.Value || Convert.ToInt32(value) == 0)
                {
                    comboBox.SelectedIndex = -1;
                    return;
                }

                for (int i = 0; i < comboBox.Items.Count; i++)
                {
                    DataRowView item = (DataRowView)comboBox.Items[i];
                    if (item.Row[comboBox.ValueMember].ToString() == value.ToString())
                    {
                        comboBox.SelectedIndex = i;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка установки значения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            try
            {
                // Валидация
                if (string.IsNullOrWhiteSpace(txtCapacity.Text))
                {
                    MessageBox.Show("Введите емкость резервуара!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCapacity.Focus();
                    return;
                }

                if (!int.TryParse(txtCapacity.Text, out int capacity) || capacity <= 0)
                {
                    MessageBox.Show("Емкость должна быть положительным числом!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCapacity.Focus();
                    return;
                }

                if (cbxStorage.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите склад!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxStorage.Focus();
                    return;
                }

                if (cbxMaterial.SelectedIndex == -1)
                {
                    MessageBox.Show("Выберите материал резервуара!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxMaterial.Focus();
                    return;
                }

                int storageId = Convert.ToInt32(cbxStorage.SelectedValue);
                int materialId = Convert.ToInt32(cbxMaterial.SelectedValue);
                string unitMeasure = txtUnitMeasure.Text.Trim();

                // Продукт может быть не выбран (NULL)
                string productIdValue = cbxProduct.SelectedIndex == -1 ? "NULL" : Convert.ToInt32(cbxProduct.SelectedValue).ToString();

                // Проверка триггера: не превышено ли количество резервуаров на складе
                if (!CheckStorageCapacity(storageId))
                {
                    MessageBox.Show("Превышено количество резервуаров на складе! Выберите другой склад.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbxStorage.Focus();
                    return;
                }

                if (_isEditMode)
                {
                    // Обновление
                    string updateQuery = $@"
                        UPDATE tank SET
                            tank_capacity = {capacity},
                            unit_of_measure = '{unitMeasure}',
                            oil_product_id = {productIdValue},
                            storage_id = {storageId},
                            tank_material_id = {materialId}
                        WHERE tank_id = {_tankId}";

                    bool success = DbMethods.Execute(updateQuery);
                    if (success)
                    {
                        MessageBox.Show("Резервуар успешно обновлен!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // Добавление
                    string insertQuery = $@"
                        INSERT INTO tank (
                            tank_capacity,
                            unit_of_measure,
                            oil_product_id,
                            storage_id,
                            tank_material_id
                        ) VALUES (
                            {capacity},
                            '{unitMeasure}',
                            {productIdValue},
                            {storageId},
                            {materialId}
                        )";

                    bool success = DbMethods.Execute(insertQuery);
                    if (success)
                    {
                        MessageBox.Show("Резервуар успешно добавлен!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckStorageCapacity(int storageId)
        {
            try
            {
                // Проверяем, не превышено ли количество резервуаров на складе
                string query = $@"
                    SELECT 
                        s.number_of_tanks,
                        COUNT(t.tank_id) as current_tanks
                    FROM storage s
                    LEFT JOIN tank t ON s.storage_id = t.storage_id
                    WHERE s.storage_id = {storageId}
                    GROUP BY s.storage_id, s.number_of_tanks";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    int maxTanks = Convert.ToInt32(dt.Rows[0]["number_of_tanks"]);
                    int currentTanks = Convert.ToInt32(dt.Rows[0]["current_tanks"]);

                    // Если редактируем существующий резервуар на том же складе, не учитываем его в проверке
                    if (_isEditMode)
                    {
                        string checkCurrentQuery = $@"
                            SELECT storage_id 
                            FROM tank 
                            WHERE tank_id = {_tankId}";
                        DataTable current = DbMethods.GetData(checkCurrentQuery);
                        if (current.Rows.Count > 0)
                        {
                            int currentStorageId = Convert.ToInt32(current.Rows[0]["storage_id"]);
                            if (currentStorageId == storageId)
                            {
                                // Резервуар остается на том же складе, не уменьшаем счетчик
                                return currentTanks <= maxTanks;
                            }
                        }
                    }

                    // Для нового резервуара или при смене склада
                    return currentTanks < maxTanks;
                }
                return true;
            }
            catch
            {
                return true; // В случае ошибки пропускаем проверку
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Событие для отображения информации о складе при выборе
        private void cbxStorage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxStorage.SelectedIndex != -1 && cbxStorage.SelectedItem is DataRowView)
            {
                DataRowView row = (DataRowView)cbxStorage.SelectedItem;
                int maxTanks = Convert.ToInt32(row["number_of_tanks"]);

                // Подсчет текущих резервуаров на выбранном складе
                string countQuery = $@"
                    SELECT COUNT(*) as tank_count 
                    FROM tank 
                    WHERE storage_id = {row["storage_id"]}";

                DataTable countDt = DbMethods.GetData(countQuery);
                int currentTanks = countDt.Rows.Count > 0 ? Convert.ToInt32(countDt.Rows[0]["tank_count"]) : 0;

                // Для редактируемого резервуара учитываем, что он уже есть на складе
                if (_isEditMode)
                {
                    string checkQuery = $@"
                        SELECT storage_id 
                        FROM tank 
                        WHERE tank_id = {_tankId}";
                    DataTable current = DbMethods.GetData(checkQuery);
                    if (current.Rows.Count > 0 &&
                        Convert.ToInt32(current.Rows[0]["storage_id"]) == Convert.ToInt32(row["storage_id"]))
                    {
                        // Резервуар уже учтен в currentTanks
                    }
                }

                int availableTanks = maxTanks - currentTanks;
                lblStorageInfo.Text = $"Свободно резервуаров: {availableTanks} из {maxTanks}";
            }
            else
            {
                lblStorageInfo.Text = "Выберите склад";
            }
        }
    }
}
using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using Oil.Helpers;
using Oil.Models;

namespace Oil.Forms.Laboratory
{
    partial class OilProductEditForm : Form
    {
        private int _oilProductId = -1; // -1 = новая запись
        private bool _isEditMode = false;

        // Конструктор для добавления
        public OilProductEditForm()
        {
            InitializeComponent();
            lblTitle.Text = "Добавить нефтепродукт";
            Text = "Oil System - Добавление нефтепродукта";
        }

        // Конструктор для редактирования
        public OilProductEditForm(int oilProductId)
        {
            InitializeComponent();
            _oilProductId = oilProductId;
            _isEditMode = true;
            lblTitle.Text = "Редактировать нефтепродукт";
            Text = "Oil System - Редактирование нефтепродукта";
        }

        private void OilProductEditForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadComboBoxData();

                // Если режим редактирования, загружаем данные
                if (_isEditMode)
                {
                    LoadOilProductData();
                }

                // Устанавливаем даты по умолчанию
                dtpManufactureDate.Value = DateTime.Now;
                dtpExpirationDate.Value = DateTime.Now.AddYears(1);
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
                // 1. Загружаем наименования нефтепродуктов
                DataTable productNames = DbMethods.GetData(
                    "SELECT oil_product_name_id, product_name FROM oil_product_name ORDER BY product_name");
                cbxProductName.DataSource = productNames;
                cbxProductName.DisplayMember = "product_name";
                cbxProductName.ValueMember = "oil_product_name_id";

                // 2. Загружаем марки
                DataTable marks = DbMethods.GetData(
                    "SELECT mark_id, mark_name FROM mark ORDER BY mark_name");
                cbxMark.DataSource = marks;
                cbxMark.DisplayMember = "mark_name";
                cbxMark.ValueMember = "mark_id";

                // 3. Загружаем применения
                DataTable applications = DbMethods.GetData(
                    "SELECT application_id, application_name FROM application ORDER BY application_name");
                cbxApplication.DataSource = applications;
                cbxApplication.DisplayMember = "application_name";
                cbxApplication.ValueMember = "application_id";

                // 4. Загружаем классы опасности
                DataTable dangerClasses = DbMethods.GetData(
                    "SELECT class_of_danger_id, class_name FROM class_of_danger ORDER BY class_of_danger_id");
                cbxClassOfDanger.DataSource = dangerClasses;
                cbxClassOfDanger.DisplayMember = "class_name";
                cbxClassOfDanger.ValueMember = "class_of_danger_id";

                // 5. Загружаем фракции (используем ту же таблицу, что и для нефти)
                DataTable fractions = DbMethods.GetData(
                    "SELECT oil_fraction_id, fraction FROM oil_fraction ORDER BY oil_fraction_id");
                cbxFraction.DataSource = fractions;
                cbxFraction.DisplayMember = "fraction";
                cbxFraction.ValueMember = "oil_fraction_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOilProductData()
        {
            try
            {
                string query = $@"
                    SELECT 
                        oil_product_name_id,
                        mark_id,
                        application_id,
                        class_of_danger_id,
                        oil_product_fraction_id,
                        manufacture_date,
                        expiration_date
                    FROM oil_product 
                    WHERE oil_product_id = {_oilProductId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Устанавливаем значения в выпадающие списки
                    SetComboBoxValue(cbxProductName, row["oil_product_name_id"]);
                    SetComboBoxValue(cbxMark, row["mark_id"]);
                    SetComboBoxValue(cbxApplication, row["application_id"]);
                    SetComboBoxValue(cbxClassOfDanger, row["class_of_danger_id"]);
                    SetComboBoxValue(cbxFraction, row["oil_product_fraction_id"]);

                    // Устанавливаем даты
                    dtpManufactureDate.Value = Convert.ToDateTime(row["manufacture_date"]);
                    dtpExpirationDate.Value = Convert.ToDateTime(row["expiration_date"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных нефтепродукта: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetComboBoxValue(ComboBox comboBox, object value)
        {
            try
            {
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
                // Проверяем, что все обязательные поля заполнены
                if (cbxProductName.SelectedIndex == -1 ||
                    cbxMark.SelectedIndex == -1 ||
                    cbxApplication.SelectedIndex == -1 ||
                    cbxClassOfDanger.SelectedIndex == -1 ||
                    cbxFraction.SelectedIndex == -1)
                {
                    MessageBox.Show("Заполните все обязательные поля!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверяем, что дата производства раньше срока годности
                if (dtpManufactureDate.Value >= dtpExpirationDate.Value)
                {
                    MessageBox.Show("Дата производства должна быть раньше срока годности!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Получаем значения из формы
                int productNameId = Convert.ToInt32(cbxProductName.SelectedValue);
                int markId = Convert.ToInt32(cbxMark.SelectedValue);
                int applicationId = Convert.ToInt32(cbxApplication.SelectedValue);
                int classOfDangerId = Convert.ToInt32(cbxClassOfDanger.SelectedValue);
                int fractionId = Convert.ToInt32(cbxFraction.SelectedValue);
                string manufactureDate = dtpManufactureDate.Value.ToString("yyyy-MM-dd");
                string expirationDate = dtpExpirationDate.Value.ToString("yyyy-MM-dd");

                if (_isEditMode)
                {
                    // Обновляем существующую запись
                    string updateQuery = $@"
                        UPDATE oil_product SET
                            oil_product_name_id = {productNameId},
                            mark_id = {markId},
                            application_id = {applicationId},
                            class_of_danger_id = {classOfDangerId},
                            oil_product_fraction_id = {fractionId},
                            manufacture_date = '{manufactureDate}',
                            expiration_date = '{expirationDate}'
                        WHERE oil_product_id = {_oilProductId}";

                    bool success = DbMethods.Execute(updateQuery);
                    if (success)
                    {
                        MessageBox.Show("Нефтепродукт успешно обновлен!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // Добавляем новую запись
                    // Проверяем, нет ли уже такого сочетания продукта и марки
                    string checkQuery = $@"
                        SELECT COUNT(*) FROM oil_product 
                        WHERE oil_product_name_id = {productNameId} 
                        AND mark_id = {markId}";

                    DataTable dt = DbMethods.GetData(checkQuery);
                    int count = Convert.ToInt32(dt.Rows[0][0]);

                    if (count > 0)
                    {
                        MessageBox.Show("Нефтепродукт с таким наименованием и маркой уже существует!", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string insertQuery = $@"
                        INSERT INTO oil_product (
                            oil_product_name_id,
                            mark_id,
                            application_id,
                            class_of_danger_id,
                            oil_product_fraction_id,
                            manufacture_date,
                            expiration_date
                        ) VALUES (
                            {productNameId},
                            {markId},
                            {applicationId},
                            {classOfDangerId},
                            {fractionId},
                            '{manufactureDate}',
                            '{expirationDate}'
                        )";

                    bool success = DbMethods.Execute(insertQuery);
                    if (success)
                    {
                        MessageBox.Show("Нефтепродукт успешно добавлен!", "Успех",
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Проверка уникальности при изменении данных
        private void CheckUniqueProduct()
        {
            try
            {
                if (cbxProductName.SelectedIndex != -1 && cbxMark.SelectedIndex != -1)
                {
                    int productNameId = Convert.ToInt32(cbxProductName.SelectedValue);
                    int markId = Convert.ToInt32(cbxMark.SelectedValue);

                    string query = $@"
                        SELECT COUNT(*) FROM oil_product 
                        WHERE oil_product_name_id = {productNameId} 
                        AND mark_id = {markId}";

                    // Если режим редактирования, исключаем текущую запись
                    if (_isEditMode)
                    {
                        query += $" AND oil_product_id != {_oilProductId}";
                    }

                    DataTable dt = DbMethods.GetData(query);
                    int count = Convert.ToInt32(dt.Rows[0][0]);

                    if (count > 0)
                    {
                        // Подсвечиваем проблемные поля
                        cbxProductName.BackColor = Color.LightPink;
                        cbxMark.BackColor = Color.LightPink;
                    }
                    else
                    {
                        cbxProductName.BackColor = Color.White;
                        cbxMark.BackColor = Color.White;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
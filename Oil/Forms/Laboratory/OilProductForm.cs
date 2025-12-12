using Npgsql;
using Oil.Forms.Laboratory;
using Oil.Helpers;
using Oil.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace Oil
{
    partial class OilProductForm : Form
    {
        public OilProductForm()
        {
            InitializeComponent();
        }

        private void LoadOilProducts()
        {
            try
            {
                // Используем представление 
                string query = @"
                    SELECT 
                        op.oil_product_id,
                        opn.product_name,
                        m.mark_name,
                        a.application_name,
                        cd.class_name AS danger_class,
                        offr.fraction AS product_fraction,
                        op.manufacture_date,
                        op.expiration_date
                    FROM oil_product op
                    JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
                    JOIN mark m ON op.mark_id = m.mark_id
                    JOIN application a ON op.application_id = a.application_id
                    JOIN class_of_danger cd ON op.class_of_danger_id = cd.class_of_danger_id
                    JOIN oil_fraction offr ON op.oil_product_fraction_id = offr.oil_fraction_id
                    ORDER BY opn.product_name, m.mark_name";

                DataTable dt = DbMethods.GetData(query);
                dgvOilProducts.DataSource = dt;

                // Заголовки
                if (dgvOilProducts.Columns.Count > 0)
                {
                    dgvOilProducts.Columns["oil_product_id"].Visible = false; // Скрываем ID
                    dgvOilProducts.Columns["product_name"].HeaderText = "Наименование";
                    dgvOilProducts.Columns["mark_name"].HeaderText = "Марка";
                    dgvOilProducts.Columns["application_name"].HeaderText = "Применение";
                    dgvOilProducts.Columns["danger_class"].HeaderText = "Класс опасности";
                    dgvOilProducts.Columns["product_fraction"].HeaderText = "Фракция";
                    dgvOilProducts.Columns["manufacture_date"].HeaderText = "Дата производства";
                    dgvOilProducts.Columns["expiration_date"].HeaderText = "Срок годности до";

                    // Ширина колонок
                    dgvOilProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Отображение даты
                    dgvOilProducts.Columns["manufacture_date"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    dgvOilProducts.Columns["expiration_date"].DefaultCellStyle.Format = "dd.MM.yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OilProductForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadOilProducts();
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
                // ОТКРЫВАЕМ ФОРМУ ДЛЯ ДОБАВЛЕНИЯ НОВОГО НЕФТЕПРОДУКТА
                OilProductEditForm editForm = new OilProductEditForm();

                // Если пользователь нажал "Сохранить" в форме редактирования
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Нефтепродукт успешно добавлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Обновляем список после добавления
                    LoadOilProducts();
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
                if (dgvOilProducts.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvOilProducts.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["oil_product_id"].Value);
                    string productName = row.Cells["product_name"].Value.ToString();
                    string markName = row.Cells["mark_name"].Value.ToString();

                    // ОТКРЫВАЕМ ФОРМУ ДЛЯ РЕДАКТИРОВАНИЯ СУЩЕСТВУЮЩЕГО НЕФТЕПРОДУКТА
                    // Передаем ID выбранного нефтепродукта
                    OilProductEditForm editForm = new OilProductEditForm(id);

                    // Если пользователь нажал "Сохранить" в форме редактирования
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show($"Нефтепродукт {productName} - {markName} успешно обновлен!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Обновляем список после редактирования
                        LoadOilProducts();
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
                if (dgvOilProducts.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvOilProducts.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["oil_product_id"].Value);
                    string productName = row.Cells["product_name"].Value.ToString();
                    string markName = row.Cells["mark_name"].Value.ToString();

                    var result = MessageBox.Show($"Вы уверены, что хотите удалить нефтепродукт:\n{productName} - {markName}?",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Проверяем, есть ли связанные записи (партии нефтепродуктов)
                        string checkQuery = $"SELECT COUNT(*) FROM oil_product_lot WHERE oil_product_id = {id}";
                        DataTable dt = DbMethods.GetData(checkQuery);
                        int count = Convert.ToInt32(dt.Rows[0][0]);

                        if (count > 0)
                        {
                            MessageBox.Show("Невозможно удалить нефтепродукт, так как есть связанные партии!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        bool success = DbMethods.Delete("oil_product", id);
                        if (success)
                        {
                            MessageBox.Show("Нефтепродукт успешно удален", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadOilProducts();
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
            LoadOilProducts();
        }

        private void dgvOilProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        // Метод для показа информации о выбранном нефтепродукте
        private void ShowProductInfo(int productId)
        {
            try
            {
                string query = $@"
                    SELECT 
                        op.oil_product_id,
                        opn.product_name,
                        m.mark_name,
                        a.application_name,
                        cd.class_name,
                        offr.fraction,
                        op.manufacture_date,
                        op.expiration_date
                    FROM oil_product op
                    JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
                    JOIN mark m ON op.mark_id = m.mark_id
                    JOIN application a ON op.application_id = a.application_id
                    JOIN class_of_danger cd ON op.class_of_danger_id = cd.class_of_danger_id
                    JOIN oil_fraction offr ON op.oil_product_fraction_id = offr.oil_fraction_id
                    WHERE op.oil_product_id = {productId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    string info = $"Информация о нефтепродукте:\n\n" +
                                 $"Наименование: {row["product_name"]}\n" +
                                 $"Марка: {row["mark_name"]}\n" +
                                 $"Применение: {row["application_name"]}\n" +
                                 $"Класс опасности: {row["class_name"]}\n" +
                                 $"Фракция: {row["fraction"]}\n" +
                                 $"Дата производства: {Convert.ToDateTime(row["manufacture_date"]):dd.MM.yyyy}\n" +
                                 $"Срок годности до: {Convert.ToDateTime(row["expiration_date"]):dd.MM.yyyy}";

                    MessageBox.Show(info, "Информация о нефтепродукте",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка получения информации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
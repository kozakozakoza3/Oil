using Oil.Helpers;
using System;
using System.Data;
using System.Windows.Forms;

namespace Oil.Forms
{
    public partial class LaboratoryAnalysisForm : Form
    {
        public LaboratoryAnalysisForm()
        {
            InitializeComponent();
        }

        private void LoadAnalyses()
        {
            try
            {
                string query = @"
                    SELECT 
                        la.laboratory_analysis_id,
                        opn.product_name || ' - ' || m.mark_name AS product_name,
                        e.last_name || ' ' || e.name AS analyst_name,
                        la.sample_volume || ' ' || la.unit_of_measure_volume AS sample_info,
                        la.oil_product_density || ' ' || la.unit_of_measure_density AS density_info,
                        la.oil_product_sulfur_content || ' ' || la.unit_of_measure_sulfur AS sulfur_info,
                        la.oil_product_viscosity || ' ' || la.unit_of_measure_viscosity AS viscosity_info,
                        la.oil_product_flash_point || ' ' || la.unit_of_measure_flash AS flash_info,
                        la.date_time_analysis
                    FROM laboratory_analysis la
                    JOIN oil_product op ON la.oil_product_id = op.oil_product_id
                    JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
                    JOIN mark m ON op.mark_id = m.mark_id
                    JOIN employee e ON la.employee_id = e.employee_id
                    ORDER BY la.date_time_analysis DESC";

                DataTable dt = DbMethods.GetData(query);
                dgvAnalyses.DataSource = dt;

                // Настройка заголовков колонок
                if (dgvAnalyses.Columns.Count > 0)
                {
                    dgvAnalyses.Columns["laboratory_analysis_id"].Visible = false; // Скрываем ID
                    dgvAnalyses.Columns["product_name"].HeaderText = "Продукт";
                    dgvAnalyses.Columns["analyst_name"].HeaderText = "Аналитик";
                    dgvAnalyses.Columns["sample_info"].HeaderText = "Объем пробы";
                    dgvAnalyses.Columns["density_info"].HeaderText = "Плотность";
                    dgvAnalyses.Columns["sulfur_info"].HeaderText = "Содержание серы";
                    dgvAnalyses.Columns["viscosity_info"].HeaderText = "Вязкость";
                    dgvAnalyses.Columns["flash_info"].HeaderText = "Темп. вспышки";
                    dgvAnalyses.Columns["date_time_analysis"].HeaderText = "Дата анализа";

                    // Настройка ширины колонок
                    dgvAnalyses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Форматирование даты
                    dgvAnalyses.Columns["date_time_analysis"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LaboratoryAnalysisForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadAnalyses();
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
                LaboratoryAnalysisEditForm editForm = new LaboratoryAnalysisEditForm();
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadAnalyses();
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
                if (dgvAnalyses.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvAnalyses.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["laboratory_analysis_id"].Value);

                    LaboratoryAnalysisEditForm editForm = new LaboratoryAnalysisEditForm(id);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadAnalyses();
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
                if (dgvAnalyses.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvAnalyses.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["laboratory_analysis_id"].Value);
                    string productName = row.Cells["product_name"].Value.ToString();

                    var result = MessageBox.Show($"Вы уверены, что хотите удалить анализ для продукта '{productName}'?",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Проверяем, есть ли связанные записи
                        string checkQuery = $"SELECT COUNT(*) FROM laboratory_analysis_route WHERE laboratory_analysis_id = {id}";
                        DataTable dt = DbMethods.GetData(checkQuery);
                        int count = Convert.ToInt32(dt.Rows[0][0]);

                        if (count > 0)
                        {
                            MessageBox.Show("Невозможно удалить анализ, так как он привязан к маршруту!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        bool success = DbMethods.Delete("laboratory_analysis", id);
                        if (success)
                        {
                            MessageBox.Show("Анализ успешно удален", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAnalyses();
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
            LoadAnalyses();
        }

        private void dgvAnalyses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnEdit_Click(sender, e);
            }
        }

        // Кнопка для печати (оставляем как в примере)
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAnalyses.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgvAnalyses.SelectedRows[0];
                    int id = Convert.ToInt32(row.Cells["laboratory_analysis_id"].Value);
                    string productName = row.Cells["product_name"].Value.ToString();

                    // Здесь будет код для печати
                    MessageBox.Show($"Печать анализа для продукта: {productName}\nID анализа: {id}",
                        "Печать", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Выберите анализ для печати", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при печати: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
using Oil.Helpers;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oil.Models;

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
            // Простой запрос для получения данных
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

            // Простые заголовки
            if (dgvAnalyses.Columns.Count > 0)
            {
                dgvAnalyses.Columns["laboratory_analysis_id"].Visible = false;
                dgvAnalyses.Columns["product_name"].HeaderText = "Продукт";
                dgvAnalyses.Columns["analyst_name"].HeaderText = "Аналитик";
                dgvAnalyses.Columns["sample_info"].HeaderText = "Объем пробы";
                dgvAnalyses.Columns["density_info"].HeaderText = "Плотность";
                dgvAnalyses.Columns["sulfur_info"].HeaderText = "Содержание серы";
                dgvAnalyses.Columns["viscosity_info"].HeaderText = "Вязкость";
                dgvAnalyses.Columns["flash_info"].HeaderText = "Темп. вспышки";
                dgvAnalyses.Columns["date_time_analysis"].HeaderText = "Дата анализа";

                // Форматирование даты и времени
                dgvAnalyses.Columns["date_time_analysis"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
            }
        }

        private void LaboratoryAnalysisForm_Load(object sender, EventArgs e)
        {
            LoadAnalyses();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // СОЗДАЕМ ФОРМУ ДЛЯ ДОБАВЛЕНИЯ НОВОГО АНАЛИЗА
                LaboratoryAnalysisEditForm editForm = new LaboratoryAnalysisEditForm();

                // ПОКАЗЫВАЕМ ФОРМУ КАК ДИАЛОГОВОЕ ОКНО
                // ShowDialog() - окно блокирует родительское окно, пока не закроется
                DialogResult result = editForm.ShowDialog();

                // ЕСЛИ ПОЛЬЗОВАТЕЛЬ НАЖАЛ "СОХРАНИТЬ" (DialogResult.OK)
                if (result == DialogResult.OK)
                {
                    // ОБНОВЛЯЕМ ТАБЛИЦУ С АНАЛИЗАМИ
                    LoadAnalyses();

                    // Сообщаем пользователю об успехе
                    MessageBox.Show("Анализ успешно добавлен!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // ЕСЛИ ПОЛЬЗОВАТЕЛЬ НАЖАЛ "ОТМЕНА" (DialogResult.Cancel) - ничего не делаем
            }
            catch (Exception ex)
            {
                // ЕСЛИ ЧТО-ТО ПОШЛО НЕ ТАК - ПОКАЗЫВАЕМ ОШИБКУ
                MessageBox.Show($"Ошибка при добавлении анализа:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                // ПРОВЕРЯЕМ: ВЫБРАНА ЛИ КАКАЯ-ТО СТРОКА В ТАБЛИЦЕ?
                if (dgvAnalyses.SelectedRows.Count > 0)
                {
                    // БЕРЕМ ПЕРВУЮ ВЫБРАННУЮ СТРОКУ
                    DataGridViewRow row = dgvAnalyses.SelectedRows[0];

                    // ПОЛУЧАЕМ ID АНАЛИЗА ИЗ СКРЫТОЙ КОЛОНКИ
                    // ВАЖНО: используем правильное имя колонки - "laboratory_analysis_id"
                    int id = Convert.ToInt32(row.Cells["laboratory_analysis_id"].Value);

                    // СОЗДАЕМ ФОРМУ ДЛЯ РЕДАКТИРОВАНИЯ И ПЕРЕДАЕМ ID
                    LaboratoryAnalysisEditForm editForm = new LaboratoryAnalysisEditForm(id);

                    // ПОКАЗЫВАЕМ ФОРМУ
                    DialogResult result = editForm.ShowDialog();

                    // ЕСЛИ НАЖАЛИ "СОХРАНИТЬ"
                    if (result == DialogResult.OK)
                    {
                        // ОБНОВЛЯЕМ ТАБЛИЦУ
                        LoadAnalyses();

                        // Сообщаем пользователю об успехе
                        MessageBox.Show("Анализ успешно обновлен!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // ЕСЛИ НИЧЕГО НЕ ВЫБРАНО - ПОКАЗЫВАЕМ ПОДСКАЗКУ
                    MessageBox.Show("Выберите анализ для редактирования.\n" +
                                  "Кликните по строке в таблице, чтобы выбрать ее.",
                                  "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // ЕСЛИ ВОЗНИКЛА ОШИБКА
                MessageBox.Show($"Ошибка при редактировании анализа:\n{ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Проверяем, что выбрана строка
            if (dgvAnalyses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите анализ для печати");
                return;
            }

            // Получаем ID выбранного анализа
            DataGridViewRow row = dgvAnalyses.SelectedRows[0];
            int analysisId = Convert.ToInt32(row.Cells["laboratory_analysis_id"].Value);

            // Получаем данные для этого анализа
            string query = $@"
        SELECT 
            opn.product_name,
            m.mark_name,
            e.last_name || ' ' || e.name as analyst_name,
            p.post_name as analyst_position,
            la.sample_volume,
            la.unit_of_measure_volume,
            la.oil_product_density,
            la.unit_of_measure_density,
            la.oil_product_sulfur_content,
            la.unit_of_measure_sulfur,
            la.oil_product_viscosity,
            la.unit_of_measure_viscosity,
            la.oil_product_flash_point,
            la.unit_of_measure_flash,
            la.date_time_analysis
        FROM laboratory_analysis la
        JOIN oil_product op ON la.oil_product_id = op.oil_product_id
        JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
        JOIN mark m ON op.mark_id = m.mark_id
        JOIN employee e ON la.employee_id = e.employee_id
        JOIN post p ON e.post_id = p.post_id
        WHERE la.laboratory_analysis_id = {analysisId}";

            DataTable dt = DbMethods.GetData(query);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Не найдены данные для печати");
                return;
            }

            DataRow data = dt.Rows[0];

            // Создаем объект с данными для печати
            CertificatePrintData printData = new CertificatePrintData
            {
                AnalysisId = analysisId,
                ProductName = data["product_name"].ToString(),
                ProductMark = data["mark_name"].ToString(),
                AnalystName = data["analyst_name"].ToString(),
                AnalystPosition = data["analyst_position"].ToString(),
                SampleVolume = Convert.ToDecimal(data["sample_volume"]),
                UnitOfMeasureVolume = data["unit_of_measure_volume"].ToString(),
                Density = Convert.ToDecimal(data["oil_product_density"]),
                UnitOfMeasureDensity = data["unit_of_measure_density"].ToString(),
                SulfurContent = Convert.ToDecimal(data["oil_product_sulfur_content"]),
                UnitOfMeasureSulfur = data["unit_of_measure_sulfur"].ToString(),
                Viscosity = Convert.ToDecimal(data["oil_product_viscosity"]),
                UnitOfMeasureViscosity = data["unit_of_measure_viscosity"].ToString(),
                FlashPoint = Convert.ToInt32(data["oil_product_flash_point"]),
                UnitOfMeasureFlash = data["unit_of_measure_flash"].ToString(),
                AnalysisDateTime = Convert.ToDateTime(data["date_time_analysis"]),
                CertificateDateTime = DateTime.Now
            };

            // Создаем принтер и печатаем
            CertificatePrinter printer = new CertificatePrinter();
            printer.ShowPrintDialog(printData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadAnalyses();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ДОПОЛНИТЕЛЬНО: можно добавить обработчик двойного клика по строке
        private void dgvAnalyses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Кликнули по строке с данными (не по заголовку)
            {
                btnEdit_Click(sender, e); // Вызываем тот же метод, что и при нажатии кнопки "Изменить"
            }
        }
    }
}
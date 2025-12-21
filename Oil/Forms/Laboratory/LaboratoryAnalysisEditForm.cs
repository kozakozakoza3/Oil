using Oil.Helpers;
using System;
using System.Data;
using System.Windows.Forms;
using System.Globalization;

namespace Oil.Forms
{
    public partial class LaboratoryAnalysisEditForm : Form
    {
        private int _laboratoryAnalysisId = -1; // -1 = новая запись
        private bool _isEditMode = false;

        // КОНСТРУКТОР 1: Для добавления нового анализа
        public LaboratoryAnalysisEditForm()
        {
            InitializeComponent();
            Text = "Добавление лабораторного анализа";
        }

        // КОНСТРУКТОР 2: Для редактирования существующего анализа
        public LaboratoryAnalysisEditForm(int laboratoryAnalysisId)
        {
            InitializeComponent();
            _laboratoryAnalysisId = laboratoryAnalysisId;
            _isEditMode = true;
            Text = "Редактирование лабораторного анализа";
        }

        private void LaboratoryAnalysisEditForm_Load(object sender, EventArgs e)
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

                // Загружаем данные в выпадающие списки
                LoadComboBoxData();

                // Устанавливаем текущую дату и время
                dtpDateTimeAnalysis.Value = DateTime.Now;

                // Если редактируем, загружаем данные анализа
                if (_isEditMode)
                {
                    LoadLaboratoryAnalysisData();
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
                // 1. Загружаем нефтепродукты
                string productQuery = @"
                    SELECT 
                        op.oil_product_id,
                        opn.product_name || ' - ' || m.mark_name AS display_name
                    FROM oil_product op
                    JOIN oil_product_name opn ON op.oil_product_name_id = opn.oil_product_name_id
                    JOIN mark m ON op.mark_id = m.mark_id
                    ORDER BY opn.product_name, m.mark_name";

                DataTable products = DbMethods.GetData(productQuery);
                cbxOilProduct.DataSource = products;
                cbxOilProduct.DisplayMember = "display_name";
                cbxOilProduct.ValueMember = "oil_product_id";

                // 2. Загружаем сотрудников
                DataTable employees = DbMethods.GetData(
                    "SELECT employee_id, last_name || ' ' || name AS full_name FROM employee ORDER BY last_name, name");
                cbxEmployee.DataSource = employees;
                cbxEmployee.DisplayMember = "full_name";
                cbxEmployee.ValueMember = "employee_id";

                // 3. Загружаем единицы измерения
                LoadUnitsOfMeasure();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки справочников: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUnitsOfMeasure()
        {
            try
            {
                // Единицы объема (из структуры БД)
                cbxUnitVolume.Items.Clear();
                cbxUnitVolume.Items.AddRange(new string[] { "м³", "л" });
                cbxUnitVolume.SelectedIndex = 0;

                // Единицы плотности (из структуры БД)
                cbxUnitDensity.Items.Clear();
                cbxUnitDensity.Items.AddRange(new string[] { "кг/м³" });
                cbxUnitDensity.SelectedIndex = 0;

                // Единицы содержания серы (из структуры БД)
                cbxUnitSulfur.Items.Clear();
                cbxUnitSulfur.Items.AddRange(new string[] { "% масс." });
                cbxUnitSulfur.SelectedIndex = 0;

                // Единицы содержания воды (из структуры БД)
                cbxUnitWater.Items.Clear();
                cbxUnitWater.Items.AddRange(new string[] { "% масс." });
                cbxUnitWater.SelectedIndex = 0;

                // Единицы вязкости (из структуры БД)
                cbxUnitViscosity.Items.Clear();
                cbxUnitViscosity.Items.AddRange(new string[] { "мПа·с" });
                cbxUnitViscosity.SelectedIndex = 0;

                // Единицы температуры вспышки (из структуры БД)
                cbxUnitFlash.Items.Clear();
                cbxUnitFlash.Items.AddRange(new string[] { "°C" });
                cbxUnitFlash.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки единиц измерения: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLaboratoryAnalysisData()
        {
            try
            {
                string query = $@"
                    SELECT 
                        oil_product_id,
                        employee_id,
                        sample_volume,
                        unit_of_measure_volume,
                        oil_product_density,
                        unit_of_measure_density,
                        oil_product_sulfur_content,
                        unit_of_measure_sulfur,
                        oil_product_water_content,
                        unit_of_measure_water,
                        oil_product_viscosity,
                        unit_of_measure_viscosity,
                        oil_product_flash_point,
                        unit_of_measure_flash,
                        date_time_analysis
                    FROM laboratory_analysis 
                    WHERE laboratory_analysis_id = {_laboratoryAnalysisId}";

                DataTable dt = DbMethods.GetData(query);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Устанавливаем значения в выпадающие списки
                    SetComboBoxValue(cbxOilProduct, row["oil_product_id"]);
                    SetComboBoxValue(cbxEmployee, row["employee_id"]);

                    // Заполняем текстовые поля
                    txtSampleVolume.Text = row["sample_volume"].ToString();
                    txtOilProductDensity.Text = row["oil_product_density"].ToString();
                    txtOilProductSulfurContent.Text = row["oil_product_sulfur_content"].ToString();
                    txtOilProductViscosity.Text = row["oil_product_viscosity"].ToString();
                    txtOilProductFlashPoint.Text = row["oil_product_flash_point"].ToString();

                    // Содержание воды может быть NULL
                    if (row["oil_product_water_content"] != DBNull.Value)
                        txtOilProductWaterContent.Text = row["oil_product_water_content"].ToString();

                    // Устанавливаем единицы измерения
                    cbxUnitVolume.Text = row["unit_of_measure_volume"].ToString();
                    cbxUnitDensity.Text = row["unit_of_measure_density"].ToString();
                    cbxUnitSulfur.Text = row["unit_of_measure_sulfur"].ToString();
                    cbxUnitWater.Text = row["unit_of_measure_water"].ToString();
                    cbxUnitViscosity.Text = row["unit_of_measure_viscosity"].ToString();
                    cbxUnitFlash.Text = row["unit_of_measure_flash"].ToString();

                    // Устанавливаем дату и время
                    if (row["date_time_analysis"] != DBNull.Value)
                        dtpDateTimeAnalysis.Value = Convert.ToDateTime(row["date_time_analysis"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных анализа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetComboBoxValue(ComboBox comboBox, object value)
        {
            try
            {
                if (value == DBNull.Value) return;

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
                MessageBox.Show($"Ошибка установки значения в ComboBox: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            // Проверяем обязательные поля
            if (cbxOilProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите нефтепродукт!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxOilProduct.Focus();
                return false;
            }

            if (cbxEmployee.SelectedValue == null)
            {
                MessageBox.Show("Выберите сотрудника!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbxEmployee.Focus();
                return false;
            }

            // Проверяем числовые поля
            if (!decimal.TryParse(txtSampleVolume.Text, out decimal sampleVolume) || sampleVolume <= 0)
            {
                MessageBox.Show("Введите корректный объем пробы (положительное число)!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSampleVolume.Focus();
                return false;
            }

            if (!decimal.TryParse(txtOilProductDensity.Text, out decimal density) || density <= 0)
            {
                MessageBox.Show("Введите корректную плотность (положительное число)!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOilProductDensity.Focus();
                return false;
            }

            if (!decimal.TryParse(txtOilProductSulfurContent.Text, out decimal sulfur) || sulfur < 0)
            {
                MessageBox.Show("Введите корректное содержание серы (неотрицательное число)!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOilProductSulfurContent.Focus();
                return false;
            }

            if (!decimal.TryParse(txtOilProductViscosity.Text, out decimal viscosity) || viscosity <= 0)
            {
                MessageBox.Show("Введите корректную вязкость (положительное число)!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOilProductViscosity.Focus();
                return false;
            }

            if (!int.TryParse(txtOilProductFlashPoint.Text, out int flashPoint) || flashPoint < 0)
            {
                MessageBox.Show("Введите корректную температуру вспышки (неотрицательное число)!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOilProductFlashPoint.Focus();
                return false;
            }

            // Проверяем содержание воды (может быть пустым)
            if (!string.IsNullOrEmpty(txtOilProductWaterContent.Text))
            {
                if (!decimal.TryParse(txtOilProductWaterContent.Text, out decimal water) || water < 0)
                {
                    MessageBox.Show("Введите корректное содержание воды (неотрицательное число)!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOilProductWaterContent.Focus();
                    return false;
                }
            }

            DateTime selectedDate = dtpDateTimeAnalysis.Value;
            DateTime currentDate = DateTime.Now;

            // Сравниваем без времени, только дату
            if (selectedDate.Date > currentDate.Date)
            {
                MessageBox.Show("Дата анализа не может быть в будущем! Выберите сегодняшнюю или прошедшую дату.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpDateTimeAnalysis.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация полей
                if (!ValidateInput())
                    return;

                // Получаем значения из формы
                int oilProductId = Convert.ToInt32(cbxOilProduct.SelectedValue);
                int employeeId = Convert.ToInt32(cbxEmployee.SelectedValue);
                decimal sampleVolume = decimal.Parse(txtSampleVolume.Text);
                decimal oilProductDensity = decimal.Parse(txtOilProductDensity.Text);
                decimal oilProductSulfurContent = decimal.Parse(txtOilProductSulfurContent.Text);
                decimal oilProductViscosity = decimal.Parse(txtOilProductViscosity.Text);
                int oilProductFlashPoint = int.Parse(txtOilProductFlashPoint.Text);

                // Содержание воды может быть пустым
                string waterContentValue = string.IsNullOrEmpty(txtOilProductWaterContent.Text) ?
                    "NULL" : decimal.Parse(txtOilProductWaterContent.Text).ToString().Replace(',', '.');

                string unitOfMeasureVolume = cbxUnitVolume.Text;
                string unitOfMeasureDensity = cbxUnitDensity.Text;
                string unitOfMeasureSulfur = cbxUnitSulfur.Text;
                string unitOfMeasureWater = cbxUnitWater.Text;
                string unitOfMeasureViscosity = cbxUnitViscosity.Text;
                string unitOfMeasureFlash = cbxUnitFlash.Text;
                string dateTimeAnalysis = dtpDateTimeAnalysis.Value.ToString("yyyy-MM-dd HH:mm:ss");

                if (_isEditMode)
                {
                    // Обновляем существующую запись
                    string updateQuery = $@"
                        UPDATE laboratory_analysis SET
                            oil_product_id = {oilProductId},
                            employee_id = {employeeId},
                            sample_volume = {sampleVolume.ToString().Replace(',', '.')},
                            unit_of_measure_volume = '{unitOfMeasureVolume}',
                            oil_product_density = {oilProductDensity.ToString().Replace(',', '.')},
                            unit_of_measure_density = '{unitOfMeasureDensity}',
                            oil_product_sulfur_content = {oilProductSulfurContent.ToString().Replace(',', '.')},
                            unit_of_measure_sulfur = '{unitOfMeasureSulfur}',
                            oil_product_water_content = {waterContentValue},
                            unit_of_measure_water = '{unitOfMeasureWater}',
                            oil_product_viscosity = {oilProductViscosity.ToString().Replace(',', '.')},
                            unit_of_measure_viscosity = '{unitOfMeasureViscosity}',
                            oil_product_flash_point = {oilProductFlashPoint},
                            unit_of_measure_flash = '{unitOfMeasureFlash}',
                            date_time_analysis = '{dateTimeAnalysis}'
                        WHERE laboratory_analysis_id = {_laboratoryAnalysisId}";

                    bool success = DbMethods.Execute(updateQuery);
                    if (success)
                    {
                        MessageBox.Show("Анализ успешно обновлен!", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // Добавляем новую запись
                    string insertQuery = $@"
                        INSERT INTO laboratory_analysis (
                            oil_product_id,
                            employee_id,
                            sample_volume,
                            unit_of_measure_volume,
                            oil_product_density,
                            unit_of_measure_density,
                            oil_product_sulfur_content,
                            unit_of_measure_sulfur,
                            oil_product_water_content,
                            unit_of_measure_water,
                            oil_product_viscosity,
                            unit_of_measure_viscosity,
                            oil_product_flash_point,
                            unit_of_measure_flash,
                            date_time_analysis
                        ) VALUES (
                            {oilProductId},
                            {employeeId},
                            {sampleVolume.ToString().Replace(',', '.')},
                            '{unitOfMeasureVolume}',
                            {oilProductDensity.ToString().Replace(',', '.')},
                            '{unitOfMeasureDensity}',
                            {oilProductSulfurContent.ToString().Replace(',', '.')},
                            '{unitOfMeasureSulfur}',
                            {waterContentValue},
                            '{unitOfMeasureWater}',
                            {oilProductViscosity.ToString().Replace(',', '.')},
                            '{unitOfMeasureViscosity}',
                            {oilProductFlashPoint},
                            '{unitOfMeasureFlash}',
                            '{dateTimeAnalysis}'
                        )";

                    bool success = DbMethods.Execute(insertQuery);
                    if (success)
                    {
                        MessageBox.Show("Анализ успешно добавлен!", "Успех",
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

        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем цифры, точку, запятую и Backspace
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' &&
                e.KeyChar != ',' &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            // Запрещаем больше одной точки или запятой
            TextBox textBox = (TextBox)sender;
            if ((e.KeyChar == '.' || e.KeyChar == ',') &&
                (textBox.Text.Contains('.') || textBox.Text.Contains(',')))
            {
                e.Handled = true;
            }
        }

        private void txtInteger_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Только цифры и Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
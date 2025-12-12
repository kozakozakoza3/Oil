using Oil.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Oil
{
    public partial class LaboratoryAnalysisForm : Form
    {
        public LaboratoryAnalysis? Analysis { get; set; }
        public string? Analyst { get; set; }

        // Добавляем константы
        private const double MIN_DENSITY = 0.7;
        private const double MAX_DENSITY = 1.0;
        private const double MIN_SULFUR = 0.0;
        private const double MAX_SULFUR = 5.0;
        private const double MAX_WATER = 1.0;
        private const double MIN_VISCOSITY = 1.0;
        private const double MAX_VISCOSITY = 10000.0;
        private const int MIN_FLASH_POINT = 30;
        private const int MAX_FLASH_POINT = 300;

        public LaboratoryAnalysisForm()
        {
            InitializeComponent();
            ConfigureInputMasks();
        }

        private void ConfigureInputMasks()
        {
            // Настраиваем маски для числовых полей
            // Используем TextBox с валидацией вместо MaskedTextBox для простоты
            // В реальном проекте можно использовать MaskedTextBox или NumericUpDown

            txtDensity.TextChanged += NumericTextBox_TextChanged;
            txtSulfurContent.TextChanged += NumericTextBox_TextChanged;
            txtWaterContent.TextChanged += NumericTextBox_TextChanged;
            txtViscosity.TextChanged += NumericTextBox_TextChanged;
            txtFlashPoint.TextChanged += NumericTextBox_TextChanged;
        }

        private void NumericTextBox_TextChanged(object? sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    // Удаляем все нецифровые символы, кроме точки и запятой
                    string cleanText = new string(textBox.Text.Where(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());

                    // Заменяем запятую на точку для унификации
                    cleanText = cleanText.Replace(',', '.');

                    // Проверяем, что точка только одна
                    int dotCount = cleanText.Count(c => c == '.');
                    if (dotCount > 1)
                    {
                        cleanText = cleanText.Substring(0, cleanText.LastIndexOf('.'));
                    }

                    if (textBox.Text != cleanText)
                    {
                        int cursorPos = textBox.SelectionStart;
                        textBox.Text = cleanText;
                        textBox.SelectionStart = Math.Max(0, cursorPos - 1);
                    }
                }
            }
        }

        private void LaboratoryAnalysisForm_Load(object? sender, EventArgs e)
        {
            txtAnalyst.Text = Analyst ?? string.Empty;

            if (Analysis != null && Analysis.Id > 0)
            {
                txtProductName.Text = Analysis.ProductName;

                // Используем инвариантную культуру для корректного форматирования чисел
                txtDensity.Text = Analysis.Density.ToString(CultureInfo.InvariantCulture);
                txtSulfurContent.Text = Analysis.SulfurContent.ToString(CultureInfo.InvariantCulture);
                txtWaterContent.Text = Analysis.WaterContent?.ToString(CultureInfo.InvariantCulture) ?? "";
                txtViscosity.Text = Analysis.Viscosity.ToString(CultureInfo.InvariantCulture);
                txtFlashPoint.Text = Analysis.FlashPoint.ToString(CultureInfo.InvariantCulture);

                dtpAnalysisDate.Value = Analysis.AnalysisDate;
                Text = "Редактировать анализ";
            }
            else
            {
                Analysis = new LaboratoryAnalysis();
                Text = "Добавить анализ";
            }
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (ValidateForm())
            {
                try
                {
                    // Создаем новый объект Analysis, если он был null
                    Analysis ??= new LaboratoryAnalysis();

                    Analysis.ProductName = txtProductName.Text;
                    Analysis.Analyst = txtAnalyst.Text;

                    // Используем инвариантную культуру для парсинга
                    Analysis.Density = double.Parse(txtDensity.Text, CultureInfo.InvariantCulture);
                    Analysis.SulfurContent = double.Parse(txtSulfurContent.Text, CultureInfo.InvariantCulture);

                    Analysis.WaterContent = string.IsNullOrWhiteSpace(txtWaterContent.Text) ?
                        (double?)null : double.Parse(txtWaterContent.Text, CultureInfo.InvariantCulture);

                    Analysis.Viscosity = double.Parse(txtViscosity.Text, CultureInfo.InvariantCulture);
                    Analysis.FlashPoint = int.Parse(txtFlashPoint.Text, CultureInfo.InvariantCulture);
                    Analysis.AnalysisDate = dtpAnalysisDate.Value;

                    // Используем параметризованные запросы
                    if (Analysis.Id > 0)
                    {
                        // Обновление существующей записи
                        UpdateAnalysis();
                    }
                    else
                    {
                        // Добавление новой записи
                        InsertAnalysis();
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateAnalysis()
        {
            string query = @"UPDATE laboratory_analysis 
                            SET product_name = @productName,
                                analyst = @analyst,
                                density = @density,
                                sulfur_content = @sulfurContent,
                                water_content = @waterContent,
                                viscosity = @viscosity,
                                flash_point = @flashPoint,
                                analysis_date = @analysisDate
                            WHERE analysis_id = @analysisId";

            var parameters = new Dictionary<string, object?>
            {
                { "@productName", Analysis!.ProductName },
                { "@analyst", Analysis.Analyst },
                { "@density", Analysis.Density },
                { "@sulfurContent", Analysis.SulfurContent },
                { "@waterContent", Analysis.WaterContent ?? (object?)DBNull.Value },
                { "@viscosity", Analysis.Viscosity },
                { "@flashPoint", Analysis.FlashPoint },
                { "@analysisDate", Analysis.AnalysisDate },
                { "@analysisId", Analysis.Id }
            };

            if (!ExecuteParameterizedQuery(query, parameters))
            {
                throw new Exception("Не удалось обновить запись в базе данных");
            }
        }

        private void InsertAnalysis()
        {
            string query = @"INSERT INTO laboratory_analysis 
                            (product_name, analyst, density, sulfur_content, 
                             water_content, viscosity, flash_point, analysis_date)
                            VALUES 
                            (@productName, @analyst, @density, @sulfurContent,
                             @waterContent, @viscosity, @flashPoint, @analysisDate)";

            var parameters = new Dictionary<string, object?>
            {
                { "@productName", Analysis!.ProductName },
                { "@analyst", Analysis.Analyst },
                { "@density", Analysis.Density },
                { "@sulfurContent", Analysis.SulfurContent },
                { "@waterContent", Analysis.WaterContent ?? (object?)DBNull.Value },
                { "@viscosity", Analysis.Viscosity },
                { "@flashPoint", Analysis.FlashPoint },
                { "@analysisDate", Analysis.AnalysisDate }
            };

            if (!ExecuteParameterizedQuery(query, parameters))
            {
                throw new Exception("Не удалось добавить запись в базу данных");
            }
        }

        private bool ExecuteParameterizedQuery(string query, Dictionary<string, object?> parameters)
        {
            try
            {
                // Предполагаем, что у вас есть строка подключения
                string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1234567890;Database=Oil;";

                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var command = new NpgsqlCommand(query, conn))
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка выполнения запроса: {ex.Message}", "Ошибка базы данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool ValidateForm()
        {
            // Валидация названия продукта
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Введите название продукта", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
                return false;
            }

            // Валидация плотности
            if (!double.TryParse(txtDensity.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double density))
            {
                MessageBox.Show("Введите корректную плотность (например: 0.85)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDensity.Focus();
                return false;
            }

            if (density < MIN_DENSITY || density > MAX_DENSITY)
            {
                MessageBox.Show($"Плотность должна быть в диапазоне {MIN_DENSITY}-{MAX_DENSITY} г/см³",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDensity.Focus();
                return false;
            }

            // Валидация содержания серы
            if (!double.TryParse(txtSulfurContent.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double sulfur))
            {
                MessageBox.Show("Введите корректное содержание серы (например: 1.5)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSulfurContent.Focus();
                return false;
            }

            if (sulfur < MIN_SULFUR || sulfur > MAX_SULFUR)
            {
                MessageBox.Show($"Содержание серы должно быть в диапазоне {MIN_SULFUR}-{MAX_SULFUR}%",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSulfurContent.Focus();
                return false;
            }

            // Валидация содержания воды
            if (!string.IsNullOrWhiteSpace(txtWaterContent.Text))
            {
                if (!double.TryParse(txtWaterContent.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double water))
                {
                    MessageBox.Show("Введите корректное содержание воды (например: 0.1)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWaterContent.Focus();
                    return false;
                }

                if (water < 0 || water > MAX_WATER)
                {
                    MessageBox.Show($"Содержание воды должно быть в диапазоне 0-{MAX_WATER}%",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWaterContent.Focus();
                    return false;
                }
            }

            // Валидация вязкости
            if (!double.TryParse(txtViscosity.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double viscosity))
            {
                MessageBox.Show("Введите корректную вязкость (например: 15.5)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtViscosity.Focus();
                return false;
            }

            if (viscosity < MIN_VISCOSITY || viscosity > MAX_VISCOSITY)
            {
                MessageBox.Show($"Вязкость должна быть в диапазоне {MIN_VISCOSITY}-{MAX_VISCOSITY} сСт",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtViscosity.Focus();
                return false;
            }

            // Валидация температуры вспышки
            if (!int.TryParse(txtFlashPoint.Text, out int flashPoint))
            {
                MessageBox.Show("Введите корректную температуру вспышки (целое число)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFlashPoint.Focus();
                return false;
            }

            if (flashPoint < MIN_FLASH_POINT || flashPoint > MAX_FLASH_POINT)
            {
                MessageBox.Show($"Температура вспышки должна быть в диапазоне {MIN_FLASH_POINT}-{MAX_FLASH_POINT}°C",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFlashPoint.Focus();
                return false;
            }

            return true;
        }
    }
}
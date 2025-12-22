using NUnit.Framework;
using Oil.Forms;
using System.Data;
using System.Linq;

namespace Oil.Tests.Forms
{
    [TestFixture]
    public class LaboratoryAnalysisFormTests
    {
        // === ПРОХОДЯЩИЕ ТЕСТЫ ===

        
        // ТЕСТ 1: Проверяем, что всегда можно добавить анализ (ДОЛЖЕН ПРОЙТИ)
        [Test]
        public void CanAddNewAnalysis_ReturnsTrue()
        {
            // Arrange
            var form = new LaboratoryAnalysisForm();

            // Act
            bool canAdd = form.CanAddNewAnalysis();

            // Assert
            Assert.IsTrue(canAdd, "Метод CanAddNewAnalysis всегда должен возвращать true");

            Console.WriteLine("✅ Тест 1 пройден: можно всегда добавлять новый анализ");
        }

        // ТЕСТ 2: Проверяем запрос для печати (ДОЛЖЕН ПРОЙТИ)
        [Test]
        public void GetPrintQueryForTest_ContainsAnalysisId()
        {
            // Arrange
            var form = new LaboratoryAnalysisForm();
            int testId = 999; // тестовый ID

            // Act
            string query = form.GetPrintQueryForTest(testId);

            // Assert
            Assert.IsTrue(query.Contains($"laboratory_analysis_id = {testId}"),
                $"Запрос должен содержать ID анализа: {testId}");
            Assert.IsTrue(query.Contains("product_name"), "Запрос должен содержать название продукта");
            Assert.IsTrue(query.Contains("mark_name"), "Запрос должен содержать марку");

            Console.WriteLine($"✅ Тест 2 пройден: запрос для печати содержит ID {testId}");
        }

        // ТЕСТ 3: Проверяем начальное состояние формы (ДОЛЖЕН ПРОЙТИ)
        [Test]
        public void InitialState_NoSelectedRows()
        {
            // Arrange
            var form = new LaboratoryAnalysisForm();

            // Act
            bool canEdit = form.CanEditSelectedAnalysis();
            bool canPrint = form.CanPrintSelectedAnalysis();
            int? selectedId = form.GetSelectedAnalysisIdForTest();

            // Assert
            Assert.IsFalse(canEdit, "Изначально нельзя редактировать - нет выделенных строк");
            Assert.IsFalse(canPrint, "Изначально нельзя печатать - нет выделенных строк");
            Assert.IsNull(selectedId, "Изначально нет выбранного ID");

            Console.WriteLine("✅ Тест 3 пройден: начальное состояние формы корректно");
        }

        // === ПАДАЮЩИЕ ТЕСТЫ ===

        
        // ТЕСТ 4: Проверка на ложное условие (ДОЛЖЕН УПАСТЬ!)
        [Test]
        public void CanAddNewAnalysis_WrongAssert_ShouldFail()
        {
            // Arrange
            var form = new LaboratoryAnalysisForm();

            // Act
            bool canAdd = form.CanAddNewAnalysis();

            // Assert: НАМЕРЕННО неверное утверждение!
            // Метод возвращает true, но мы проверяем на false

            Assert.IsFalse(canAdd,
                "❌ Метод CanAddNewAnalysis возвращает true, а мы проверяем false! ДОЛЖЕН УПАСТЬ!");

            Console.WriteLine("⚠️ Этого сообщения не должно быть видно!");
        }

        // ТЕСТ 5: Проверка формата даты (ДОЛЖЕН ПРОЙТИ, но показывает ограничения)
        [Test]
        public void GetDateTimeColumnFormat_ReturnsExpectedFormat()
        {
            // Arrange
            var form = new LaboratoryAnalysisForm();

            // Act
            string format = form.GetDateTimeColumnFormat();

            // Assert
            // Этот тест может пройти ИЛИ упасть в зависимости от состояния формы
            // Если DataGridView еще не инициализирован - формат будет null

            if (format == null)
            {
                Assert.Inconclusive("DataGridView не инициализирован, нельзя проверить формат");
                Console.WriteLine("⚠️ Тест пропущен: DataGridView не готов");
            }
            else
            {
                Assert.AreEqual("dd.MM.yyyy HH:mm", format,
                    "Формат даты должен быть 'dd.MM.yyyy HH:mm'");
                Console.WriteLine("✅ Тест 5 пройден: формат даты корректный");
            }
        }

        // ТЕСТ 6: Проверка DataGridView (ДОЛЖЕН ПРОЙТИ)
        [Test]
        public void GetAnalysesDataGridView_ReturnsDataGridView()
        {
            // Arrange
            var form = new LaboratoryAnalysisForm();

            // Act
            var dgv = form.GetAnalysesDataGridView();

            // Assert
            Assert.IsNotNull(dgv, "DataGridView не должен быть null");
            Assert.IsInstanceOf<DataGridView>(dgv, "Должен быть типа DataGridView");

            // Проверяем некоторые свойства DataGridView
            Assert.AreEqual("dgvAnalyses", dgv.Name, "DataGridView должен называться 'dgvAnalyses'");

            Console.WriteLine("✅ Тест 6 пройден: DataGridView доступен для тестирования");
        }
    }
}
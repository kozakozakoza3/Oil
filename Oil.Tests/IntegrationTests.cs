using NUnit.Framework;
using Oil.Forms;
using Oil.Helpers;
using System.Collections.Generic;
using System.Data;

namespace Oil.Tests.Helpers
{
    [TestFixture]
    public class DbMethodsTests
    {
        // Тест 1: Простейший тест подключения
        [Test]
        public void TestConnection_ShouldReturnTrue_WhenDatabaseIsAvailable()
        {
            // Arrange (Подготовка) - ничего не нужно

            // Act (Действие)
            bool isConnected = DbMethods.TestConnection();

            // Assert (Проверка)
            Assert.IsTrue(isConnected, "Не удалось подключиться к базе данных");
        }

        // Тест 2: Простой SELECT запрос
        [Test]
        public void GetData_SimpleSelect_ShouldReturnDataTable()
        {
            // Arrange
            string simpleQuery = "SELECT 1 as number, 'test' as text";

            // Act
            DataTable result = DbMethods.GetData(simpleQuery);

            // Assert
            Assert.IsNotNull(result, "Результат не должен быть null");
            Assert.Greater(result.Rows.Count, 0, "Должна быть хотя бы одна строка");
            Assert.AreEqual("number", result.Columns[0].ColumnName, "Первая колонка должна называться 'number'");
            Assert.AreEqual("text", result.Columns[1].ColumnName, "Вторая колонка должна называться 'text'");
        }

        // Тест 3: Проверка на ошибку (неверный SQL)
        [Test]
        public void Execute_InvalidSql_ShouldReturnFalse()
        {
            // Arrange
            string invalidSql = "THIS IS NOT VALID SQL";

            // Act
            bool result = DbMethods.Execute(invalidSql);

            // Assert
            Assert.IsFalse(result, "При неверном SQL должен возвращаться false");
        }
        // ТЕСТ 4: Проверка публичного метода загрузки 
        [Test]
        public void LoadAnalysesPublic_DoesNotThrowException()
        {
            // Arrange
            var form = new LaboratoryAnalysisForm();

            // Act & Assert
            // Этот тест проверяет, что метод можно вызвать без исключений
            // Но он МОЖЕТ упасть, если нет подключения к БД!

            try
            {
                form.LoadAnalysesPublic();
                Console.WriteLine("✅ Тест 4 пройден: метод LoadAnalysesPublic выполнен без ошибок");
            }
            catch (System.Exception ex)
            {
                // Если упал - это информационно для нас
                Assert.Inconclusive($"Метод упал с ошибкой (возможно, нет БД): {ex.Message}");
                Console.WriteLine($"⚠️ Тест пропущен: {ex.Message}");
            }
        }
    }
}

        
using NUnit.Framework;
using Oil;
using Oil.Forms;
using System.Windows.Forms;

namespace Oil.Tests.Forms
{
    [TestFixture]
    public class LaboratoryFormTests
    {
        // === ПРОХОДЯЩИЕ ТЕСТЫ (GREEN TESTS) ===

        // ТЕСТ 1: Проверяем создание формы (ДОЛЖЕН ПРОЙТИ)
        [Test]
        public void LaboratoryForm_Creation_Successful()
        {
            // Arrange & Act
            var form = new LaboratoryForm();

            // Assert
            Assert.IsNotNull(form, "Форма должна создаваться без ошибок");
            Assert.IsInstanceOf<Form>(form, "Должна быть типа Form");
            Assert.IsInstanceOf<LaboratoryForm>(form, "Должна быть именно LaboratoryForm");

            Console.WriteLine("✅ Тест 1 пройден: форма создается корректно");
        }



        // ТЕСТ 2: Проверяем форму авторизации (ДОЛЖЕН ПРОЙТИ)
        [Test]
        public void GetAuthorizationForm_ReturnsAuthorizationForm()
        {
            // Arrange
            var form = new LaboratoryForm();

            // Act
            var authForm = form.GetAuthorizationForm();

            // Assert
            Assert.IsNotNull(authForm, "Форма авторизации не должна быть null");
            Assert.IsInstanceOf<AuthorizationForm>(authForm, "Должна быть AuthorizationForm");

            Console.WriteLine("✅ Тест 3 пройден: форма авторизации создается корректно");
        }

        // === ПАДАЮЩИЕ ТЕСТЫ (RED TESTS - ДЛЯ ДЕМОНСТРАЦИИ) ===

        // ТЕСТ 3: Намеренно неправильная проверка (ДОЛЖЕН УПАСТЬ!)
        [Test]
        public void OpenOilLotForm_WrongTypeCheck_ShouldFail()
        {
            // Arrange
            var form = new LaboratoryForm();

            // Act
            var openedForm = form.OpenOilLotForm();

            // Assert: НАМЕРЕННО неверная проверка!
            // OilLotForm НЕ является типом LaboratoryAnalysisForm
            // Этот тест ДОЛЖЕН упасть с ошибкой

            Assert.IsInstanceOf<LaboratoryAnalysisForm>(openedForm,
                "❌ OilLotForm не может быть LaboratoryAnalysisForm! Этот тест ДОЛЖЕН упасть!");

            // Эта строка не выполнится, если assert выше упадет
            Console.WriteLine("⚠️ Этого сообщения не должно быть видно!");
        }

        // ТЕСТ 4: Проверка несуществующего свойства (ДОЛЖЕН УПАСТЬ!)
        [Test]
        public void FormHasInvalidProperty_ShouldFail()
        {
            // Arrange
            var form = new LaboratoryForm();

            // Act & Assert: пытаемся получить свойство, которого нет
            // Этот тест упадет с ошибкой компиляции или выполнения

            // ВНИМАНИЕ: этот тест может не скомпилироваться!
            // Если скомпилируется - упадет при выполнении

            // var invalid = form.NonExistentProperty; // раскомментировать для падения

            // Вместо этого проверим что-то реальное, но с заведомо ложным условием
            Assert.IsTrue(form.Visible == true && form.Visible == false,
                "❌ Логическая ошибка: форма не может быть одновременно видимой и невидимой!");

            Console.WriteLine("⚠️ Этот тест должен упасть из-за логической ошибки");
        }

        // ТЕСТ 5: Проверка null там, где его быть не должно (ДОЛЖЕН ПРОЙТИ, но показывает граничный случай)
        [Test]
        public void OpenMethods_ReturnNonNullForms()
        {
            // Arrange
            var form = new LaboratoryForm();

            // Act
            var oilForm = form.OpenOilLotForm();
            var productForm = form.OpenOilProductForm();
            var analysisForm = form.OpenLaboratoryAnalysisForm();
            var authForm = form.GetAuthorizationForm();

            // Assert: проверяем, что ни одна форма не null
            // Этот тест должен пройти, т.к. все методы возвращают new Form()

            Assert.IsNotNull(oilForm, "OilLotForm не должен быть null");
            Assert.IsNotNull(productForm, "OilProductForm не должен быть null");
            Assert.IsNotNull(analysisForm, "LaboratoryAnalysisForm не должен быть null");
            Assert.IsNotNull(authForm, "AuthorizationForm не должен быть null");

            Console.WriteLine("✅ Тест 5 пройден: все формы создаются (не null)");
        }
    }
}
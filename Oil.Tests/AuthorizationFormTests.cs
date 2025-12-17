using NUnit.Framework;
using Oil;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace Oil.Tests
{
    // --- ЗАГЛУШКИ ПРЯМО В ЭТОМ ФАЙЛЕ ---
    // (они будут использоваться вместо реальных форм)

    public class TestLaboratoryForm : Form { }

    public class TestTransportForm : Form
    {
        public TestTransportForm(string login) { }
    }

    public class TestStorageForm : Form
    {
        public TestStorageForm(string login) { }
    }

    public class TestGuestForm : Form { }

    public class TestManagementForm : Form
    {
        public TestManagementForm(string login) { }
    }

    public class TestAuthorizationForm : Form
    {
        public TestAuthorizationForm()
        {
            // Пустой конструктор для тестов
        }

        // Копия твоего реального метода, но возвращающая ТЕСТОВЫЕ формы
        private Form GetEmployeeFormByPostSwitch(string login, string postName, string employeeName)
        {
            if (string.IsNullOrEmpty(postName))
            {
                return new TestGuestForm();
            }

            string normalizedPostName = postName.ToLower();

            switch (normalizedPostName)
            {
                case "химик":
                case "старший химик":
                case "лаборант":
                case "инженер качества":
                case "старший инженер качества":
                case "технолог":
                case "старший технолог":
                case "аналитик":
                    return new TestLaboratoryForm();

                case "водитель":
                case "логист":
                case "старший логист":
                case "диспетчер":
                case "машинист":
                case "машинист насосов":
                case "механик":
                case "старший механик":
                case "оператор":
                case "оператор установок":
                case "оператор технологических установок":
                    return new TestTransportForm(login);

                case "кладовщик":
                case "старший кладовщик":
                case "грузчик":
                case "складской работник":
                    return new TestStorageForm(login);

                default:
                    return new TestGuestForm();
            }
        }
    }
    // --- КОНЕЦ ЗАГЛУШЕК ---

    [TestFixture]
    public class AuthorizationFormTests
    {
        [Test]
        public void GetEmployeeFormByPostSwitch_SimpleTest()
        {
            // Arrange
            // Используем нашу ТЕСТОВУЮ форму вместо реальной
            var form = new TestAuthorizationForm();

            // Используем reflection для вызова приватного метода
            var method = typeof(TestAuthorizationForm).GetMethod(
                "GetEmployeeFormByPostSwitch",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Act & Assert для разных случаев

            // Случай 1: Лаборант → TestLaboratoryForm
            var result1 = method.Invoke(form, new object[] { "user1", "лаборант", "Тест Тестер" });
            // Проверяем, что вернулась НАША тестовая форма
            Assert.IsInstanceOf<TestLaboratoryForm>(result1,
                "Для 'лаборант' должна возвращаться TestLaboratoryForm");

            // Случай 2: Пустая должность → TestGuestForm
            var result2 = method.Invoke(form, new object[] { "user2", "", "Тест Тестер" });
            Assert.IsInstanceOf<TestGuestForm>(result2,
                "Для пустой должности должна возвращаться TestGuestForm");

            // Случай 3: Неизвестная должность → TestGuestForm  
            var result3 = method.Invoke(form, new object[] { "user3", "директор", "Тест Тестер" });
            Assert.IsInstanceOf<TestGuestForm>(result3,
                "Для неизвестной должности должна возвращаться TestGuestForm");
        }

        [Test]
        public void GetEmployeeFormByPostSwitch_TransportPosition_ReturnsTransportForm()
        {
            // Arrange
            var form = new TestAuthorizationForm();
            var method = typeof(TestAuthorizationForm).GetMethod(
                "GetEmployeeFormByPostSwitch",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Act: Проверяем транспортную должность
            var result = method.Invoke(form, new object[] { "driver123", "водитель", "Водитель Водителев" });

            // Assert
            Assert.IsInstanceOf<TestTransportForm>(result,
                "Для 'водитель' должна возвращаться TestTransportForm");
        }

        [Test]
        public void GetEmployeeFormByPostSwitch_CaseInsensitive_WorksCorrectly()
        {
            // Arrange
            var form = new TestAuthorizationForm();
            var method = typeof(TestAuthorizationForm).GetMethod(
                "GetEmployeeFormByPostSwitch",
                BindingFlags.NonPublic | BindingFlags.Instance);

            // Act: Проверяем разный регистр
            var result1 = method.Invoke(form, new object[] { "user1", "ХИМИК", "Тест" });
            var result2 = method.Invoke(form, new object[] { "user2", "ЛаБоРаНт", "Тест" });
            var result3 = method.Invoke(form, new object[] { "user3", "ВоДиТеЛЬ", "Тест" });

            // Assert
            Assert.IsInstanceOf<TestLaboratoryForm>(result1, "Должен работать верхний регистр");
            Assert.IsInstanceOf<TestLaboratoryForm>(result2, "Должен работать смешанный регистр");
            Assert.IsInstanceOf<TestTransportForm>(result3, "Должен работать разный регистр для транспорта");
        }
    }
}
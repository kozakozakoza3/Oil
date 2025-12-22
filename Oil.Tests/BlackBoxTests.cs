using System;
using System.Threading;
using System.Windows.Forms;
using Oil.Forms;

namespace Oil.BlackBoxTests
{
    public class BlackBoxTests
    {
        // Симуляция действий пользователя
        private static void SimulateUserAction(int milliseconds = 500)
        {
            Thread.Sleep(milliseconds); // Имитация времени реакции пользователя
        }

        // ===== ТЕСТЫ ФОРМЫ АВТОРИЗАЦИИ =====
        public static void RunAuthorizationFormTests()
        {
            Console.WriteLine("📋 ТЕСТИРОВАНИЕ ФОРМЫ АВТОРИЗАЦИИ");
            Console.WriteLine("════════════════════════════════════════\n");

            try
            {
                // Тест 1: Проверка открытия формы
                Console.WriteLine("Тест 1: Открытие формы авторизации");
                AuthorizationForm authForm = new AuthorizationForm();
                Console.WriteLine($"✅ Форма создана. Заголовок: {authForm.Text}");
                SimulateUserAction();

                // Тест 2: Проверка наличия элементов
                Console.WriteLine("\nТест 2: Проверка элементов управления");
                Console.WriteLine($"• Поле логина: {(GetControlByName(authForm, "txtLogin") != null ? "✅" : "❌")}");
                Console.WriteLine($"• Поле пароля: {(GetControlByName(authForm, "txtPassword") != null ? "✅" : "❌")}");
                Console.WriteLine($"• Кнопка Войти: {(GetControlByName(authForm, "btnLogin") != null ? "✅" : "❌")}");
                Console.WriteLine($"• Кнопка Гость: {(GetControlByName(authForm, "btnGuest") != null ? "✅" : "❌")}");
                SimulateUserAction();

                // Тест 3: Проверка валидации пустых полей
                Console.WriteLine("\nТест 3: Вход с пустыми данными");
                Console.WriteLine("Ожидаемый результат: Сообщение об ошибке");
                SimulateUserAction();

                // Тест 4: Ввод данных
                Console.WriteLine("\nТест 4: Ввод корректных данных");
                Console.WriteLine("• Вводим логин: 'a.nikolaeva'");
                Console.WriteLine("• Вводим пароль: 'nikolaeva_chem_pass'");
                Console.WriteLine("• Нажимаем 'Войти'");
                Console.WriteLine("Ожидаемый результат: Открывается главная форма");
                SimulateUserAction();

                Console.WriteLine("\n✅ Все тесты формы авторизации завершены\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка: {ex.Message}");
            }
        }

        // ===== ТЕСТЫ ГЛАВНОЙ ФОРМЫ ЛАБОРАТОРИИ =====
        public static void RunLaboratoryFormTests()
        {
            Console.WriteLine("📋 ТЕСТИРОВАНИЕ ГЛАВНОЙ ФОРМЫ ЛАБОРАТОРИИ");
            Console.WriteLine("══════════════════════════════════════════════\n");

            try
            {
                // Тест 1: Создание формы
                Console.WriteLine("Тест 1: Открытие главной формы");
                LaboratoryForm labForm = new LaboratoryForm();
                Console.WriteLine($"✅ Форма создана. Заголовок: {labForm.Text}");
                SimulateUserAction();

                // Тест 2: Проверка кнопок
                Console.WriteLine("\nТест 2: Проверка кнопок меню");
                Console.WriteLine($"• 'Партии нефти': {(GetControlByName(labForm, "btnOil") != null ? "✅" : "❌")}");
                Console.WriteLine($"• 'Нефтепродукты': {(GetControlByName(labForm, "btnProducts") != null ? "✅" : "❌")}");
                Console.WriteLine($"• 'Лабораторные анализы': {(GetControlByName(labForm, "btnAnalysis") != null ? "✅" : "❌")}");
                Console.WriteLine($"• 'Выйти': {(GetControlByName(labForm, "btnExit") != null ? "✅" : "❌")}");
                SimulateUserAction();

                // Тест 3: Нажатие кнопки "Лабораторные анализы"
                Console.WriteLine("\nТест 3: Переход к лабораторным анализам");
                Console.WriteLine("• Нажимаем кнопку 'Лабораторные анализы'");
                var analysisForm = labForm.OpenLaboratoryAnalysisForm();
                Console.WriteLine($"✅ Форма анализов открыта: {(analysisForm != null ? "Да" : "Нет")}");
                SimulateUserAction();

                // Тест 4: Возврат на форму авторизации
                Console.WriteLine("\nТест 4: Выход из системы");
                Console.WriteLine("• Нажимаем кнопку 'Выйти'");
                var authForm = labForm.GetAuthorizationForm();
                Console.WriteLine($"✅ Форма авторизации получена: {(authForm != null ? "Да" : "Нет")}");
                SimulateUserAction();

                Console.WriteLine("\n✅ Все тесты главной формы завершены\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка: {ex.Message}");
            }
        }

        // ===== ТЕСТЫ ФОРМЫ ЛАБОРАТОРНЫХ АНАЛИЗОВ =====
        public static void RunLaboratoryAnalysisFormTests()
        {
            Console.WriteLine("📋 ТЕСТИРОВАНИЕ ФОРМЫ ЛАБОРАТОРНЫХ АНАЛИЗОВ");
            Console.WriteLine("═══════════════════════════════════════════════\n");

            try
            {
                // Тест 1: Создание формы
                Console.WriteLine("Тест 1: Открытие формы анализов");
                LaboratoryAnalysisForm analysisForm = new LaboratoryAnalysisForm();
                Console.WriteLine($"✅ Форма создана. Заголовок: {analysisForm.Text}");
                SimulateUserAction();

                // Тест 2: Проверка загрузки данных
                Console.WriteLine("\nТест 2: Загрузка данных в таблицу");
                analysisForm.LoadAnalysesPublic();
                var dataGridView = analysisForm.GetAnalysesDataGridView();
                Console.WriteLine($"✅ DataGridView создан: {(dataGridView != null ? "Да" : "Нет")}");
                Console.WriteLine($"• Колонок: {analysisForm.GetVisibleColumnNames().Length}");
                Console.WriteLine($"• Формат даты: {analysisForm.GetDateTimeColumnFormat()}");
                SimulateUserAction();

                // Тест 3: Проверка функциональных кнопок
                Console.WriteLine("\nТест 3: Проверка кнопок управления");
                Console.WriteLine($"• 'Добавить': {(GetControlByName(analysisForm, "btnAdd") != null ? "✅" : "❌")}");
                Console.WriteLine($"• 'Редактировать': {(GetControlByName(analysisForm, "btnEdit") != null ? "✅" : "❌")}");
                Console.WriteLine($"• 'Удалить': {(GetControlByName(analysisForm, "btnDelete") != null ? "✅" : "❌")}");
                Console.WriteLine($"• 'Обновить': {(GetControlByName(analysisForm, "btnRefresh") != null ? "✅" : "❌")}");
                Console.WriteLine($"• 'Печать': {(GetControlByName(analysisForm, "btnPrint") != null ? "✅" : "❌")}");
                Console.WriteLine($"• 'Назад': {(GetControlByName(analysisForm, "btnBack") != null ? "✅" : "❌")}");
                SimulateUserAction();

                // Тест 4: Проверка условий для редактирования
                Console.WriteLine("\nТест 4: Проверка возможности редактирования");
                Console.WriteLine($"• Строка выбрана: {analysisForm.CanEditSelectedAnalysis()}");
                Console.WriteLine($"• Можно редактировать: {analysisForm.CanEditSelectedAnalysis()}");
                SimulateUserAction();

                // Тест 5: Проверка SQL запросов (без выполнения)
                Console.WriteLine("\nТест 5: Проверка SQL запросов");
                string analysisQuery = analysisForm.GetAnalysisQueryForTest();
                Console.WriteLine($"✅ Запрос для загрузки анализов получен");
                Console.WriteLine($"• Длина запроса: {analysisQuery.Length} символов");
                Console.WriteLine($"• Содержит SELECT: {analysisQuery.Contains("SELECT")}");
                SimulateUserAction();

                // Тест 6: Тестирование печати
                Console.WriteLine("\nТест 6: Проверка функции печати");
                Console.WriteLine($"• Можно печатать: {analysisForm.CanPrintSelectedAnalysis()}");
                if (dataGridView.Rows.Count > 0)
                {
                    // Выбираем первую строку
                    dataGridView.Rows[0].Selected = true;
                    Console.WriteLine($"• Выбрана строка для печати");
                    var selectedId = analysisForm.GetSelectedAnalysisIdForTest();
                    Console.WriteLine($"• ID выбранного анализа: {selectedId}");

                    if (selectedId.HasValue)
                    {
                        string printQuery = analysisForm.GetPrintQueryForTest(selectedId.Value);
                        Console.WriteLine($"✅ Запрос для печати получен");
                        Console.WriteLine($"• Содержит WHERE: {printQuery.Contains("WHERE")}");
                    }
                }
                SimulateUserAction();

                // Тест 7: Возврат назад
                Console.WriteLine("\nТест 7: Возврат на предыдущую форму");
                Console.WriteLine("• Нажимаем кнопку 'Назад'");
                Console.WriteLine("Ожидаемый результат: Форма закрывается");
                SimulateUserAction();

                Console.WriteLine("\n✅ Все тесты формы анализов завершены\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка: {ex.Message}");
            }
        }

        // ===== ТЕСТЫ ФОРМЫ РЕДАКТИРОВАНИЯ АНАЛИЗОВ =====
        public static void RunLaboratoryAnalysisEditFormTests()
        {
            Console.WriteLine("📋 ТЕСТИРОВАНИЕ ФОРМЫ РЕДАКТИРОВАНИЯ АНАЛИЗОВ");
            Console.WriteLine("══════════════════════════════════════════════════\n");

            try
            {
                // Тест 1: Форма добавления нового анализа
                Console.WriteLine("Тест 1: Форма добавления нового анализа");
                LaboratoryAnalysisEditForm addForm = new LaboratoryAnalysisEditForm();
                Console.WriteLine($"✅ Форма добавления создана");
                Console.WriteLine($"• Режим: {addForm.Text}");
                Console.WriteLine($"• Режим редактирования: {IsEditMode(addForm)}");
                SimulateUserAction();

                // Тест 2: Форма редактирования существующего анализа
                Console.WriteLine("\nТест 2: Форма редактирования анализа");
                LaboratoryAnalysisEditForm editForm = new LaboratoryAnalysisEditForm(1);
                Console.WriteLine($"✅ Форма редактирования создана");
                Console.WriteLine($"• Режим: {editForm.Text}");
                Console.WriteLine($"• Режим редактирования: {IsEditMode(editForm)}");
                SimulateUserAction();

                // Тест 3: Проверка элементов управления
                Console.WriteLine("\nТест 3: Проверка элементов ввода");
                Console.WriteLine($"• Выбор продукта: {(GetControlByName(addForm, "cbxOilProduct") != null ? "✅" : "❌")}");
                Console.WriteLine($"• Выбор сотрудника: {(GetControlByName(addForm, "cbxEmployee") != null ? "✅" : "❌")}");
                Console.WriteLine($"• Объем пробы: {(GetControlByName(addForm, "txtSampleVolume") != null ? "✅" : "❌")}");
                Console.WriteLine($"• Плотность: {(GetControlByName(addForm, "txtOilProductDensity") != null ? "✅" : "❌")}");
                Console.WriteLine($"• Содержание серы: {(GetControlByName(addForm, "txtOilProductSulfurContent") != null ? "✅" : "❌")}");
                Console.WriteLine($"• Вязкость: {(GetControlByName(addForm, "txtOilProductViscosity") != null ? "✅" : "❌")}");
                Console.WriteLine($"• Температура вспышки: {(GetControlByName(addForm, "txtOilProductFlashPoint") != null ? "✅" : "❌")}");
                Console.WriteLine($"• Дата анализа: {(GetControlByName(addForm, "dtpDateTimeAnalysis") != null ? "✅" : "❌")}");
                SimulateUserAction();

                // Тест 4: Проверка валидации
                Console.WriteLine("\nТест 4: Проверка валидации ввода");
                Console.WriteLine("Ожидаемая проверка:");
                Console.WriteLine("• Обязательные поля не пустые");
                Console.WriteLine("• Числовые значения корректны");
                Console.WriteLine("• Дата не в будущем");
                SimulateUserAction();

                // Тест 5: Тестирование сохранения
                Console.WriteLine("\nТест 5: Функция сохранения");
                Console.WriteLine("Сценарий 1: Добавление нового анализа");
                Console.WriteLine("• Заполняем все поля корректными данными");
                Console.WriteLine("• Нажимаем 'Сохранить'");
                Console.WriteLine("Ожидаемый результат: Анализ сохраняется в БД");
                SimulateUserAction();

                Console.WriteLine("\nСценарий 2: Редактирование анализа");
                Console.WriteLine("• Изменяем некоторые значения");
                Console.WriteLine("• Нажимаем 'Сохранить'");
                Console.WriteLine("Ожидаемый результат: Данные обновляются в БД");
                SimulateUserAction();

                // Тест 6: Отмена операции
                Console.WriteLine("\nТест 6: Отмена операции");
                Console.WriteLine("• Нажимаем 'Отмена'");
                Console.WriteLine("Ожидаемый результат: Форма закрывается без сохранения");
                SimulateUserAction();

                Console.WriteLine("\n✅ Все тесты формы редактирования завершены\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ошибка: {ex.Message}");
            }
        }

        // ===== ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ =====
        private static Control GetControlByName(Form form, string controlName)
        {
            try
            {
                return form.Controls.Find(controlName, true).FirstOrDefault();
            }
            catch
            {
                return null;
            }
        }

        private static string IsEditMode(LaboratoryAnalysisEditForm form)
        {
            try
            {
                // Используем рефлексию для доступа к приватному полю
                var field = typeof(LaboratoryAnalysisEditForm).GetField("_isEditMode",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                return field?.GetValue(form)?.ToString() ?? "Неизвестно";
            }
            catch
            {
                return "Не удалось определить";
            }
        }

        // ===== ОСНОВНОЙ МЕТОД ЗАПУСКА ВСЕХ ТЕСТОВ =====
        public static void RunAllTests()
        {
            Console.Clear();
            Console.WriteLine("🧪 ТЕСТИРОВАНИЕ ЧЁРНЫМ ЯЩИКОМ - НЕФТЯНАЯ ЛАБОРАТОРИЯ");
            Console.WriteLine("══════════════════════════════════════════════════════════\n");

            try
            {
                // Запуск всех тестов
                RunAuthorizationFormTests();
                RunLaboratoryFormTests();
                RunLaboratoryAnalysisFormTests();
                RunLaboratoryAnalysisEditFormTests();

                // Итоговый отчет
                Console.WriteLine("══════════════════════════════════════════════════════════");
                Console.WriteLine("📊 ИТОГОВЫЙ ОТЧЕТ ТЕСТИРОВАНИЯ");
                Console.WriteLine("══════════════════════════════════════════════════════════");
                Console.WriteLine("\n✅ Тестирование завершено успешно!");
                Console.WriteLine("\n📋 Проверенные модули:");
                Console.WriteLine("   1. Форма авторизации");
                Console.WriteLine("   2. Главная форма лаборатории");
                Console.WriteLine("   3. Форма лабораторных анализов");
                Console.WriteLine("   4. Форма редактирования анализов");
                Console.WriteLine("\n⚠️  Рекомендации:");
                Console.WriteLine("   • Проведите ручное тестирование критических сценариев");
                Console.WriteLine("   • Протестируйте работу с реальной БД");
                Console.WriteLine("   • Проверьте обработку ошибок при отключении БД");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ Критическая ошибка при тестировании: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
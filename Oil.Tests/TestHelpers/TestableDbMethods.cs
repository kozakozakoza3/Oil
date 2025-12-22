using Moq;
using Npgsql;
using Oil.Helpers;
using System.Data;

namespace Oil.Tests.TestHelpers
{
    // Этот класс наследуется от оригинального DbMethods
    // и позволяет подменять внутренние зависимости
    public class TestableDbMethods : DbMethods
    {
        private NpgsqlConnection _mockConnection;
        private NpgsqlDataAdapter _mockDataAdapter;

        // Методы для подмены объектов
        public void SetMockConnection(NpgsqlConnection mockConnection)
        {
            _mockConnection = mockConnection;
        }

        public void SetMockDataAdapter(NpgsqlDataAdapter mockDataAdapter)
        {
            _mockDataAdapter = mockDataAdapter;
        }

        // Переопределяем метод, который создает подключение
        // Вместо реального подключения возвращаем mock
        protected override NpgsqlConnection CreateConnection(string connectionString)
        {
            return _mockConnection ?? base.CreateConnection(connectionString);
        }

        // Переопределяем метод, который создает адаптер
        protected override NpgsqlDataAdapter CreateDataAdapter(string query, NpgsqlConnection conn)
        {
            return _mockDataAdapter ?? base.CreateDataAdapter(query, conn);
        }

        // Публичные методы для тестирования private-методов
        public DataTable GetDataPublic(string query) => GetData(query);
    }
}

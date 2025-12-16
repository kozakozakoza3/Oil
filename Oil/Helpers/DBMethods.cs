using Npgsql;
using Oil.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace Oil.Helpers
{
    public class DbMethods
    {
        private static readonly string ConnectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=1234567890;Database=Oil;";

        // 1. Получить данные из таблицы
        public static DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка БД");
            }
            return dt;
        }

        // 2. Выполнить команду (INSERT, UPDATE, DELETE)
        public static bool Execute(string query)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка БД");
                return false;
            }
        }

        // 3. Удалить запись по ID
        public static bool Delete(string tableName, int id)
        {
            string query = $"DELETE FROM {tableName} WHERE {tableName}_id = {id}";
            return Execute(query);
        }

        // 4. Получить все записи из таблицы
        public static DataTable GetAll(string tableName)
        {
            return GetData($"SELECT * FROM {tableName}");
        }

        // 6. Проверить подключение
        public static bool TestConnection()
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
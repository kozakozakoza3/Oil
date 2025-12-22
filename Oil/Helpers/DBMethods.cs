using Npgsql;
using Oil.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Oil.Helpers
{
    public class DbMethods
    {
        private static readonly string ConnectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=1234567890;Database=Oil;";

        // 1. Получить данные из таблицы (без параметров)
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

        // 1a. Получить данные из таблицы с параметрами
        public static DataTable GetData(string query, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        // Добавляем параметры
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        using (NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
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

        // 2a. Выполнить команду с параметрами
        public static bool Execute(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        // Добавляем параметры
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

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
            string query = $"DELETE FROM {tableName} WHERE {tableName}_id = @id";

            var parameters = new Dictionary<string, object>
            {
                { "@id", id }
            };

            return Execute(query, parameters);
        }

        // 4. Получить все записи из таблицы
        public static DataTable GetAll(string tableName)
        {
            return GetData($"SELECT * FROM {tableName}");
        }

        // 5. Выполнить запрос и получить скалярное значение
        public static object ExecuteScalar(string query)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка БД");
                return null;
            }
        }

        // 5a. Выполнить запрос с параметрами и получить скалярное значение
        public static object ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
                {
                    conn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        // Добавляем параметры
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка БД");
                return null;
            }
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
        protected virtual NpgsqlConnection CreateConnection(string connectionString)
        {
            return new NpgsqlConnection(connectionString);
        }

        protected virtual NpgsqlDataAdapter CreateDataAdapter(string query, NpgsqlConnection conn)
        {
            return new NpgsqlDataAdapter(query, conn);
        }
    }
}
       
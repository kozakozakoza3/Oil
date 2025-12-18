using System;
using System.Data;

namespace Oil.Helpers
{
    public static class SafeConverter
    {
        public static int ToInt32(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;

            if (int.TryParse(value.ToString(), out int result))
                return result;

            return 0;
        }

        public static string ToString(object value)
        {
            if (value == null || value == DBNull.Value)
                return string.Empty;

            return value.ToString();
        }

        public static DateTime ToDateTime(object value)
        {
            if (value == null || value == DBNull.Value)
                return DateTime.Now;

            if (DateTime.TryParse(value.ToString(), out DateTime result))
                return result;

            return DateTime.Now;
        }
        public static int ToInt(object value, int defaultValue = 0)
        {
            if (value == null || value == DBNull.Value)
                return defaultValue;

            if (int.TryParse(value.ToString(), out int result))
                return result;

            return defaultValue;
        }
        // Новый метод для безопасного получения значения из ComboBox
        public static int GetComboBoxValue(ComboBox comboBox, int defaultValue = -1)
        {
            if (comboBox?.SelectedValue == null)
                return defaultValue;

            try
            {
                if (comboBox.SelectedValue is DataRowView rowView)
                {
                    object value = rowView.Row[comboBox.ValueMember];
                    return ToInt(value, defaultValue);
                }

                // Если это уже простое значение
                return ToInt(comboBox.SelectedValue, defaultValue);
            }
            catch
            {
                return defaultValue;
            }
        }
        public static DateTime? ToNullableDateTime(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            if (DateTime.TryParse(value.ToString(), out DateTime result))
                return result;

            return null;
        }

        public static int? ToNullableInt32(object value)
        {
            if (value == null || value == DBNull.Value)
                return null;

            if (int.TryParse(value.ToString(), out int result))
                return result;

            return null;
        }

        public static decimal ToDecimal(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0m;

            if (decimal.TryParse(value.ToString(), out decimal result))
                return result;

            return 0m;
        }

        public static bool ToBoolean(object value)
        {
            if (value == null || value == DBNull.Value)
                return false;

            if (bool.TryParse(value.ToString(), out bool result))
                return result;

            // Попробуем преобразовать 1/0
            if (value.ToString() == "1")
                return true;
            if (value.ToString() == "0")
                return false;

            return false;
        }

        public static string TruncateString(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static string FormatPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return string.Empty;

            // Удаляем все нецифровые символы
            string digits = System.Text.RegularExpressions.Regex.Replace(phone, @"[^\d]", "");

            // Форматируем в зависимости от длины
            if (digits.Length == 11) // +7 (XXX) XXX-XX-XX
                return $"+{digits[0]} ({digits.Substring(1, 3)}) {digits.Substring(4, 3)}-{digits.Substring(7, 2)}-{digits.Substring(9, 2)}";
            else if (digits.Length == 10) // (XXX) XXX-XX-XX
                return $"({digits.Substring(0, 3)}) {digits.Substring(3, 3)}-{digits.Substring(6, 2)}-{digits.Substring(8, 2)}";
            else
                return phone;
        }
    }
}
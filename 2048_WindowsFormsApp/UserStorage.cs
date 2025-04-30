using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace _2048_WindowsFormsApp
{
    public class UserStorage
    {
        private static readonly string _filePath = "usersResults.json";

        // Сохраняем всех пользователей в файл
        public static void Save(List<User> users)
        {
            try
            {
                string json = JsonConvert.SerializeObject(users);
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        // Загружаем пользователей из файла
        public static List<User> Load()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}");
            }
            return new List<User>();
        }

    }
}

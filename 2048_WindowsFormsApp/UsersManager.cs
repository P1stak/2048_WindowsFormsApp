using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace _2048_WindowsFormsApp
{
    public class UsersManager
    {
        private static List<User> _users = UserStorage.Load();

        // Добавляем нового пользователя (или обновляем счёт, если он уже есть)
        public static void Add(User newUser)
        {
            var existingUser = _users.Find(u => u.Name == newUser.Name);
            if (existingUser != null)
            {
                if (newUser.Score > existingUser.Score)
                {
                    existingUser.Score = newUser.Score;
                }
            }
            else
            {
                _users.Add(newUser);
            }

            UserStorage.Save(_users); // Сохраняем изменения
        }

        // Получаем всех пользователей
        public static List<User> GetAll()
        {
            return _users;
        }
    }
}

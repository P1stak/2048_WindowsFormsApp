using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace _2048_WindowsFormsApp
{
    public class UsersManager
    {
        private static readonly string _filePath = "UsersResult.json";

        // получение
        public static List<User> GetAll()
        {
            if (FileProvider.Exist(_filePath))
            {
                var jsonData = FileProvider.GetValue(_filePath);
                return JsonConvert.DeserializeObject<List<User>>(jsonData);
            }
            return new List<User>();
        }

        //добавление
        public static void Add(User newUser)
        {
            var users = GetAll();
            users.Add(newUser);

            //сохраняем
            var jsonData = JsonConvert.SerializeObject(users);
            FileProvider.Replace(_filePath, jsonData);

        }
    }
}

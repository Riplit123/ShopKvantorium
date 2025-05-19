using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopKvantorium
{
    public class User
    {
        public string Fioname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public static class UserService
    {
        private const string UsersKey = "stored_users";

        public static List<User> GetUsers()
        {
            var usersJson = Preferences.Get(UsersKey, string.Empty);
            return string.IsNullOrEmpty(usersJson)
                ? new List<User>()
                : JsonSerializer.Deserialize<List<User>>(usersJson);
        }

        public static void SaveUsers(List<User> users)
        {
            var usersJson = JsonSerializer.Serialize(users);
            Preferences.Set(UsersKey, usersJson);
        }
    }
}

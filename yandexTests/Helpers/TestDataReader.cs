using Newtonsoft.Json;
using System.Text.Json;
using yandexTests.MailData;

namespace yandexTests.Helpers
{
    public class TestDataReader
    {
        public List<User> GetTestUsers()
        {
            string jsonString = File.ReadAllText("C:/dev/yandexTests/yandexTests/MailData/MailDataTest.json");
            JsonDocument jsonDocument = JsonDocument.Parse(jsonString);
            List<User> users = new List<User>();

            foreach (var userElement in jsonDocument.RootElement.GetProperty("users").EnumerateArray())
            {
                var user = new User
                {
                    Login = userElement.GetProperty("login").GetString(),
                    Email = userElement.GetProperty("email").GetString(),
                    Password = userElement.GetProperty("password").GetString(),
                    PasswordSMTP = userElement.GetProperty("passwordSMTP").GetString()
                };
                users.Add(user);
            }

            return users;
        }
    }
}

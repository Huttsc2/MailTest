using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yandexTests.MailData;

namespace yandexTests.Helpers
{
    public class TestDataReader
    {
        public User GetTestUser()
        {
            using StreamReader r = new($"C:/dev/yandexTests/yandexTests/MailData/MailDataTest.json");
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<User>(json);
        }
    }
}

using Newtonsoft.Json;
using yandexTests.MailData;

namespace yandexTests.Helpers
{
    public class TestDataReader
    {
        public Users GetTestUsers()
        {
            string path = PathFinder.GetRootDirectory();
            using StreamReader r = new(path + "/MailData/MailDataTest.json");
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<Users>(json);
        }
    }
}

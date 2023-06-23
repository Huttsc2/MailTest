using Newtonsoft.Json;
using System.Net.Mail;

namespace yandexTests.Helpers
{
    public class SmtpClientDataReader
    {
        public SmtpClient GetSmtpClient()
        {
            string path = PathFinder.GetRootDirectory();
            using StreamReader r = new(path + "/SMTP/SmtpClientData.json");
            string json = r.ReadToEnd();
            return JsonConvert.DeserializeObject<SmtpClient>(json);
        }
    }
}

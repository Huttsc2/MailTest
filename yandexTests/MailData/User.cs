using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace yandexTests.MailData
{
    public class User
    {
        [JsonPropertyName("login1")]
        public string Login1 { get; set; }

        [JsonPropertyName("login2")]
        public string Login2 { get; set; }

        [JsonPropertyName("password1")]
        public string Password1 { get; set; }

        [JsonPropertyName("password2")]
        public string Password2 { get; set; }

        [JsonPropertyName("email1")]
        public string Email1 { get; set; }

        [JsonPropertyName("email2")]
        public string Email2 { get; set; }

        [JsonPropertyName("password1SMTP")]
        public string Password1SMTP { get; set; }

        [JsonPropertyName("password2SMTP")]
        public string Password2SMTP { get; set; }
    }
}

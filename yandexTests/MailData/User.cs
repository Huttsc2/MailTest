using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace yandexTests.MailData
{
    public class User
    {
        [JsonProperty("login1", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("login1")]
        public string Login1 { get; set; }

        [JsonProperty("login2", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("login2")]
        public string Login2 { get; set; }

        [JsonProperty("password1", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("password1")]
        public string Password1 { get; set; }

        [JsonProperty("password2", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("password2")]
        public string Password2 { get; set; }

        [JsonProperty("email1", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email1")]
        public string Email1 { get; set; }

        [JsonProperty("email2", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("email2")]
        public string Email2 { get; set; }

        [JsonProperty("password1SMTP", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("password1SMTP")]
        public string Password1SMTP { get; set; }

        [JsonProperty("password2SMTP", NullValueHandling = NullValueHandling.Ignore)]
        [JsonPropertyName("password2SMTP")]
        public string Password2SMTP { get; set; }
    }
}

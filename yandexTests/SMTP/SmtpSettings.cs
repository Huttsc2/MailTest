using System.Text.Json.Serialization;

namespace yandexTests.SMTP
{
    public class SmtpSettings
    {
        [JsonPropertyName("port")]
        public int Port { get; set; }

        [JsonPropertyName("host")]
        public string Host { get; set; }

        [JsonPropertyName("enableSsl")]
        public bool EnableSsl { get; set; }

        [JsonPropertyName("useDefaultCredentials")]
        public bool UseDefaultCredentials { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace yandexTests.MailData
{
    public class User
    {
        [JsonPropertyName("login")]
        public string? Login { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("password")]
        public string? Password { get; set; }

        [JsonPropertyName("passwordSMTP")]
        public string? PasswordSMTP { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace yandexTests.MailData
{
    public class Users
    {
        [JsonPropertyName("sender")]
        public User Sender { get; set; }

        [JsonPropertyName("recipient")]
        public User Recipient { get; set; }

    }
}

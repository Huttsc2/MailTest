using System.Text;

namespace yandexTests.Helpers
{
    public class RandomString
    {
        public string GetRandomString(int lenght = 4)
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder result = new StringBuilder(lenght);
            for (int i = 0; i < lenght; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }
    }
}

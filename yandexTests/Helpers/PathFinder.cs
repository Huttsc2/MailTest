using System.Text.RegularExpressions;

namespace yandexTests.Helpers
{
    public class PathFinder
    {
        public static string GetRootDirectory()
        {
            string dir = Directory.GetCurrentDirectory();
            Regex reg = new(".{0,}yandexTests");
            return reg.Match(dir).Captures.First().Value;
        }
    }
}

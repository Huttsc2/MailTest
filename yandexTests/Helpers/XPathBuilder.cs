namespace yandexTests.Helpers
{
    public class XPathBuilder
    {
        public string GetXPathBySubject(string subject)
        {
            string xpath = "//span[@title='" + subject + "']";
            return xpath;
        }
    }
}

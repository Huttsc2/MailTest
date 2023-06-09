using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yandexTests
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

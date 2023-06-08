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
            return "//span[@title='" + subject + "']";
        }
    }
}

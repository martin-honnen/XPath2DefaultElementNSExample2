using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Wmhelp.XPath2;

namespace XPath2DefaultElementNSExample2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XPathDocument xpathDocument = new XPathDocument("sample1.xml");

            var xpath = "/root[1]/items[1]/item[2]";

            var xmlNsMgr = new XmlNamespaceManager(xpathDocument.CreateNavigator().NameTable);

            xmlNsMgr.AddNamespace("", "http://example.com/ns1");

            var xpathNav = xpathDocument.CreateNavigator().XPath2SelectSingleNode(xpath, xmlNsMgr);

            var xpathLineInfo = (IXmlLineInfo)xpathNav;

            Console.WriteLine("{0}:{1}", xpathLineInfo.LineNumber, xpathLineInfo.LinePosition);

            var linqXmlDoc = XDocument.Load("sample1.xml", LoadOptions.PreserveWhitespace | LoadOptions.SetLineInfo);

            xmlNsMgr = new XmlNamespaceManager(new NameTable());

            xmlNsMgr.AddNamespace("", "http://example.com/ns1");

            var linqNode = linqXmlDoc.XPath2SelectElement(xpath, xmlNsMgr);

            var linqNodeLineInfo = (IXmlLineInfo)linqNode;

            Console.WriteLine("{0}:{1}", linqNodeLineInfo.LineNumber, linqNodeLineInfo.LinePosition);

            Console.ReadLine();
        }
    }
}

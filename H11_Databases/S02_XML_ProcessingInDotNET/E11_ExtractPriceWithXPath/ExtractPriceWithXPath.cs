namespace E11_ExtractPriceWithXPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;

    public class ExtractPriceWithXPath
    {
        public static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load("../../../E01_Create_XML_Catalogue/catalogue.xml");

            string xPathQuery = "/catalogue/album[year<1990]";

            XmlNodeList priceList = xmlDoc.SelectNodes(xPathQuery);

            foreach (XmlNode priceNode in priceList)
            {
                string albumName = priceNode.SelectSingleNode("name").InnerText;
                string price = priceNode.SelectSingleNode("price").InnerText;

                Console.WriteLine("Price of {0} --> {1}.00 USD", albumName, price);
            }
        }
    }
}

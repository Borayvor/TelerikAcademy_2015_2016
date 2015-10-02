namespace E16_XsdSchema
{
    using System;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class XsdSchema
    {
        public static void Main(string[] args)
        {
            var schema = new XmlSchemaSet();
            schema.Add(string.Empty, "../../catalogue.xsd");

            XDocument catalogue = XDocument.Load("../../../E01_Create_XML_Catalogue/catalogue.xml");
            XDocument invalidCatalogue = XDocument.Load("../../invalidCatalogue.xml");

            PrintValidationResult(catalogue, schema, "catalogue.xml");
            PrintValidationResult(invalidCatalogue, schema, "invalidCatalogue.xml");
        }

        private static void PrintValidationResult(XDocument doc, XmlSchemaSet schema, string file)
        {
            doc.Validate(schema, (obj, ev) =>
            {
                Console.WriteLine("* {0} \n* {1}", file, ev.Message);
            });
        }
    }
}

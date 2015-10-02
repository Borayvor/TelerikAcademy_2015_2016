namespace E13_E14_XslTransform
{
    using System;
    using System.Xml.Xsl;

    public class XslTransform
    {
        public static void Main(string[] args)
        {
            var xslt = new XslCompiledTransform();

            xslt.Load("../../catalogue.xsl");
            xslt.Transform("../../../E01_Create_XML_Catalogue/catalogue.xml"
                , "../../catalogue.html");

            Console.WriteLine("Document catalogue.html was created.");
        }
    }
}

namespace SampleConsoleApplication.Importers
{
    using System;
    using System.IO;

    public class EmpleesImporter : IImporter
    {
        public string Message
        {
            get { return "Importing Emploees"; }
        }

        public int Order
        {
            get { return 2; }
        }

        public Action<CompanyEntities, TextWriter> Get
        {
            get
            {
                return (db, tr) =>
                {

                };
            }
        }
    }
}

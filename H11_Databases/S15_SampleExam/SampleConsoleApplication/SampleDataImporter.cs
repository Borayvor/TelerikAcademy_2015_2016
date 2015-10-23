namespace SampleConsoleApplication
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Importers;

    public class SampleDataImporter
    {
        private TextWriter textWriter;

        private SampleDataImporter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public static SampleDataImporter Create(TextWriter textWriter)
        {
            return new SampleDataImporter(textWriter);
        }

        public void Import()
        {
            Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IImporter).IsAssignableFrom(t)
                && !t.IsInterface && !t.IsAbstract)
                .Select(Activator.CreateInstance)
                .OfType<IImporter>()
                .OrderBy(i => i.Order)
                .ToList()
                .ForEach(i =>
                {
                    textWriter.WriteLine(i.Message);
                    var db = new CompanyEntities();
                    i.Get(db, textWriter);
                });
        }
    }
}

namespace SchoolSystem
{
    using Core;
    using Db;
    using Helpers;
    using Providers;

    public class Startup
    {
        public static void Main()
        {
            var provider = new ConsoleProvider();
            var parser = new CommandParser();
            var db = new DictionaryDataBase();

            var engine = new Engine(provider, parser, db);
            engine.Start();
        }
    }
}

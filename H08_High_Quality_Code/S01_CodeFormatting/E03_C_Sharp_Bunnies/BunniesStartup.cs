namespace E03_C_Sharp_Bunnies
{
    using System.IO;

    public class BunniesStartup
    {
        public static void Main(string[] args)
        {
            const string BunniesFilePath = @"..\..\bunnies.txt";

            var consoleWriter = new ConsoleWriter();

            foreach (var bunny in Bunnies.List)
            {
                bunny.Introduce(consoleWriter);
            }

            var fileStream = File.Create(BunniesFilePath);

            fileStream.Close();

            using (var streamWriter = new StreamWriter(BunniesFilePath))
            {
                foreach (var bunny in Bunnies.List)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }
            }
        }
    }
}

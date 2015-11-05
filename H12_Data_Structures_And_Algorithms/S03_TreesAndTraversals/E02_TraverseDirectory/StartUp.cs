namespace E02_TraverseDirectory
{
    using System;
    using System.IO;
    using System.Linq;

    public class StartUp
    {
        private const string Extension = ".exe";

        public static void Main(string[] args)
        {
            try
            {
                TraverseDirectory(@"C:\WINDOWS");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void TraverseDirectory(string root)
        {
            var files = Directory.GetFiles(root).Where(file => file.EndsWith(Extension));
            
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

            foreach (string directory in Directory.GetDirectories(root))
            {
                TraverseDirectory(directory);
            }
        }
    }
}

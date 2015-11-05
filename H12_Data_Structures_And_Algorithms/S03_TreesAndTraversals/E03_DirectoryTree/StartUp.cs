namespace E03_DirectoryTree
{
    using System;
    using System.IO;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Traverse(@"../../"));
        }

        private static Folder Traverse(string root)
        {
            var folder = new Folder(root);

            foreach (string file in Directory.GetFiles(root))
            {
                folder.Add(new File(file, new FileInfo(file).Length));
            }

            foreach (string directory in Directory.GetDirectories(root))
            {
                folder.AddFolder(Traverse(directory));
            }

            return folder;
        }
    }
}

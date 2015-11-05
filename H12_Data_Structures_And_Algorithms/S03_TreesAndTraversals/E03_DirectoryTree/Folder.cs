namespace E03_DirectoryTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.NestedFolders = new List<Folder>();
        }

        public string Name { get; private set; }

        public IList<File> Files { get; private set; }

        public IList<Folder> NestedFolders { get; private set; }

        public void Add(File file)
        {
            this.Files.Add(file);
        }

        public void AddFolder(Folder folder)
        {
            this.NestedFolders.Add(folder);
        }

        public long GetSize()
        {
            return this.Files.Sum(file => file.Size) + this.NestedFolders.Sum(folder => folder.GetSize());
        }

        public override string ToString()
        {
            var result = new List<string>();

            result.AddRange(this.Files.Select(file => file.ToString()));
            result.AddRange(this.NestedFolders.Select(folder => folder.ToString()));

            return string.Join(Environment.NewLine, result);
        }
    }
}


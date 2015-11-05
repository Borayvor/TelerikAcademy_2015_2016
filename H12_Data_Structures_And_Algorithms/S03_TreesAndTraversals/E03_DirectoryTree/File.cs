namespace E03_DirectoryTree
{
    internal class File
    {
        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; private set; }

        public long Size { get; private set; }

        public override string ToString()
        {
            return string.Format("Name: {0}, Size: {1}", this.Name, this.Size);
        }
    }
}

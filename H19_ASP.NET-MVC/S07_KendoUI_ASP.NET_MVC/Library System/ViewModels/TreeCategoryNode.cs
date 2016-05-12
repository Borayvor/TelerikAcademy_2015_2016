namespace Library_System.ViewModels
{
    using System.Collections.Generic;

    public class TreeCategoryNode
    {
        public string Name { get; set; }

        public IEnumerable<BookNode> Items { get; set; }

        public bool HasChildren { get; set; }
    }
}
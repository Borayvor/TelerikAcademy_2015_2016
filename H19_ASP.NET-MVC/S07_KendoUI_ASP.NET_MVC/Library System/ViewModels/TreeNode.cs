namespace Library_System.ViewModels
{
    using System.Collections.Generic;

    public class TreeNode
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public IEnumerable<TreeNode> Items { get; set; }

        public bool HasChildren { get; set; }
    }
}
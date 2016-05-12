namespace Library_System.ViewModels
{
    using System.Collections.Generic;
    using Kendo.Mvc.UI;

    public class IndexViewModel
    {
        public IEnumerable<TreeViewItemModel> TreeViewItems { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
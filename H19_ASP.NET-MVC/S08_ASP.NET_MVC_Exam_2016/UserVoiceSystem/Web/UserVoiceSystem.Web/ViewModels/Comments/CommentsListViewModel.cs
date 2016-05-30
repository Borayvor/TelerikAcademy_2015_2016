namespace UserVoiceSystem.Web.ViewModels.Comments
{
    using System.Collections.Generic;

    public class CommentsListViewModel
    {
        public IEnumerable<CommentGetViewModel> Comments { get; set; }

        public int? TotalPages { get; set; }

        public int? CurrentPage { get; set; }

        public string Url { get; set; }
    }
}

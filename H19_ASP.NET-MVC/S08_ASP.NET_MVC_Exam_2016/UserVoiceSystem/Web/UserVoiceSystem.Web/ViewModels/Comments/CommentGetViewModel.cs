namespace UserVoiceSystem.Web.ViewModels.Comments
{
    using System;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentGetViewModel : IMapFrom<Comment>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        public int IdeaId { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

namespace UserVoiceSystem.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentPostViewModel : IMapFrom<Comment>, IMapTo<Comment>
    {
        public CommentPostViewModel()
        {
        }

        public CommentPostViewModel(int ideaId, string url)
        {
            this.IdeaId = ideaId;
            this.Url = url;
        }

        public int IdeaId { get; set; }

        public string Url { get; set; }

        [Required]
        [MaxLength(10000)]
        [MinLength(5)]
        public string Content { get; set; }
    }
}

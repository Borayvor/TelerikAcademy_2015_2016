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

        [Required]
        [MaxLength(500)]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9A-Za-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9A-Za-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9A-Za-z][-\w]*[0-9A-Za-z]*\.)+[A-Za-z0-9][\-a-zA-Z0-9]{0,22}[A-Za-z0-9]))$", ErrorMessage = "Invalid Email address !")]
        public string AuthorEmail { get; set; }
    }
}

namespace UserVoiceSystem.Web.ViewModels.Votes
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class VotePostViewModel : IMapFrom<Vote>, IMapTo<Vote>
    {
        public int IdeaId { get; set; }

        [Range(1, 3, ErrorMessage = "Invalid value !")]
        public int Points { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(7)]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "Invalid IP address !")]
        public string AuthorIp { get; set; }
    }
}

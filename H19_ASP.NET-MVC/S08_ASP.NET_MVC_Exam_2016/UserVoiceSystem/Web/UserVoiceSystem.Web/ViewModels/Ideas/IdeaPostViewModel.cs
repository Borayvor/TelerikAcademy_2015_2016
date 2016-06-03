namespace UserVoiceSystem.Web.ViewModels.Ideas
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class IdeaPostViewModel : IMapFrom<Idea>, IMapTo<Idea>
    {
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        [DisplayName("I suggest you ...")]
        public string Title { get; set; }

        [Required]
        [MaxLength(10000)]
        [MinLength(2)]
        public string Description { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(7)]
        [RegularExpression(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$", ErrorMessage = "Invalid IP address !")]
        public string AuthorIp { get; set; }
    }
}

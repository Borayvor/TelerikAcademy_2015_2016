namespace UserVoiceSystem.Services.Data.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentPostViewModel : IMapFrom<Comment>, IMapTo<Comment>, IHaveCustomMappings
    {
        public CommentPostViewModel()
        {
        }

        public CommentPostViewModel(int ideaId)
        {
            this.IdeaId = ideaId;
        }

        public int IdeaId { get; set; }

        [Required]
        [MaxLength(10000)]
        [MinLength(5)]
        public string Content { get; set; }

        [Required]
        [MaxLength(500)]
        [RegularExpression(@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@" + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]? [0-9]{1,2}|25[0-5]|2[0-4][0-9])\." + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]? [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|" + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$", ErrorMessage = "Invalid AuthorEmail !")]
        public string AuthorEmail { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentPostViewModel>()
                .ForMember(
                m => m.AuthorEmail,
                options => options.MapFrom(x => x.Author.Email))
                .ReverseMap();
        }
    }
}

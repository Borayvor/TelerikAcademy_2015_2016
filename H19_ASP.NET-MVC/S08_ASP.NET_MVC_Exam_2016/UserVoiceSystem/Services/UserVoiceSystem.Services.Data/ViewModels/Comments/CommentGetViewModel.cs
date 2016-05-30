namespace UserVoiceSystem.Services.Data.ViewModels.Comments
{
    using System;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using UserVoiceSystem.Data.Models;

    public class CommentGetViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        public int IdeaId { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentGetViewModel>()
                .ForMember(
                m => m.AuthorEmail,
                options => options.MapFrom(x => x.Author.Email));
        }
    }
}

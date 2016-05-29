namespace UserVoiceSystem.Web.Areas.Administration.ViewModels.Comments
{
    using System;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentOutputViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Idea { get; set; }

        public string Content { get; set; }

        public string AuthorEmail { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentOutputViewModel>()
                .ForMember(
                m => m.AuthorEmail,
                options => options.MapFrom(x => x.Author.Email))
                .ForMember(
                m => m.Idea,
                opt => opt.MapFrom(x => x.Idea.Title))
                .ReverseMap();
        }
    }
}

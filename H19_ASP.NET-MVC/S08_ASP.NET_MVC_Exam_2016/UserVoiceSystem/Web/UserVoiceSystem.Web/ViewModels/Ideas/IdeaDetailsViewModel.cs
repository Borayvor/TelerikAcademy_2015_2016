namespace UserVoiceSystem.Web.ViewModels.Ideas
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;
    using Services.Web.Common;

    public class IdeaDetailsViewModel : IMapFrom<Idea>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CommentsCount { get; set; }

        public int VotesCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/suggestions/{identifier.EncodeIdTitle(this.Id, this.Title)}";
            }
        }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Idea, IdeaGetViewModel>()
                .ForMember(
                m => m.VotesCount,
                options => options.MapFrom(x => x.Votes.Any() ? x.Votes.Sum(v => v.Points) : 0));

            configuration.CreateMap<Idea, IdeaGetViewModel>()
                .ForMember(
                x => x.CommentsCount,
                options => options.MapFrom(x => x.Comments.Any() ? x.Comments.Count : 0));
        }
    }
}

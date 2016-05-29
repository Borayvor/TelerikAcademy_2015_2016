namespace UserVoiceSystem.Web.Areas.Administration.ViewModels.Ideas
{
    using System;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;

    public class IdeaOutputViewModel : IMapFrom<Idea>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

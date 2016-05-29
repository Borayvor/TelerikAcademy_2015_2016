namespace UserVoiceSystem.Web.Areas.Administration.ViewModels.Ideas
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;

    public class IdeaInputViewModel : IMapFrom<Idea>, IMapTo<Idea>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Title { get; set; }

        [Required]
        [MaxLength(10000)]
        [MinLength(2)]
        public string Description { get; set; }
    }
}

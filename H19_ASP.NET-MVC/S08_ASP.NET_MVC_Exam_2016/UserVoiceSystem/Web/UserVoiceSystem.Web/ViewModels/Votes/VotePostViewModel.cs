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
    }
}

namespace UserVoiceSystem.Services.Data.ViewModels.Ideas
{
    using System.Collections.Generic;

    public class IdeasListViewModel
    {
        public IEnumerable<IdeaGetViewModel> Ideas { get; set; }

        public int? TotalPages { get; set; }

        public int? CurrentPage { get; set; }

        public int? Order { get; set; }

        public string Search { get; set; }
    }
}

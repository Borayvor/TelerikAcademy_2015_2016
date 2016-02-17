namespace TwitSystem.Web.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class TweetsResponseViewModels : IMapFrom<Tweet>
    {
        public string Content { get; set; }
    }
}
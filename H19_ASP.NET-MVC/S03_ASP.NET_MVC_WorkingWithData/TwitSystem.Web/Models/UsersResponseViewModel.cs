namespace TwitSystem.Web.Models
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UsersResponseViewModel : IMapFrom<User>
    {
        public string UserName { get; set; }

        public IEnumerable<TweetsResponseViewModels> Tweets { get; set; }
    }
}
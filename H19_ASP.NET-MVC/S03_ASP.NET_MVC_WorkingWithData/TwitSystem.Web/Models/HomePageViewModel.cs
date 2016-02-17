namespace TwitSystem.Web.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class HomePageViewModel
    {
        [UIHint("All Users")]
        public IEnumerable<UsersResponseViewModel> AllUsers { get; set; }

        [UIHint("All Tags")]
        public IEnumerable<TagsResponseViewModel> AllTags { get; set; }
    }
}
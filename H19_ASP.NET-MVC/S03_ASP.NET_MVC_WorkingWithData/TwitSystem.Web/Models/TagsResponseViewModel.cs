namespace TwitSystem.Web.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class TagsResponseViewModel : IMapFrom<Tag>
    {
        public string Name { get; set; }
    }
}
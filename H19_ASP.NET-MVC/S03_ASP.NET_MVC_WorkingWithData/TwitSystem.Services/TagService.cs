namespace TwitSystem.Services
{
    using System.Linq;
    using Data.Models;
    using Data.Repositories;

    public class TagService : ITagService
    {
        private readonly IRepository<Tag> tags;

        public TagService(IRepository<Tag> tags)
        {
            this.tags = tags;
        }

        public IQueryable<Tag> GetAll()
        {
            return this.tags.All().OrderBy(x => x.Name);
        }
    }
}

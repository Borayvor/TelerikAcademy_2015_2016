namespace TwitSystem.Services
{
    using System.Linq;
    using Data.Models;

    public interface ITagService
    {
        IQueryable<Tag> GetAll();
    }
}

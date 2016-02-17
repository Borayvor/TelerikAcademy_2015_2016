namespace TwitSystem.Services
{
    using System.Linq;
    using Data.Models;

    public interface IUserService
    {
        IQueryable<User> GetAll();

        User GetById(string userId);

        IQueryable<Tweet> GetUserTweets(string authorId);
    }
}

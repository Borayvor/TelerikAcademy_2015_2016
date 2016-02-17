namespace TwitSystem.Services
{
    using System.Linq;
    using Data.Models;
    using Data.Repositories;

    public class UserService : IUserService
    {
        private readonly IRepository<User> users;

        private readonly IRepository<Tweet> tweets;

        public UserService(IRepository<User> users, IRepository<Tweet> tweets)
        {
            this.users = users;
            this.tweets = tweets;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User GetById(string userId)
        {
            return this.users.GetById(userId);
        }

        public IQueryable<Tweet> GetUserTweets(string authorId)
        {
            return this.tweets.All().Where(x => x.AuthorId == authorId);
        }
    }
}

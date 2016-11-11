namespace Dealership.Engine.Factories
{
    using System;
    using Common.Enums;
    using Contracts;
    using Contracts.Factories;
    using Models;

    public class DealershipFactory : IDealershipFactory
    {
        public IUser CreateUser(string username, string firstName, string lastName, string password, string role)
        {
            return new User(username, firstName, lastName, password, (Role)Enum.Parse(typeof(Role), role));
        }

        public IComment CreateComment(string content)
        {
            return new Comment(content);
        }
    }
}

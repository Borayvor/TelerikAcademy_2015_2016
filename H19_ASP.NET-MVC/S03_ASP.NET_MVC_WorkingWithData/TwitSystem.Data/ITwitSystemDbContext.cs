﻿namespace TwitSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Models;

    public interface ITwitSystemDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Tag> Tags { get; set; }

        IDbSet<Tweet> Tweets { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}

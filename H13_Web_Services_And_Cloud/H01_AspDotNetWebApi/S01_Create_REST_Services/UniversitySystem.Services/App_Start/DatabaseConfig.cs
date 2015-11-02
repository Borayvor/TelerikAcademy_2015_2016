﻿namespace UniversitySystem.Services
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public static class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<UniversityDbContext, Configuration>());

            UniversityDbContext.Create().Database.Initialize(true);
        }
    }
}
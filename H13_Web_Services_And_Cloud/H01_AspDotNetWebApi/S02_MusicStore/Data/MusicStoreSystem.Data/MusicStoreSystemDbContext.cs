namespace MusicStoreSystem.Data
{
    using System.Data.Entity;
    using Interfaces;
    using Models;

    public class MusicStoreSystemDbContext : DbContext, IMusicStoreSystemDbContext
    {
        public MusicStoreSystemDbContext()
            : base("MusicStoreSystemDatabase")
        {
        }

        public virtual IDbSet<Album> Albums { get; set; }

        public virtual IDbSet<Artist> Artists { get; set; }

        public virtual IDbSet<Song> Songs { get; set; }

        public static MusicStoreSystemDbContext Create()
        {
            return new MusicStoreSystemDbContext();
        }
    }
}

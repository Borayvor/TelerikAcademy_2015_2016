namespace MusicStoreSystem.Services.Data.Songs
{
    using System;
    using System.Linq;
    using Models;
    using MusicStore.Common.Constants;
    using MusicStoreSystem.Data;
    using MusicStoreSystem.Data.Repositories;

    public class SongsServices : ISongsServices
    {
        private readonly IRepository<Song> data;

        public SongsServices()
        {
            this.data = new EfGenericRepository<Song>(new MusicStoreSystemDbContext());
        }

        public IQueryable<Song> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            return this.data
                    .All()
                    .OrderByDescending(x => x.Title)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
        }

        public IQueryable<Song> GetById(int id)
        {
            return this.GetById(id);
        }

        public int Add(string title, DateTime? year, string genre)
        {
            var newSong = new Song
            {
                Title = title,
                Year = year,
                Genre = genre
            };

            this.data.Add(newSong);
            this.data.SaveChanges();

            return newSong.Id;
        }

        public int Update(Song song, string title, DateTime? year, string genre)
        {
            song.Title = title;
            song.Year = year;
            song.Genre = genre;

            this.data.Update(song);
            this.data.SaveChanges();

            return song.Id;
        }

        public void Delete(Song song)
        {
            this.data.Delete(song);
            this.data.SaveChanges();
        }
    }
}

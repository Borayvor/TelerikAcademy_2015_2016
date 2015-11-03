namespace MusicStoreSystem.Services.Data.Songs
{
    using System;
    using System.Linq;
    using Models;
    using MusicStore.Common.Constants;
    using MusicStoreSystem.Data.Interfaces;

    public class SongsServices : ISongsServices
    {
        private readonly IRepository<Song> songs;

        public SongsServices(IRepository<Song> songsRepo)
        {
            this.songs = songsRepo;
        }

        public IQueryable<Song> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize)
        {
            return this.songs
                    .All()
                    .OrderByDescending(x => x.Title)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize);
        }

        public Song GetById(int id)
        {
            var song = this.songs.GetById(id);

            return song;
        }

        public int Add(string title, DateTime? year, string genre, int albumId)
        {
            var newSong = new Song
            {
                Title = title,
                Year = year,
                Genre = genre,
                AlbumId = albumId
            };

            this.songs.Add(newSong);
            this.songs.SaveChanges();

            return newSong.Id;
        }

        public int Update(Song song, string title, DateTime? year, string genre, int albumId)
        {
            song.Title = title;
            song.Year = year;
            song.Genre = genre;
            song.AlbumId = albumId;

            this.songs.Update(song);
            this.songs.SaveChanges();

            return song.Id;
        }

        public void Delete(Song song)
        {
            this.songs.Delete(song);
            this.songs.SaveChanges();
        }
    }
}

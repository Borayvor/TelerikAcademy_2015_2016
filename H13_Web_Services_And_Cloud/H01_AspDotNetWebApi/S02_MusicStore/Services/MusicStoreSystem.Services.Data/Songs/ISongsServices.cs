namespace MusicStoreSystem.Services.Data.Songs
{
    using System;
    using System.Linq;
    using Models;
    using MusicStore.Common.Constants;

    public interface ISongsServices
    {
        IQueryable<Song> All(int page = 1, int pageSize = GlobalConstants.DefaultPageSize);

        Song GetById(int id);

        int Add(string title, DateTime? year, string genre, int albumId);

        int Update(Song song, string title, DateTime? year, string genre, int albumId);

        void Delete(Song song);
    }
}

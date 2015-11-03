namespace MusicStoreSystem.Api.Models.Songs
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using MusicStore.Common.Constants;
    using MusicStoreSystem.Models;

    public class SongDetailsResponseModel
    {
        public static Expression<Func<Song, SongDetailsResponseModel>> FromModel
        {
            get
            {
                return x => new SongDetailsResponseModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Year = x.Year,
                    Genre = x.Genre
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinTitleLength)]
        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Title { get; set; }

        public virtual DateTime? Year { get; set; }

        [MinLength(ValidationConstants.MinGenreLength)]
        [MaxLength(ValidationConstants.MaxGenreLength)]
        public string Genre { get; set; }
    }
}
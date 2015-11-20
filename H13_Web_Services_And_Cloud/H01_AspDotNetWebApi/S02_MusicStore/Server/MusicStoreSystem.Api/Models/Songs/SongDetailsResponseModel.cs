namespace MusicStoreSystem.Api.Models.Songs
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Infrastructure.Mapping;
    using MusicStore.Common.Constants;
    using MusicStoreSystem.Models;

    public class SongDetailsResponseModel : IMapFrom<Song>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinTitleLength)]
        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Title { get; set; }

        public virtual DateTime? Year { get; set; }

        [MinLength(ValidationConstants.MinGenreLength)]
        [MaxLength(ValidationConstants.MaxGenreLength)]
        public string Genre { get; set; }

        [Required]
        public int AlbumId { get; set; }
    }
}
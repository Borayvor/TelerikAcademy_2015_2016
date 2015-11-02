namespace MusicStoreSystem.Api.Models.Songs
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MusicStore.Common.Constants;

    public class SaveSongRequestModel
    {
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
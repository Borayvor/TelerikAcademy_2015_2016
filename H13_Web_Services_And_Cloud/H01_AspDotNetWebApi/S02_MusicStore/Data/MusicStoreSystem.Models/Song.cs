namespace MusicStoreSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MusicStore.Common.Constants;

    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinTitleLength)]
        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Title { get; set; }

        public virtual DateTime? Year { get; set; }

        [MinLength(ValidationConstants.MinGenreLength)]
        [MaxLength(ValidationConstants.MaxGenreLength)]
        public string Genre { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}

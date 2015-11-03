namespace MusicStoreSystem.Api.Models.Albums
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MusicStore.Common.Constants;

    public class AlbumDetailsResponseModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinTitleLength)]
        [MaxLength(ValidationConstants.MaxTitleLength)]
        public string Title { get; set; }

        public virtual DateTime? Year { get; set; }

        [MinLength(ValidationConstants.MinProducerNameLength)]
        [MaxLength(ValidationConstants.MaxProducerNameLength)]
        public string Producer { get; set; }
    }
}
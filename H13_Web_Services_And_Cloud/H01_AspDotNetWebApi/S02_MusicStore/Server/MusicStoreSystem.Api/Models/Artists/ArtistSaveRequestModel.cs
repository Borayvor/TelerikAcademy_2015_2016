namespace MusicStoreSystem.Api.Models.Artists
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using MusicStore.Common.Constants;

    public class ArtistSaveRequestModel
    {
        [Required]
        [MinLength(ValidationConstants.MinNameLength)]
        [MaxLength(ValidationConstants.MaxNameLength)]
        public string Name { get; set; }

        [MinLength(ValidationConstants.MinCountryNameLength)]
        [MaxLength(ValidationConstants.MaxCountryNameLength)]
        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}
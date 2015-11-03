﻿namespace MusicStoreSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using MusicStore.Common.Constants;

    public class Artist
    {
        private ICollection<Album> albums;
        private ICollection<Song> songs;

        public Artist()
        {
            this.albums = new HashSet<Album>();
            this.songs = new HashSet<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.MinNameLength)]
        [MaxLength(ValidationConstants.MaxNameLength)]
        public string Name { get; set; }

        [MinLength(ValidationConstants.MinCountryNameLength)]
        [MaxLength(ValidationConstants.MaxCountryNameLength)]
        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Album> Albums
        {
            get { return this.albums; }
            set { this.albums = value; }
        }
    }
}

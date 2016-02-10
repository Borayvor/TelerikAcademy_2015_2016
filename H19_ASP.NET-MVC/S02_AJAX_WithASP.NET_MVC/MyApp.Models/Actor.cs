namespace MyApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Actor
    {
        private ICollection<Movie> movies;

        public Actor()
        {
            this.movies = new HashSet<Movie>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength( 30, ErrorMessage = "First name must be between 2 and 30 characters long", MinimumLength = 2 )]
        public string FirstName { get; set; }

        [Required]
        [StringLength( 30, ErrorMessage = "Last name be between 2 and 30 characters long", MinimumLength = 2 )]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public virtual ICollection<Movie> Movies
        {
            get { return this.movies; }
            set { this.movies = value; }
        }
    }
}
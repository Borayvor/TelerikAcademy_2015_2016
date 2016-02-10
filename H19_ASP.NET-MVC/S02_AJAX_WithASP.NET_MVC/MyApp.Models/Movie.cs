namespace MyApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength( 100, ErrorMessage = "Title must be between 2 and 100 characters long", MinimumLength = 2 )]
        public string Title { get; set; }

        [Range( 1900, 2030, ErrorMessage = "The year must be between 1900 and 2030" )]
        public int? Year { get; set; }

        public int? DirectorId { get; set; }

        public virtual Director Director { get; set; }

        public int? LeadingMaleRoleId { get; set; }

        public virtual Actor LeadingMaleRole { get; set; }

        public int? LeadingFemaleRoleId { get; set; }

        public virtual Actor LeadingFemaleRole { get; set; }

        public int? StudioId { get; set; }

        public virtual Studio Studio { get; set; }
    }
}

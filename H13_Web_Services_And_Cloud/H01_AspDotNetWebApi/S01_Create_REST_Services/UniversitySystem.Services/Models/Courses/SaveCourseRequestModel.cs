namespace UniversitySystem.Services.Models.Courses
{
    using System.ComponentModel.DataAnnotations;

    public class SaveCourseRequestModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
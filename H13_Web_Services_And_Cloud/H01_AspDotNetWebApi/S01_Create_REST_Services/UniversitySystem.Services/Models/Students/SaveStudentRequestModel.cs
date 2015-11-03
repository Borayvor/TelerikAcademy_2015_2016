namespace UniversitySystem.Services.Models.Students
{
    using System.ComponentModel.DataAnnotations;

    public class SaveStudentRequestModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }

        public uint? Number { get; set; }
    }
}
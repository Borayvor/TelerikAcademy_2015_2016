namespace UniversitySystem.Services.Models.Courses
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using UniversitySystem.Models;

    public class CourseDetailsResponseModel
    {
        public static Expression<Func<Course, CourseDetailsResponseModel>> FromModel
        {
            get
            {
                return c => new CourseDetailsResponseModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}
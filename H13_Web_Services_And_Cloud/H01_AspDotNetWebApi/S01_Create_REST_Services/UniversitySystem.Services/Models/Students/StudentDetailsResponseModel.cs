namespace UniversitySystem.Services.Models.Students
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using UniversitySystem.Models;

    public class StudentDetailsResponseModel
    {
        public static Expression<Func<Student, StudentDetailsResponseModel>> FromModel
        {
            get
            {
                return st => new StudentDetailsResponseModel
                {
                    Id = st.Id,
                    Name = st.Name
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }
    }
}
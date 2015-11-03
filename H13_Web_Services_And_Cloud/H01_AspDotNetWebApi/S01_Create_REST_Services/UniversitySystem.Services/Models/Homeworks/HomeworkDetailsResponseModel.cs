namespace UniversitySystem.Services.Models.Homeworks
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using UniversitySystem.Models;

    public class HomeworkDetailsResponseModel
    {
        public static Expression<Func<Homework, HomeworkDetailsResponseModel>> FromModel
        {
            get
            {
                return h => new HomeworkDetailsResponseModel
                {
                    Id = h.Id,
                    Content = h.Content,
                    TimeSent = h.TimeSent
                };
            }
        }

        public int Id { get; set; }

        [MaxLength(1000)]
        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }
    }
}
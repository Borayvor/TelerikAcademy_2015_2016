namespace UniversitySystem.Services.Models.Homeworks
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class SaveHomeworkRequestModel
    {
        [MaxLength(1000)]
        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }
    }
}
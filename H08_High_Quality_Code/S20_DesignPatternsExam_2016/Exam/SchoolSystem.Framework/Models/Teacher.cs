namespace SchoolSystem.Framework.Models
{
    using System;
    using Abstractions;
    using Contracts;
    using Core.Contracts.Factories;
    using Enums;

    public class Teacher : Person, ITeacher
    {
        public const int MaxStudentMarksCount = 20;

        private IMarkFactory markFactory;

        public Teacher(string firstName, string lastName, Subject subject, IMarkFactory markFactory)
            : base(firstName, lastName)
        {
            this.Subject = subject;
            this.markFactory = markFactory;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float mark)
        {
            if (student.Marks.Count >= MaxStudentMarksCount)
            {
                throw new ArgumentException($"The student's marks count exceed the maximum count of {MaxStudentMarksCount} marks");
            }

            var newMark = this.markFactory.CreateMark(this.Subject, mark);
            student.Marks.Add(newMark);
        }
    }
}

namespace SchoolSystem.Framework.Core.Commands
{
    using System.Collections.Generic;
    using Contracts.Commands;
    using Contracts.Repositories;
    using Models.Contracts;

    public class StudentListMarksCommand : ICommand
    {
        private readonly IDbRepository<IStudent> students;

        public StudentListMarksCommand(IDbRepository<IStudent> students)
        {
            this.students = students;
        }

        public string Execute(IList<string> parameters)
        {
            var studentId = int.Parse(parameters[0]);
            var student = this.students.GetById(studentId);

            return student.ListMarks();
        }
    }
}

namespace SchoolSystem.Framework.Core.Commands
{
    using System.Collections.Generic;
    using Common.Constants;
    using Contracts.Commands;
    using Contracts.Repositories;
    using Models.Contracts;

    public class TeacherAddMarkCommand : ICommand
    {
        private readonly IDbRepository<ITeacher> teachers;
        private readonly IDbRepository<IStudent> students;

        public TeacherAddMarkCommand(
            IDbRepository<ITeacher> teachers,
            IDbRepository<IStudent> students)
        {
            this.teachers = teachers;
            this.students = students;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var teacher = this.teachers.GetById(teacherId);
            var student = this.students.GetById(studentId);

            teacher.AddMark(student, mark);

            var result = string.Format(
                GlobalConstants.TeacherAddMarkSuccessMessageTemplate,
                teacher.FirstName,
                teacher.LastName,
                mark,
                student.FirstName,
                student.LastName,
                teacher.Subject);

            return result;
        }
    }
}

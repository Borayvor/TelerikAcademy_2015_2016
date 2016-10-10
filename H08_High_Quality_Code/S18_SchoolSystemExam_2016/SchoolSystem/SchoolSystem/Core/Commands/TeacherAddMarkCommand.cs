namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using Models;

    public class TeacherAddMarkCommand : Command, ICommand
    {
        public TeacherAddMarkCommand(IDataBase db)
            : base(db)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var markValue = float.Parse(parameters[2]);

            var student = this.db.GetStudentById(studentId);
            var teacher = this.db.GetTeacherById(teacherId);

            var newMark = new Mark(teacher.Subject, markValue);

            teacher.AddMarkToStudent(student, newMark);

            var result = $"Teacher {teacher.FirstName} {teacher.LastName} added mark {markValue} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";

            return result;
        }
    }
}

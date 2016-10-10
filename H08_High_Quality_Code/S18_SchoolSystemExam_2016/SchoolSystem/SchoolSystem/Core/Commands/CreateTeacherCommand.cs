namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using EnumTypes;
    using Models;

    public class CreateTeacherCommand : Command, ICommand
    {
        public CreateTeacherCommand(IDataBase db)
            : base(db)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (SubjectType)int.Parse(parameters[2]);
            var teacher = new Teacher(firstName, lastName, subject);

            this.db.AddTeacher(teacher);

            var result = $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {teacher.Id} was created.";

            return result;
        }
    }
}

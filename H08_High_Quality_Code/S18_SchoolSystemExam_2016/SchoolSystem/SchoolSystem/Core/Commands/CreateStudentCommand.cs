namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;
    using EnumTypes;
    using Models;

    public class CreateStudentCommand : Command, ICommand
    {
        public CreateStudentCommand(IDataBase db)
            : base(db)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (GradeType)int.Parse(parameters[2]);
            var student = new Student(firstName, lastName, grade);

            this.db.AddStudent(student);

            var result = $"A new student with name {firstName} {lastName}, grade {grade} and ID {student.Id} was created.";

            return result;
        }
    }
}

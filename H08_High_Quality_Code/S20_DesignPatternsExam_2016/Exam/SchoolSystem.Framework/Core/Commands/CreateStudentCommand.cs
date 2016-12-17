namespace SchoolSystem.Framework.Core.Commands
{
    using System.Collections.Generic;
    using Common.Constants;
    using Contracts.Commands;
    using Contracts.Factories;
    using Contracts.Repositories;
    using Models.Contracts;
    using Models.Enums;

    public class CreateStudentCommand : ICommand
    {
        protected IStudentFactory studentFactory;
        private readonly IDbRepository<IStudent> students;

        public CreateStudentCommand(
            IStudentFactory studentFactory,
            IDbRepository<IStudent> students)
        {
            this.studentFactory = studentFactory;
            this.students = students;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            var student = this.studentFactory.CreateStudent(firstName, lastName, grade);
            var studentId = this.students.Add(student);

            var result = string.Format(
                GlobalConstants.CreateStudentSuccessMessageTemplate,
                firstName,
                lastName,
                grade,
                studentId);

            return result;
        }
    }
}

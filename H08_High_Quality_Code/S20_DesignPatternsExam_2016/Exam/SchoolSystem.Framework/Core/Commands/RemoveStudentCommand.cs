namespace SchoolSystem.Framework.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Common.Constants;
    using Contracts.Commands;
    using Contracts.Repositories;
    using Models.Contracts;

    public class RemoveStudentCommand : ICommand
    {
        private readonly IDbRepository<IStudent> students;

        public RemoveStudentCommand(IDbRepository<IStudent> students)
        {
            this.students = students;
        }

        public string Execute(IList<string> parameters)
        {
            var id = int.Parse(parameters[0]);

            if (this.students.GetById(id) == null)
            {
                throw new ArgumentException(GlobalConstants.NotFoundMessage);
            }

            this.students.Remove(id);

            var result = string.Format(
                GlobalConstants.RemoveStudentSuccessMessageTemplate, id);

            return result;
        }
    }
}

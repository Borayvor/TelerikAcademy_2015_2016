namespace SchoolSystem.Framework.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using Common.Constants;
    using Contracts.Commands;
    using Contracts.Repositories;
    using Models.Contracts;

    public class RemoveTeacherCommand : ICommand
    {
        private readonly IDbRepository<ITeacher> teachers;

        public RemoveTeacherCommand(IDbRepository<ITeacher> teachers)
        {
            this.teachers = teachers;
        }

        public string Execute(IList<string> parameters)
        {
            var id = int.Parse(parameters[0]);

            if (this.teachers.GetById(id) == null)
            {
                throw new ArgumentException(GlobalConstants.NotFoundMessage);
            }

            this.teachers.Remove(id);

            var result = string.Format(
                GlobalConstants.RemoveTeacherSuccessMessageTemplate, id);

            return result;
        }
    }
}

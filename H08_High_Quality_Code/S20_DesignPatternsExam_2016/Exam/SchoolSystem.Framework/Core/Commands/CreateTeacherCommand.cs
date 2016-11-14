namespace SchoolSystem.Framework.Core.Commands
{
    using System.Collections.Generic;
    using Common.Constants;
    using Contracts.Commands;
    using Contracts.Factories;
    using Contracts.Repositories;
    using Models.Contracts;
    using Models.Enums;

    public class CreateTeacherCommand : ICommand
    {
        protected ITeacherFactory teacherFactory;
        private readonly IDbRepository<ITeacher> teachers;

        public CreateTeacherCommand(
            ITeacherFactory teacherFactory,
            IDbRepository<ITeacher> teachers)
        {
            this.teacherFactory = teacherFactory;
            this.teachers = teachers;
        }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var subject = (Subject)int.Parse(parameters[2]);

            var teacher = this.teacherFactory.CreateTeacher(firstName, lastName, subject);
            var teacherId = this.teachers.Add(teacher);

            var result = string.Format(
                GlobalConstants.CreateTeacherSuccessMessageTemplate,
                firstName,
                lastName,
                subject,
                teacherId);

            return result;
        }
    }
}

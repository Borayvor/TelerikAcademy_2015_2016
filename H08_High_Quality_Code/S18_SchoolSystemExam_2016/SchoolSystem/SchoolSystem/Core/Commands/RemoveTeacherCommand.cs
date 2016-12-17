namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;

    public class RemoveTeacherCommand : Command, ICommand
    {
        public RemoveTeacherCommand(IDataBase db)
            : base(db)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var result = string.Empty;
            var id = int.Parse(parameters[0]);
            var isRemoved = this.db.RemoveTeacherById(id);

            if (isRemoved)
            {
                result = $"Teacher with ID {id} was sucessfully removed.";
            }
            else
            {
                result = $"There is no teacher with ID {id}.";
            }

            return result;
        }
    }
}

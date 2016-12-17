namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;

    public class RemoveStudentCommand : Command, ICommand
    {
        public RemoveStudentCommand(IDataBase db)
            : base(db)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var result = string.Empty;
            var id = int.Parse(parameters[0]);
            var isRemoved = this.db.RemoveStudentById(id);

            if (isRemoved)
            {
                result = $"Student with ID {id} was sucessfully removed.";
            }
            else
            {
                result = $"There is no student with ID {id}.";
            }

            return result;
        }
    }
}

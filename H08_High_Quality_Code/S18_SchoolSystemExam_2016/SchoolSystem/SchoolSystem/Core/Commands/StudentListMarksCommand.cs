namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;

    public class StudentListMarksCommand : Command, ICommand
    {
        public StudentListMarksCommand(IDataBase db)
            : base(db)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var id = int.Parse(parameters[0]);
            var result = this.db.GetStudentById(id).GetMarksAsStringList();

            return result;
        }
    }
}

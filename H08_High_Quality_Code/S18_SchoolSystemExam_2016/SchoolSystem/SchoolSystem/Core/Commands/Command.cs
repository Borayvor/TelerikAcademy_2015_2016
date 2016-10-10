namespace SchoolSystem.Core.Commands
{
    using System.Collections.Generic;
    using Contracts;

    public abstract class Command : ICommand
    {
        protected IDataBase db;

        public Command(IDataBase db)
        {
            this.db = db;
        }

        public abstract string Execute(IList<string> parameters);
    }
}

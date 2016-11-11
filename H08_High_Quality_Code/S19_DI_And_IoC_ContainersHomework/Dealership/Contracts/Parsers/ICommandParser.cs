namespace Dealership.Contracts.Parsers
{
    using System.Collections.Generic;

    public interface ICommandParser
    {
        ICollection<string> Parse(string value);
    }
}

namespace Dealership.Engine.Parsers
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using Contracts.Parsers;

    public class CommandParser : ICommandParser
    {
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";
        private const string RegExString = "{{.+(?=}})}}";

        private List<string> parameters;
        private Regex regex;

        public CommandParser()
        {
            this.regex = new Regex(RegExString);
        }

        public ICollection<string> Parse(string value)
        {
            var indexOfFirstSeparator = value.IndexOf(SplitCommandSymbol);
            var indexOfOpenComment = value.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = value.IndexOf(CommentCloseSymbol);

            this.parameters = new List<string>();

            if (indexOfFirstSeparator < 0)
            {
                this.parameters.Add(value);

                return this.parameters;
            }

            this.parameters.Add(value.Substring(0, indexOfFirstSeparator));

            if (indexOfOpenComment >= 0)
            {
                this.parameters.Add(value.Substring(indexOfOpenComment + CommentOpenSymbol.Length, indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment));
                value = regex.Replace(value, string.Empty);
            }

            this.parameters.AddRange(value.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));

            return this.parameters;
        }
    }
}

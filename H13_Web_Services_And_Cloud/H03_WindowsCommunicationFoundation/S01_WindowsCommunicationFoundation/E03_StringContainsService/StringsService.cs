namespace E03_StringContainsService
{
    using System.Text.RegularExpressions;

    public class StringsService : IStringsService
    {
        public int GetNumberOfTimesSecondStringContainsFirstString(string first, string second)
        {
            int occurences = 0;

            if (string.IsNullOrEmpty(first)
                || string.IsNullOrEmpty(second)
                || first.Length > second.Length)
            {
                return occurences;
            }

            MatchCollection match = Regex.Matches(second, first, RegexOptions.IgnoreCase);
            occurences = match.Count;

            return occurences;
        }
    }
}

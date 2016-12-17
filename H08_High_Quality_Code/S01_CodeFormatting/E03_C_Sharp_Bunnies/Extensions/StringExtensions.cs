namespace E03_C_Sharp_Bunnies.Extensions
{
    using System.Text;

    public static class StringExtensions
    {
        public static string SplitToSeparateWordsByUppercaseLetter(this string sequence)
        {
            const int ProbableStringMargin = 10;
            const char SingleWhitespace = ' ';

            var probableStringSize = sequence.Length + ProbableStringMargin;

            var builder = new StringBuilder(probableStringSize);

            foreach (var letter in sequence)
            {
                if (char.IsUpper(letter))
                {
                    builder.Append(SingleWhitespace);
                }

                builder.Append(letter);
            }

            return builder.ToString().Trim();
        }
    }
}

namespace E01_StringBuilder_Substring
{
    using System;
    using System.Text;

    /// <summary>
    /// Extend StringBuilder
    /// </summary>
    public static class StringBuilderExtension
    {
        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at a specified
        /// character position and has a specified length.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="index">
        /// The zero-based starting character position of a substring 
        /// in this instance.</param>
        /// <param name="length">The number of characters in the substring.</param>
        /// <returns>
        /// A string that is equivalent to the substring of length length that begins
        /// at startIndex in this instance, or System.String.Empty if startIndex is equal
        /// to the length of this instance and length is zero.</returns>
        public static StringBuilder Substring(this StringBuilder sb, int index, int length)
        {            
            if (index < 0 || index >= sb.Length ||
                index + length < 0 || index + length >= sb.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            var newSb = new StringBuilder();

            for (int i = index; i < (index + length); i++)
            {
                newSb.Append(sb[i]);
            }

            return newSb;
        }
    }
}

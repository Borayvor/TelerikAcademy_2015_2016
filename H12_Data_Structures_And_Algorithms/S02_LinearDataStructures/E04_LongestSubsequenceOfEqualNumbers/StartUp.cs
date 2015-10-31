namespace E04_LongestSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utils;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var reader = new ConsoleReader();
            var sequence = reader.ReadSequenceOfInt();

            var longestSubsequenceOfEqualNumbers = GetLongestSubsequenceOfEqualNumbers(sequence);

            Console.WriteLine("Sequence : {0}", string.Join(", ", sequence));
            Console.WriteLine("Longest subsequence of equal numbers : {0}", string.Join(", ", longestSubsequenceOfEqualNumbers));
        }

        private static List<int> GetLongestSubsequenceOfEqualNumbers(List<int> sequence)
        {
            var longestSubsequence = 0;
            var currentSubsequence = 0;
            var subsequenceNumber = default(int);

            for (int i = 0; i < sequence.Count(); i++)
            {
                var currentElement = sequence[i];

                if (i == 0)
                {
                    currentSubsequence = 1;
                }
                else
                {
                    var previousElement = sequence[i - 1];

                    if (currentElement != previousElement)
                    {
                        currentSubsequence = 1;
                    }
                    else
                    {
                        ++currentSubsequence;
                    }
                }

                if (currentSubsequence > longestSubsequence)
                {
                    longestSubsequence = currentSubsequence;
                    subsequenceNumber = currentElement;
                }
            }

            return Enumerable.Repeat(subsequenceNumber, longestSubsequence).ToList();
        }
    }
}

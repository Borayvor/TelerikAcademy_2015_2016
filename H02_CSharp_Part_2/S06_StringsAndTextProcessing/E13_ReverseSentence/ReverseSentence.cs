namespace E13_ReverseSentence
{
    using System;
    using System.Collections;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ReverseSentence
    {
        public static void Main(string[] args)
        {
            // Write a program that reverses the words in given sentence.
            // Example:
            // input:
            // C# is not C++, not PHP and not Delphi!
            // output:
            // Delphi not and PHP, not C++ not is C#!

            string sentence = "C# is not C++, not PHP and not Delphi!";
            Console.WriteLine(sentence);
            Console.WriteLine();

            // logic or -> |
            string regex = @"\s+|\,\s*|\;\s*|\:\s*|\-\s*|\!\s*|\?\s*|\.\s*";

            Stack words = new Stack();
            Queue separators = new Queue();

            foreach (var word in Regex.Split(sentence, regex))
            {
                if (!String.IsNullOrEmpty(word))
                {
                    words.Push(word);
                }
            }

            foreach (Match separator in Regex.Matches(sentence, regex))
            {
                separators.Enqueue(separator);
            }

            StringBuilder reversedSentence = new StringBuilder();

            while (words.Count > 0 && separators.Count > 0)
            {
                reversedSentence.Append(words.Pop());

                reversedSentence.Append(separators.Dequeue());
            }

            Console.WriteLine(reversedSentence.ToString());
            Console.WriteLine();
        }
    }
}

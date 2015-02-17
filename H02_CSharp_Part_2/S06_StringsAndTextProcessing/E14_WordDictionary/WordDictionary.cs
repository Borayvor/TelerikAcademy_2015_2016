namespace E14_WordDictionary
{
    using System;
    using System.Text.RegularExpressions;

    public class WordDictionary
    {
        public static void Main(string[] args)
        {
            // A dictionary is stored as a sequence of text lines 
            // containing words and their explanations.
            // Write a program that enters a word and translates 
            // it by using the dictionary.
            // Sample dictionary:
            // input 	            output
            // .NET 	            platform for applications from Microsoft
            // CLR 	                managed execution environment for .NET
            // namespace 	        hierarchical organization of classes

            string[] dictionary = {
                                ".NET - platform for applications from Microsoft",
                                "CLR - managed execution environment for .NET",
                                "namespace - hierarchical - organization of classes"
                               };

            string word = ".NET";  // Console.ReadLine().Trim();

            foreach (string member in dictionary)
            {
                var explanation = Regex.Match(member, "(.*?) - (.*)").Groups;

                if (explanation[1].Value == word)
                {
                    Console.WriteLine("{0} - {1}", word, explanation[2]);
                    return;
                }
            }
        }
    }
}

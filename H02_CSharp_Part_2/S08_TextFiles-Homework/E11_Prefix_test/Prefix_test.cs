namespace E11_Prefix_test
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class Prefix_test
    {
        public static void Main(string[] args)
        {
            // Write a program that deletes from a text file all words 
            // that start with the prefix test.
            // Words contain only the symbols 0…9, a…z, A…Z, _.

            using (StreamReader streamReader = new StreamReader("../../Text.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter("../../Result.txt"))
                {
                    string line = streamReader.ReadLine();

                    while (line != null)
                    {
                        streamWriter.WriteLine(Regex.Replace(line, @"\bsub\w*\b", String.Empty));
                        line = streamReader.ReadLine();
                    }

                    Console.WriteLine("Result.txt - Done !");
                }
            }
        }
    }
}

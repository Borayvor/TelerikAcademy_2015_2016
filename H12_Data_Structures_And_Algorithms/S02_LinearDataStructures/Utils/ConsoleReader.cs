namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConsoleReader
    {
        public List<int> ReadSequenceOfInt()
        {
            var sequence = new List<int>();
            string input = null;
            int number = 0;

            Console.Write("Please enter a sequence (format - \", \"), or a number : ");

            input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) && input.Contains(","))
            {
                sequence = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToList();
            }
            else
            {
                while (!string.IsNullOrWhiteSpace(input) || !(sequence.Count > 0))
                {
                    var isNumber = int.TryParse(input, out number);

                    if (isNumber)
                    {
                        sequence.Add(number);
                    }

                    Console.Write("Please, enter a number : ");
                    input = Console.ReadLine();
                }
            }

            return sequence;
        }

        public int ReadSingleInt()
        {
            string input;
            bool isNumber = false;
            int number = 0;

            do
            {
                Console.Write("Please, enter a number : ");
                input = Console.ReadLine();

                isNumber = int.TryParse(input, out number);
            }
            while (!isNumber);

            return number;
        }
    }
}

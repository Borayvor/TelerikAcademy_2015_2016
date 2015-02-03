namespace E03_Enigmanation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Enigmanation
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine().Trim();

            List<string> expression = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    int endInBracketIndex = input.IndexOf(')', i);
                    string[] insideBrackets = input.Substring(i + 1, endInBracketIndex - i - 1)
                        .Select(x => x.ToString())
                        .ToArray();

                    expression.Add(GetResult(insideBrackets).ToString());
                    i = endInBracketIndex + 1;
                }

                if (input[i] == ')')
                {
                    i += 1;
                }

                expression.Add(input[i].ToString());
            }

            double result = GetResult(expression.ToArray());
            Console.WriteLine("{0:F3}", result);
        }

        private static double GetResult(string[] input)
        {
            const string SUM = "+";
            const string SUBTRACT = "-";
            const string MODULE = "%";
            const string MULTIPLY = "*";

            double result = double.Parse(input[0].ToString());

            for (int indexInput = 1; indexInput < input.Length; indexInput++)
            {
                if (input[indexInput - 1] == SUM)
                {
                    result += double.Parse(input[indexInput].ToString());                    
                }
                else if (input[indexInput - 1] == SUBTRACT)
                {
                    result -= double.Parse(input[indexInput].ToString());                    
                }
                else if (input[indexInput - 1] == MODULE)
                {
                    result %= double.Parse(input[indexInput].ToString());                    
                }
                else if (input[indexInput - 1] == MULTIPLY)
                {
                    result *= double.Parse(input[indexInput].ToString());                   
                }
            }

            return result;
        }
    }
}

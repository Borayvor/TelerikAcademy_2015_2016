namespace E03_CorrectBrackets
{
    using System;

    public class CorrectBrackets
    {
        public static void Main(string[] args)
        {
            // Write a program to check if in a given expression 
            // the brackets are put correctly.
            // Example of correct expression:  ((a+b)/5-d) 
            // Example of incorrect expression:  )(a+b))

            Console.WriteLine("((a + b) / 5 - d) --> {0}", 
                CheckBrackets("((a + b) / 5 - d)"));
            Console.WriteLine("))(a+b) --> {0}", CheckBrackets("))(a+b)"));
            Console.WriteLine("(a+b))( --> {0}", CheckBrackets("(a+b))("));
            Console.WriteLine("(a+b)(( --> {0}", CheckBrackets("(a+b)(("));
        }


        private static bool CheckBrackets(string str)
        {
            int unclosedParentheses = 0;

            for (int i = 0; i < str.Length && unclosedParentheses >= 0; i++)
            {
                if (str[i] == '(') unclosedParentheses++;
                if (str[i] == ')') unclosedParentheses--;
            }

            return unclosedParentheses == 0;
        }
    }
}

namespace E05_GameOfPage
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class GameOfPage
    {
        public static void Main(string[] args)
        {
            const double COOKIE_COST = 1.79;
            const string COMMAND_WHAT_IS = "what is";
            const string COMMAND_BUY = "buy";
            const string COMMAND_END = "paypal";

            ////StreamReader input = new StreamReader("..\\..\\input.txt");
            ////Console.SetIn(input);

            int[] cookieTray = new int[18];

            cookieTray[0] = 0;

            for (int row = 1; row < cookieTray.Length - 1; row++)
            {
                cookieTray[row] = Convert.ToInt32(Console.ReadLine().Trim(), 2);
            }

            cookieTray[cookieTray.Length - 1] = 0;

            List<string> questions = new List<string>();

            while (true)
            {
                string command = Console.ReadLine().Trim();

                if (command == COMMAND_END)
                {
                    break;
                }

                questions.Add(command);
            }

            List<string> answers = new List<string>();

            int cookieCount = 0;

            for (int index = 0; index < questions.Count; index++)
            {
                if (questions[index] == COMMAND_WHAT_IS)
                {
                    int row = int.Parse(questions[index + 1]) + 1;
                    int col = 15 - int.Parse(questions[index + 2]);

                    if (IsCookie(cookieTray, row, col))
                    {
                        answers.Add("cookie");
                    }
                    else if (IsBrokenCookie(cookieTray, row, col))
                    {
                        answers.Add("broken cookie");
                    }
                    else if (IsCrumb(cookieTray, row, col))
                    {
                        answers.Add("cookie crumb");
                    }
                    else
                    {
                        answers.Add("smile");
                    }

                    index += 2;
                }
                else if (questions[index] == COMMAND_BUY)
                {
                    int row = int.Parse(questions[index + 1]) + 1;
                    int col = 15 - int.Parse(questions[index + 2]);

                    if (IsCookie(cookieTray, row, col))
                    {
                        cookieCount++;
                        cookieTray = CookieTrayBuyCookie(cookieTray, row, col);
                    }
                    else if (IsCrumb(cookieTray, row, col) ||
                        IsBrokenCookie(cookieTray, row, col))
                    {
                        answers.Add("page");
                    }
                    else
                    {
                        answers.Add("smile");
                    }

                    index += 2;
                }
            }

            foreach (var answer in answers)
            {
                Console.WriteLine(answer);
            }

            Console.WriteLine("{0:0.00}", cookieCount * COOKIE_COST);
        }

        private static bool IsCrumb(int[] cookieTray, int row, int col)
        {
            return (cookieTray[row] & (1 << col)) != 0;
        }

        private static bool IsBrokenCookie(int[] cookieTray, int row, int col)
        {
            return IsCrumb(cookieTray, row, col) && (
                (cookieTray[row - 1] & (7 << (col - 1))) != 0 ||
                (cookieTray[row] & (1 << (col - 1))) != 0 ||
                (cookieTray[row] & (1 << (col + 1))) != 0 ||
                (cookieTray[row + 1] & (7 << (col - 1))) != 0
                );
        }

        private static bool IsCookie(int[] cookieTray, int row, int col)
        {
            return IsCrumb(cookieTray, row, col) && (
                (cookieTray[row - 1] & (7 << (col - 1))) != 0 &&
                (cookieTray[row] & (1 << (col - 1))) != 0 &&
                (cookieTray[row] & (1 << (col + 1))) != 0 &&
                (cookieTray[row + 1] & (7 << (col - 1))) != 0
                );
        }

        private static int[] CookieTrayBuyCookie(int[] cookieTray, int row, int col)
        {
            int[] newCookieTray = cookieTray;

            cookieTray[row - 1] ^= (7 << (col - 1));
            cookieTray[row] ^= (7 << (col - 1));
            cookieTray[row + 1] ^= (7 << (col - 1));

            return newCookieTray;
        }
    }
}

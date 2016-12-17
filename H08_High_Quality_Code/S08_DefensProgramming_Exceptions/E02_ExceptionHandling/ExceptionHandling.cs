namespace E02_ExceptionHandling
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionHandling
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            List<T> result = new List<T>();

            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count > str.Length)
            {
                count = str.Length;
            }

            StringBuilder result = new StringBuilder();

            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }

        public static void CheckPrime(int number)
        {
            if (number <= 1)
            {
                throw new ArgumentException("The input number cannot be one, zero, or negative !");
            }

            bool isPrime = true;

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                }
            }

            string stringNot = isPrime ? string.Empty : " not";

            Console.WriteLine("{0} is{1} prime !", number, stringNot);
        }

        public static void Main(string[] args)
        {
            var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));

            Console.WriteLine(ExtractEnding("I love C#", 2));
            Console.WriteLine(ExtractEnding("Nakov", 4));
            Console.WriteLine(ExtractEnding("beer", 4));
            Console.WriteLine(ExtractEnding("Hi", 100));

            try
            {
                CheckPrime(23);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            try
            {
                CheckPrime(33);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            List<Exam> peterExams = new List<Exam>()
            {
                new SimpleMathExam(2),
                new CSharpExam(55),
                new CSharpExam(100),
                new SimpleMathExam(1),
                new CSharpExam(0),
            };

            try
            {
                Student peter = new Student("Peter", "Petrov", peterExams);
                double peterAverageResult = peter.CalcAverageExamResultInPercents();
                Console.WriteLine("Student exams average results = {0:p0}", peterAverageResult);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("Student exams : " + ae.Message);
            }
        }
    }
}

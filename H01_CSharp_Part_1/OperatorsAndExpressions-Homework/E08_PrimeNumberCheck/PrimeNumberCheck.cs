namespace E08_PrimeNumberCheck
{
    using System;

    public class PrimeNumberCheck
    {
        public static void Main(string[] args)
        {
            // Write an expression that checks if given positive integer number n 
            // (n = 100) is prime (i.e. it is divisible without remainder only to itself and 1).
            // Examples:
            // 
            // n	Prime?
            // 1	false
            // 2	true
            // 3	true
            // 4	false
            // 9	false
            // 97	true
            // 51	false
            // -3	false
            // 0	false

            Console.WriteLine("Please enter a number to check if it is prime number !");
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            if (IsPrime(n))
            {
                Console.WriteLine("{0} is prime number.", n);
            }
            else
            {
                Console.WriteLine("{0} is not prime number.", n);
            }
        }


        private static bool IsPrime(int number)
        {
            if(number < 2)
            {
                return false;
            }

            if (number % 2 == 0 && number != 2)
            {
                return false;
            }

            for (int i = 3; (i * i) <= number; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

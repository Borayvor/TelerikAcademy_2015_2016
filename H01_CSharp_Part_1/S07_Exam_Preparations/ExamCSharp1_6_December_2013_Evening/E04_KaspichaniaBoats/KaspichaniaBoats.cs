namespace E04_KaspichaniaBoats
{
    using System;

    public class KaspichaniaBoats
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int width = n * 2 + 1;
            int height = 6 + ((n - 3) / 2) * 3;
            int halfN = n / 2;
           
            for (int indexHeight = 0; indexHeight < height; indexHeight++)
            {
                for (int indexWidth = 0; indexWidth < width; indexWidth++)
                {
                    if (indexHeight == n)
                    {
                        Console.Write("*");
                    }
                    else if (indexHeight == height - 1 &&
                        indexWidth >= n - halfN && indexWidth < width - n + halfN)
                    {
                        Console.Write("*");
                    }
                    else if (indexWidth == n || 
                        indexWidth == width - n - indexHeight - 1 || 
                        indexWidth == width - n + indexHeight - 1)
                    {
                        Console.Write("*");
                    }
                    else if (indexWidth == indexHeight - n ||
                        indexWidth == width - (indexHeight - n) - 1)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}

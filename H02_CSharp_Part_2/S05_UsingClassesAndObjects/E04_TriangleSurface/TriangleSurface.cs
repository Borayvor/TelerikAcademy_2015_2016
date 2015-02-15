namespace E04_TriangleSurface
{
    using System;

    public class TriangleSurface
    {
        public static void Main(string[] args)
        {
            // Write methods that calculate the surface of 
            // a triangle by given:
            // Side and an altitude to it;
            // Three sides;
            // Two sides and an angle between them;
            // Use System.Math.
            // A        B       C      altitude     angle       surface
            // 30                      21                       315.000
            // 30       30      30                              389.711
            // 30       30                          90          450.000

            CalculateSurfaceOfTriangle();
        }


        private static void CalculateSurfaceOfTriangle()
        {  
            byte userChoise;

            do
            {
                Console.WriteLine("Choose the method to calculate the surface of a triangle.");
                Console.WriteLine();
                Console.WriteLine("1. By side and altitude.");
                Console.WriteLine("2. By tree sides.");
                Console.WriteLine("3. Two sides and an angle between them. ");
                Console.WriteLine("4. Exit.");
                Console.WriteLine();

                userChoise = (byte)GetNumber("your choice");

                CalculateTheSurface(userChoise);
            } 
            while (userChoise != 4);            
        }

        private static void CalculateTheSurface(byte userChoise)
        {
            double sideA;
            double sideB;
            double sideC;
            double altitude;
            int angle;
            double surface;

            switch (userChoise)
            {
                case 1:
                    {
                        Console.WriteLine();
                        sideA = GetNumber("side A");
                        altitude = GetNumber("altitude");

                        if (sideA > 0 && altitude > 0)
                        {
                            surface = GetTriangleSurface(sideA, altitude);
                            Console.WriteLine("The surface is : {0:F3}", surface);
                        }
                        else
                        {
                            Console.WriteLine("The side or altitude of triangle is not correct."); 
                        }

                        break;                    
                    }
                case 2:
                    {
                        Console.WriteLine();
                        sideA = GetNumber("side A");
                        sideB = GetNumber("side B");
                        sideC = GetNumber("side C");

                        if ((sideA > 0 &&
                            sideB > 0 &&
                            sideC > 0) &&
                            (sideA < (sideB + sideC) ||
                            sideB < (sideA + sideC) ||
                            sideC < (sideB + sideA)))
                        {
                            surface = GetTriangleSurface(sideA, sideB, sideC);
                            Console.WriteLine("The surface of triangle is : {0:F3}", surface);
                        }
                        else
                        {
                            Console.WriteLine("One of the sides is not correct.");  
                        }

                        break;                        
                    }
                case 3:
                    {
                        Console.WriteLine();
                        sideA = GetNumber("side A");
                        sideB = GetNumber("side B");
                        angle = (int)GetNumber("an angle");

                        if (angle > 0 && angle < 180 && sideA > 0 && sideB > 0)
                        {
                            surface = GetTriangleSurface(sideA, sideB, angle);
                            Console.WriteLine("The surface of triangle is : {0:F3}", surface);
                        }
                        else
                        {
                            Console.WriteLine("The angle or side is not correct.");
                        }
                    
                    break;
                    }
                default:
                    {                        
                        break;
                    }
            }

            ConsoleKeyInfo keyinfo;

            do
            {
                Console.WriteLine("Press Spacebar to continue...");
                keyinfo = Console.ReadKey();                
            }
            while (keyinfo.Key != ConsoleKey.Spacebar);

            Console.Clear();
            Console.OpenStandardOutput();
        }

        private static double GetTriangleSurface(double side, double altitude)
        {
            return ((side * altitude) / 2);
        }

        private static double GetTriangleSurface(double sideA, double sideB, double sideC)
        {
            double semiperimeter = ((sideA + sideB + sideC) / 2);

            return Math.Sqrt(semiperimeter * (semiperimeter - sideA) *
                (semiperimeter - sideB) * (semiperimeter - sideC));
        }

        private static double GetTriangleSurface(double sideA, double sideB, int angle)
        {
            double pi = Math.PI;

            double sin = Math.Sin((angle * pi) / 180);

            return ((sideA * sideB * sin) / 2);
        }

        private static double GetNumber(string name)
        {                                 
            double number = double.MinValue;
            bool isNumber = false;

            do
            {
                Console.Write("Please, enter {0}: ", name);
                isNumber = double.TryParse(Console.ReadLine(), out number);
            } 
            while (isNumber == false && number < 0);

            return number;
        }
    }
}

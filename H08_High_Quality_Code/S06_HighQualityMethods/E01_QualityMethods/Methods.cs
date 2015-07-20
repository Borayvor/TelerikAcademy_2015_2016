namespace E01_QualityMethods
{
    using System;

    public class Methods
    {
        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                //Console.Error.WriteLine("Sides should be positive.");
                //return -1;
                throw new ArgumentException("The sides should be positive " + 
                    "numbers bigger than zero !");
            }

            double semiperimeter = (sideA + sideB + sideC) / 2;

            double triangleArea = Math.Sqrt(semiperimeter * (semiperimeter - sideA) *
                (semiperimeter - sideB) * (semiperimeter - sideC));

            return triangleArea;
        }

        public static string DigitToEnglishName(int digit)
        {
            switch (digit)
            {
                case 0:
                    {
                        return "zero";
                    }
                case 1:
                    {
                        return "one";
                    }
                case 2:
                    {
                        return "two";
                    }
                case 3:
                    {
                        return "three";
                    }
                case 4:
                    {
                        return "four";
                    }
                case 5:
                    {
                        return "five";
                    }
                case 6:
                    {
                        return "six";
                    }
                case 7:
                    {
                        return "seven";
                    }
                case 8:
                    {
                        return "eight";
                    }
                case 9:
                    {
                        return "nine";
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException("Invalid number ! " + 
                            "The number is out of range !");
                    }
            }
        }

        public static int FindBiggestElement(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                //return -1;
                throw new ArgumentNullException("The array cannot be null, or " + 
                    "with length equal to zero !");
            }

            int biggestElement = int.MinValue;

            for (int index = 1; index < elements.Length; index++)
            {
                if (elements[index] > biggestElement)
                {
                    biggestElement = elements[index];
                }
            }

            return biggestElement;
        }

        public static void PrintNumberInFormat(object numberObj, string signForFormat)
        {
            //if (format == "f")
            //{
            //    Console.WriteLine ("{0:f2}", number);
            //}
            //if (format == "%")
            //{
            //    Console.WriteLine ("{0:p0}", number);
            //}
            //if (format == "r")
            //{
            //    Console.WriteLine ("{0,8}", number);
            //}

            decimal number = ObjectToDecimal(numberObj);

            string format = GetFormatForPrint(signForFormat);

            Console.WriteLine(format, number);
        }

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        // out bool isHorizontal, out bool isVertical
        // isHorizontal = (y1 == y2);
        // isVertical = (x1 == x2);

        public static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = (y1 == y2);

            return isHorizontal;
        }

        public static bool IsVertical(double x1, double x2)
        {
            bool isVertical = (x1 == x2);

            return isVertical;
        }

        private static decimal ObjectToDecimal(object numberObject)
        {
            decimal newDecimalNumber;

            try
            {
                newDecimalNumber = Convert.ToDecimal(numberObject);
            }
            catch (FormatException)
            {
                throw new FormatException("The input value is not a number !");
            }

            return newDecimalNumber;
        }

        private static string GetFormatForPrint(string format)
        {
            switch (format)
            {
                case "f":
                    {
                        return "{0:f2}";
                    }
                case "%":
                    {
                        return "{0:p0}";
                    }
                case "r":
                    {
                        return "{0,8}";
                    }
                default:
                    {
                        throw new ArgumentException("Invalid format ! " + 
                            "Not supported format for print !");
                    }
            }
        }
               
        
        public static void Main()
        {
            Console.WriteLine("Triangle area : {0}", CalculateTriangleArea(3, 4, 5));

            Console.WriteLine("Digit to english name : {0}", DigitToEnglishName(5));

            Console.Write("Find biggest element (5, -1, 3, 2, 14, 2, 3) : ");
            Console.WriteLine(FindBiggestElement(5, -1, 3, 2, 14, 2, 3));

            Console.WriteLine();
            Console.WriteLine("Print number in format:");
            PrintNumberInFormat(1.3, "f");
            PrintNumberInFormat(0.75, "%");
            PrintNumberInFormat(2.30, "r");

            Console.WriteLine();
            double distance = CalculateDistance(3, -1, 3, 2.5);
            Console.WriteLine("Distance = {0}", distance);

            bool horizontal = IsHorizontal(-1, 2.5);
            bool vertical = IsVertical(3, 3);
            Console.WriteLine("Horizontal ? -> " + horizontal);
            Console.WriteLine("Vertical ? -> " + vertical);

            Student peter = new Student("Peter", "Ivanov");
            peter.Location = "Sofia";
            peter.DateOfBirth = "17.03.1992";
            //peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student("Stella", "Markova");
            stella.Location = "Vidin";
            stella.DateOfBirth = "03.11.1993";
            stella.Profession = "gamer";
            stella.OtherInfo = "high results";
            //stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine();
            Console.WriteLine("Peter date of birth: {0}", peter.DateOfBirth);
            Console.WriteLine("Stella date of birth: {0}", stella.DateOfBirth);
            Console.WriteLine("{0} is older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}

namespace E11_NumberAsWords
{
    using System;

    public class NumberAsWords
    {
        public static void Main(string[] args)
        {
            // Write a program that converts a number in the range [0…999] 
            // to words, corresponding to the English pronunciation.
            // Examples:
            // 
            // numbers	    number as words
            // 0	        Zero
            // 9	        Nine
            // 10	        Ten
            // 12	        Twelve
            // 19	        Nineteen
            // 25	        Twenty five
            // 98	        Ninety eight
            // 98	        Ninety eight
            // 273	        Two hundred and seventy three
            // 400	        Four hundred
            // 501	        Five hundred and one
            // 617	        Six hundred and seventeen
            // 711	        Seven hundred and eleven
            // 999	        Nine hundred and ninety nine

            int number = -1;
            do
            {
                Console.WriteLine("Please, enter a number in the range [0…999] !");
                Console.Write("number = ");
                number = int.Parse(Console.ReadLine());
            }
            while (number < 0 || number > 999);

            string numberAsString = number.ToString();
            string numberAsWords = "";

            for (int i = 0; i < numberAsString.Length; i++)
            {
                int powerOfTen = (int)Math.Pow(10, (numberAsString.Length - 1) - i);
                int value = number / powerOfTen;

                switch (powerOfTen)
                {
                    case 100:
                        {
                            numberAsWords += Enum.GetName(typeof(NumbersNames), value);
                            numberAsWords += " ";
                            numberAsWords += Enum.GetName(typeof(NumbersNames), powerOfTen);
                            break;
                        }
                    case 10:
                        {
                            if (numberAsString.Length > 2)
                            {
                                numberAsWords += "and ";
                            }

                            if (value == 0)
                            {
                                continue;
                            }
                            else
                            {
                                if (value == 1)
                                {
                                    numberAsWords += Enum.GetName(typeof(NumbersNames), number);
                                    break;
                                }

                                numberAsWords += Enum.GetName(typeof(NumbersNames), value * powerOfTen);
                            }
                            break;
                        }
                    default:
                        {
                            numberAsWords += Enum.GetName(typeof(NumbersNames), value);
                            break;
                        }
                }

                if (number >= 20)
                {
                    number %= powerOfTen;

                    if (i < numberAsString.Length)
                    {
                        numberAsWords += " ";
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(numberAsWords);
            Console.WriteLine();
        }
    }
}

namespace E09_PlayWithInt_DoubleAndString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PlayWithInt_DoubleAndString
    {
        public static void Main(string[] args)
        {
            // Write a program that, depending on the user’s choice, 
            // inputs an int, double or string variable.
            // If the variable is int or double, the program increases it by one.
            // If the variable is a string, the program appends * at the end.
            // Print the result at the console. Use switch statement.
            // Example 1:
            // 
            // program	                user
            // Please choose a type:	
            // 1 --> int	
            // 2 --> double	            3
            // 3 --> string	
            // Please enter a string:	hello
            // hello*
            //
            // Example 2:
            //
            // program	                user
            // Please choose a type:	
            // 1 --> int	
            // 2 --> double	            2
            // 3 --> string	
            // Please enter a double:	1.5
            // 2.5	

            Console.WriteLine("Please choose a type:");
            Console.WriteLine("1 --> int");
            Console.WriteLine("2 --> double");
            Console.WriteLine("3 --> string");

            int userChoose = 0;
            do
            {
                Console.Write("user = ");
                userChoose = int.Parse(Console.ReadLine());
            }
            while (userChoose < 1 || userChoose > 3);

            switch (userChoose)
            {
                case 1:
                    {
                        Console.Write("Please enter a integer:");
                        int value = int.Parse(Console.ReadLine());
                        Console.WriteLine("Result --> {0}", value + 1);
                        break;
                    }
                case 2:
                    {
                        Console.Write("Please enter a double:");
                        double value = double.Parse(Console.ReadLine());
                        Console.WriteLine("Result --> {0}", value + 1);
                        break;
                    }
                default:
                    {
                        Console.Write("Please enter a string:");
                        string  value = Console.ReadLine();
                        Console.WriteLine("Result --> {0}", value + '*');
                        break;
                    }
            }

        }
    }
}

namespace E04_PrintADeckOf_52_Cards
{
    using System;
    using System.Text;

    public class PrintADeckOf_52_Cards
    {
        public static void Main(string[] args)
        {
            // Write a program that generates and prints all possible 
            // cards from a standard deck of 52 cards (without the 
            // jokers). The cards should be printed using the classical 
            // notation (like 5 of spades, A of hearts, 9 of clubs; 
            // and K of diamonds).
            // The card faces should start from 2 to A.
            // Print each card face in its four possible suits: clubs, 
            // diamonds, hearts and spades. Use 2 nested for-loops 
            // and a switch-case statement.
            // output:
            // 
            // 2 of spades, 2 of clubs, 2 of hearts, 2 of diamonds
            // 3 of spades, 3 of clubs, 3 of hearts, 3 of diamonds
            // …  
            // K of spades, K of clubs, K of hearts, K of diamonds
            // A of spades, A of clubs, A of hearts, A of diamonds
            // Note: You may use the suit symbols instead of text.

            Console.OutputEncoding = Encoding.Unicode;
              
            string[] cardFaces = new string[] { "2", "3", "4", "5", "6", "7", 
                "8", "9", "10", "J", "D", "K", "A" };

            Console.WriteLine("|{0,10}|{1,10}|{2,10}|{3,10}|", 
                "Hearts", "Diamonds", "Clubs", "Spades");

            foreach (var face in cardFaces)
            {
                for (int i = 3; i <= 6; i++)
                {
                    Console.Write("|{0,10}", face + (char)i);
                }

                Console.WriteLine("|");
            }

            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}

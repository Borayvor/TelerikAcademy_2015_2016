namespace E03_CheckForAPlayCard
{
    using System;   

    public class CheckForAPlayCard
    {
        public static void Main(string[] args)
        {
            // Classical play cards use the following signs to designate 
            // the card face: `2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K and A. 
            // Write a program that enters a string and prints “yes” if it 
            // is a valid card sign or “no” otherwise. Examples:
            // character	Valid card sign?
            // 5	        yes
            // 1	        no
            // Q	        yes
            // q	        no
            // P	        no
            // 10	        yes
            // 500	        no            

            Console.WriteLine("Please, enter a sign of card  from classical play cards !");
            Console.Write("sign = ");
            string sign = Console.ReadLine().Trim();

            Console.WriteLine(IsValidCardSign(sign) ? "yes" : "no");
        }

        private static bool IsValidCardSign(string cardSign)
        {
            string[] cardsFaces = { "2", "3", "4", "5", "6", "7", "8", 
                                      "9", "10", "J", "Q", "K", "A" };

            return (Array.IndexOf(cardsFaces, cardSign) != -1);
        }
    }
}

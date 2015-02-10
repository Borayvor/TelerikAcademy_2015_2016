﻿namespace E01_SayHello
{
    using System;

    public class SayHello
    {
        public static void Main(string[] args)
        {
            // Write a method that asks the user for his 
            // name and prints “Hello, <name>”
            // Write a program to test this method.
            // Example:
            // input 	        output
            // Peter 	        Hello, Peter!

            Hello();
        }


        private static void Hello()
        {
            Console.WriteLine("Hello, what's your name ?");

            string name = Console.ReadLine().Trim();

            Console.WriteLine("Hello, {0} !", name);
        }
    }
}

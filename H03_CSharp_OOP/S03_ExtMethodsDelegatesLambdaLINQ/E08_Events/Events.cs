﻿namespace E08_Events
{
    using System;
    using System.Threading;

    public class Events
    {
        static event EventHandler<ConsoleKey> HandleX;
        static event EventHandler<ConsoleKey> HandleSpace;
        static void Trigger(ConsoleKey key)
        {
            if (key == ConsoleKey.X)
                HandleX(null, ConsoleKey.X);
            if (key == ConsoleKey.Spacebar)
                HandleSpace(null, ConsoleKey.Spacebar);
        }
        static void HandleKeyPress(object sender, ConsoleKey key)
        {
            Console.Clear();
            Console.WriteLine("You pressed {0}.", key.ToString());
        }
        static void SetInterval(Action f, int t)
        {
            while (!(Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Spacebar))
            {
                Thread.Sleep(t * 1000);
                f();
            }
        }

        public static void Main(string[] args)
        {
            // Read in MSDN about the keyword event in C# and how to publish events.
            // Re-implement the above using .NET events and following the best practices.

            Console.WriteLine("Press X to test or Space bar to start the timer.");
            HandleX = HandleKeyPress;
            HandleSpace = HandleKeyPress;

            HandleSpace += (a, b) =>
            {
                Console.WriteLine("Starting Timer.");
                Console.WriteLine("Press Space bar to stop.");

                SetInterval(new Action(() =>
                Console.WriteLine(DateTime.Now)
                ), 1);
            };

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Trigger(Console.ReadKey().Key);
                }
            }
        }
    }
}

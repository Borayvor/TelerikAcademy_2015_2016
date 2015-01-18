namespace E12_FallingRocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class FallingRocks
    {
        private static Random randomGenerator = new Random();

        public static void Main(string[] args)
        {
            // Implement the "Falling Rocks" game in the text console.
            // A small dwarf stays at the bottom of the screen and can 
            // move left and right (by the arrows keys).
            // A number of rocks of different sizes and forms constantly 
            // fall down and you need to avoid a crash.
            // Rocks are the symbols ^, @, *, &, +, %, $, #, !, ., ;, - distributed 
            // with appropriate density. The dwarf is (O).
            // Ensure a constant game speed by Thread.Sleep(150).
            // Implement collision detection and scoring system.

            GameField game = new GameField();
                        

            Thread inputThread = new Thread(delegate()
            {
                while (true)
                {
                    game.Player.Move();                    
                }
            });

            inputThread.IsBackground = true;
            inputThread.Start();
            game.StartPlay();
        }        
    }
}

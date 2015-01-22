namespace E12_FallingRocks
{
    using System;

    public class Rock : AbstractGameObject, IPrintable
    {   
        public void SetRandom(int width, Random randomGenerator)
        {            
            char[] symbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', ';' };

            ConsoleColor[] colors = {ConsoleColor.Red, ConsoleColor.DarkCyan,
                                    ConsoleColor.Black, ConsoleColor.Blue, 
                                    ConsoleColor.Red, ConsoleColor.Magenta,
                                    ConsoleColor.DarkYellow, ConsoleColor.DarkRed, 
                                    ConsoleColor.DarkGray, ConsoleColor.DarkGreen, 
                                    ConsoleColor.DarkBlue};

            this.Y = 0;
            this.X = randomGenerator.Next(0, width);
            this.Color = colors[randomGenerator.Next(0, colors.Length)];
            this.ObjectForm = symbols[randomGenerator.Next(0, symbols.Length)].ToString(); 
        }

        public void Fall()
        {            
            this.Clear();
            this.Y += 1;
            this.Print();
        }
    }
}

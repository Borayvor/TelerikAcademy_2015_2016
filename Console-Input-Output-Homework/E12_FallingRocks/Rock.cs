namespace E12_FallingRocks
{
    using System;

    public class Rock : AbstractGameObject, IPrintable
    {
        //public Rock(int x, int y, ConsoleColor color, string objectForm)
        //    : base(x, y, color, objectForm)
        //{
 
        //}

        public void SetRandom(int width)
        {
            Random generator = new Random();
            char[] symbols = { '^', '@', '*', '&', '+', '%', '$', '#', '!', ';' };

            ConsoleColor[] colors = {ConsoleColor.Red, ConsoleColor.DarkCyan,
                                    ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Magenta,
                                    ConsoleColor.DarkYellow, ConsoleColor.DarkRed, ConsoleColor.DarkGray,
                                    ConsoleColor.DarkGreen, ConsoleColor.DarkBlue};

            this.Y = 0;
            this.X = generator.Next(0, width);
            this.Color = colors[generator.Next(0, colors.Length)];
            this.ObjectForm = symbols[generator.Next(0, symbols.Length)].ToString(); 
        }
    }
}

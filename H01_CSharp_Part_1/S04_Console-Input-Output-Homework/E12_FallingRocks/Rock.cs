namespace E12_FallingRocks
{
    using System;

    public class Rock : AbstractGameObject, IDrawable
    {
        private const char[] SYMBOLS = { '^', '@', '*', '&', '+', '%', '$', '#', '!', ';' };

        public Rock(int x, int y, ConsoleColor color, Random randomGenerator)
            : base(x, y, color)
        {
            this.ObjectForm = SYMBOLS[randomGenerator.Next(0, SYMBOLS.Length)].ToString();
        }  
        
    
    }
}

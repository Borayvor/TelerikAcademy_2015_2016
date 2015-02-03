namespace E12_FallingRocks
{
    using System;

    public interface IDrawable
    {
        int X { get; set; }
        int Y { get; set; }
        ConsoleColor Color { get; set; }                
    }
}

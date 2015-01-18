namespace E12_FallingRocks
{
    using System;

    public interface IPrintable
    {
        int X { get; set; }
        int Y { get; set; }
        ConsoleColor Color { get; set; }

        void Print();
    }
}

namespace E12_FallingRocks
{
    using System;

    public class Dwarf : AbstractGameObject, IPrintable
    {
        private readonly int WINDOW_WIDTH_START;
        private readonly int WINDOW_WIDTH_END;

        public Dwarf(int x, int y, ConsoleColor color, string objectForm)
            : base(x, y, color, objectForm)
        {
            WINDOW_WIDTH_START = 0;
            WINDOW_WIDTH_END = (Console.WindowWidth / 3) * 2;
        }

        public void Move()
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            switch (pressedKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        if (this.X - 1 >= WINDOW_WIDTH_START)
                        {
                            this.Clear();                            
                            this.X -= 1;
                            this.Print();
                        }
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        if (this.X < WINDOW_WIDTH_END - 1)
                        {
                            this.Clear();                            
                            this.X += 1;
                            this.Print();
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}

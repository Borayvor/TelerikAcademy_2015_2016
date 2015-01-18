namespace E12_FallingRocks
{
    using System;

    public class Dwarf : AbstractGameObject, IPrintable
    {
        public Dwarf(int x, int y, ConsoleColor color, string objectForm)
            : base(x, y, color, objectForm)
        {
 
        }

        public void Move()
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey(true);

            switch (pressedKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        if (this.X - 1 >= 0)
                        {
                            this.Clear();                            
                            this.X -= 1;
                            this.Print();
                        }
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        if (this.X + 1 < (Console.WindowWidth / 3) * 2)
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

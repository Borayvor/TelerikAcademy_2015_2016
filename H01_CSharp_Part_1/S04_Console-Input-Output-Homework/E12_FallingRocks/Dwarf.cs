namespace E12_FallingRocks
{
    using System;

    public class Dwarf : AbstractGameObject, IDrawable
    {
        private const string LIVE_FORM = "(O)";
        private const string DEAD_FORM = "(X)";

        public Dwarf(int x, int y, ConsoleColor color)
            : base(x, y, color)
        {
            this.ObjectForm = LIVE_FORM;
        }

        public void Move(ConsoleKeyInfo pressedKey)
        {
            switch (pressedKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        this.X -= 1;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        this.X += 1;
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

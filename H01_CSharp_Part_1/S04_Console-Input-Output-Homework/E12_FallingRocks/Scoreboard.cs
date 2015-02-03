namespace E12_FallingRocks
{
    using System;

    public class Scoreboard : IDrawable
    {
        private int x;
        private int y;
        private ConsoleColor color;
        private int amount;
        private string message;

        public Scoreboard(int xInitial, int yInitial, ConsoleColor colorInitial,
            string messageInitial, int amountIntitial)
        {
            this.X = xInitial;
            this.Y = yInitial;
            this.Color = colorInitial;
            this.Message = messageInitial;    
            this.Amount = amountIntitial;
        }

        public int X
        {
            get
            {
                return this.x;
            }

            set
            {
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }

            set
            {
                this.y = value;
            }
        }

        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                this.message = value;
            }
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }

            set
            {
                this.amount = value;
            }
        }               
    }
}

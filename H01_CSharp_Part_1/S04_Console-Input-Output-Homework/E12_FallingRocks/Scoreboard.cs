namespace E12_FallingRocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Scoreboard : AbstractGameObject, IPrintable
    {
        private int amount;        

        public Scoreboard(int x, int y, ConsoleColor color, string message, int amountIntitial)
            : base(x, y, color, message)
        {
            this.Amount = amountIntitial;                       
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

        
        public override void Print()
        {
            base.Print();
            Console.Write(" " + this.Amount);
        }                
    }
}

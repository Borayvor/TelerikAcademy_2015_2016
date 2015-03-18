namespace E12_FallingRocks
{
    using System;

    public class Rock : AbstractGameObject, IPrintable
    {
        public Rock(int x, int y, ConsoleColor color, string objectForm)
            : base(x, y, color, objectForm)
        {
 
        }
       
        public void Fall()
        {            
            this.Clear();
            this.Y += 1;
            this.Print();
        }
    }
}

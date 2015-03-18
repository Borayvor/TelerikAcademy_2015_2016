namespace E12_FallingRocks
{
    using System;

    public abstract class AbstractGameObject : IPrintable
    {
        private int x;
        private int y;
        private ConsoleColor color;
        private string objectForm;
        private string empty;        
                
        internal AbstractGameObject(int x, int y, ConsoleColor color, string objectForm)
        {
            this.X = x;
            this.Y = y;
            this.Color = color;
            this.ObjectForm = objectForm;            

            for (int i = 0; i < this.ObjectForm.Length; i++)
            {
                this.Empty += " ";
            }
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

        public string ObjectForm
        {
            get
            {
                return this.objectForm;
            }

            set
            {
                this.objectForm = value;
            }
        }
                
        protected string Empty
        {
            get
            {
                return this.empty;
            }

            set
            {
                this.empty = value;
            }
        }


        public virtual void Print()
        {            
            Console.SetCursorPosition(this.X, this.Y);
            Console.ForegroundColor = this.Color;
            Console.Write(this.ObjectForm);
        }

        public virtual void Clear()
        {
            Console.SetCursorPosition(this.X, this.Y);
            Console.Write(this.Empty);
        }
    }
}

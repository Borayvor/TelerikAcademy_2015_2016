namespace E12_FallingRocks
{
    using System;

    public abstract class AbstractGameObject : IDrawable
    {
        private int x;
        private int y;
        private ConsoleColor color;
        private string objectForm;
        private string empty;        
                
        internal AbstractGameObject(int xInitial, int yInitial, ConsoleColor colorInitial)
        {
            this.X = xInitial;
            this.Y = yInitial;
            this.Color = colorInitial;

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
    }
}

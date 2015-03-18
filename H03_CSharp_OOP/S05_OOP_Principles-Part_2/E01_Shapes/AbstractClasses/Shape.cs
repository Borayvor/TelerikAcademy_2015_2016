namespace E01_Shapes.AbstractClasses
{
    using System;

    public abstract class Shape
    {
        private double width;
        private double height;
        private double radius;

        protected Shape(double radius)            
        {
            this.Radius = radius;
        }

        protected Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
            
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width must be positive.");
                }

                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height must be positive.");
                }
                
                this.height = value;
            }
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height must be positive.");
                }

                this.radius = value;
            }
        }

        public abstract double CalculateSurface();
    }
}

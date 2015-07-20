namespace Abstraction
{
    using System;

    public class Rectangle : AbstractShape, IShape
    {
        private double widthPrivate;
        private double heightPrivate;    

        public Rectangle(double width, double height)           
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get
            {
                return this.widthPrivate;
            }

            private set
            {
                this.ValidateDoubleValue(value, "Width");

                this.widthPrivate = value;
            }
        }

        public double Height
        {
            get
            {
                return this.heightPrivate;
            }

            private set
            {
                this.ValidateDoubleValue(value, "Height");

                this.heightPrivate = value;
            }
        }

        public override double CalculatePerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = this.Width * this.Height;
            return surface;
        }
    }
}

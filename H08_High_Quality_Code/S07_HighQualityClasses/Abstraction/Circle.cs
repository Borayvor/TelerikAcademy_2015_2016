namespace Abstraction
{
    using System;

    public class Circle : AbstractShape, IShape
    {
        private double radiusPrivate;

        public Circle(double radius)           
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radiusPrivate;
            }

            private set
            {
                this.ValidateDoubleValue(value, "Radius");

                this.radiusPrivate = value;
            }
        }
                     
        public override double CalculatePerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalculateSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }        
    }
}

namespace E01_Shapes
{
    using System;

    using E01_Shapes.AbstractClasses;    

    public class Circle : Shape
    {
        public Circle(double radius)
            : base(radius)
        {
        }

        public override double CalculateSurface()
        {
            return Math.Pow(this.Radius , 2) * System.Math.PI;
        }
    }
}

namespace E01_Shapes
{
    using E01_Shapes.AbstractClasses;

    public class Triangle : Shape
    {
        public Triangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return (this.Width * (this.Height / 2));
        }
    }
}

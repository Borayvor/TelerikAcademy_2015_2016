namespace E01_Shapes
{
    using E01_Shapes.AbstractClasses;

    public class Rectangle : Shape
    {
        public Rectangle(double width, double height)
            : base(width, height)
        {
        }

        public override double CalculateSurface()
        {
            return (this.Width * this.Height);
        }
    }
}

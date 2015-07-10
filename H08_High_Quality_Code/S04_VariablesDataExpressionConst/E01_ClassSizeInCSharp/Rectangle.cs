namespace E01_ClassSizeInCSharp
{
    public class Rectangle
    {
        public Rectangle(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }
        
        public double Width { get; private set; }

        public double Height { get; private set; }

        public Rectangle GetRotatedSize(Rectangle rotatedSize, double rotatedAngle)
        {
            double newWidth = (Math.Abs(Math.Cos(rotatedAngle)) * rotatedSize.Width) 
                + (Math.Abs(Math.Sin(rotatedAngle)) * rotatedSize.Height);

            double newHeight = (Math.Abs(Math.Sin(rotatedAngle)) * rotatedSize.Width)
                + (Math.Abs(Math.Cos(rotatedAngle)) * rotatedSize.Height);

            var rotatedRectangle = new Rectangle(newWidth, newHeight);

            return rotatedRectangle;
        }
    }
}

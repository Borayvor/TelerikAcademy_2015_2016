namespace Abstraction
{
    using System;

    public abstract class AbstractShape : IShape
    {    
        public abstract double CalculatePerimeter();

        public abstract double CalculateSurface();

        protected void ValidateDoubleValue(double value, string valueName)
        {
            if (value < 0 || value == 0)
            {
                throw new ArgumentOutOfRangeException(" " + valueName 
                    + " cannot be zero, or negative !");
            }
        }
    }
}

namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Methods for calculation in 2D
    /// </summary>
    public static class Utils2D
    {
        /// <summary>
        /// Calculates distance between two points in 2D space.
        /// </summary>
        /// <param name="x1">First point x axis.</param>
        /// <param name="y1">First point y axis.</param>
        /// <param name="x2">Second point x axis.</param>
        /// <param name="y2">Second point y axis.</param>
        /// <returns>The calculated distance as double value.</returns>
        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {  
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }

        /// <summary>
        /// Calculates diagonal of figure in 2D space.
        /// </summary>
        /// <param name="width">The width of the figure.</param>
        /// <param name="height">The height of the figure.</param>
        /// <returns>The calculated diagonal as double value.</returns>
        public static double CalculateDiagonal(double width, double height)
        {
            double diagonal = Math.Sqrt((width * width) + (height * height));

            return diagonal;
        }
    }
}

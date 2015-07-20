namespace CohesionAndCoupling
{
    using System;

    /// <summary>
    /// Methods for calculation in 3D
    /// </summary>
    public static class Utils3D
    {      
        /// <summary>
        /// Calculates distance between two points in 3D space.
        /// </summary>
        /// <param name="x1">First point x axis.</param>
        /// <param name="y1">First point y axis.</param>
        /// <param name="z1">First point z axis.</param>
        /// <param name="x2">Second point x axis.</param>
        /// <param name="y2">Second point y axis.</param>
        /// <param name="z2">Second point z axis.</param>
        /// <returns>The calculated distance as double value.</returns>
        public static double CalculateDistance(double x1, double y1, double z1, 
            double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) 
                + ((z2 - z1) * (z2 - z1)));

            return distance;
        }
        
        /// <summary>
        /// Calculates diagonal of 3D figure.        
        /// </summary>
        /// <param name="width">The width of the figure.</param>
        /// <param name="height">The height of the figure.</param>
        /// <param name="depth">The depth of the figure.</param>
        /// <returns>The calculated diagonal as double value.</returns>
        public static double CalculateDiagonal(double width, double height, double depth)
        {
            double diagonal = Math.Sqrt((width * width) + (height * height) + (depth * depth));

            return diagonal;
        }

        /// <summary>
        /// Calculates volume of 3D figure.        
        /// </summary>
        /// <param name="width">The width of the figure.</param>
        /// <param name="height">The height of the figure.</param>
        /// <param name="depth">The depth of the figure.</param>
        /// <returns>The calculated diagonal as decimal value.</returns>
        public static decimal CalculateVolume(double width, double height, double depth)
        {
            decimal volume = (decimal)width * (decimal)height * (decimal)depth;

            return volume;
        }
    }
}

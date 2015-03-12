namespace E01_Space3D
{
    using System;

    // 03. Static class
    // Write a static class with a static method to calculate the 
    // distance between two points in the 3D space.
    public static class Distance3D
    {
        public static double Calculate(Point3D firstPoint, Point3D secontPoint)
        {
            double deltaX = secontPoint.X - firstPoint.X;
            double deltaY = secontPoint.Y - firstPoint.Y;
            double deltaZ = secontPoint.Z - firstPoint.Z;

            double distance = (double)Math.Sqrt((deltaX * deltaX) + 
                (deltaY * deltaY) + (deltaZ * deltaZ));

            return distance;
        }
    }
}

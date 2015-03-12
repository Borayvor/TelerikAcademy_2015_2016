namespace E01_Space3D
{
    using System;

    // 01. Structure
    // Create a structure Point3D to hold a 3D-coordinate {X, Y, Z} 
    // in the Euclidian 3D space.
    // Implement the ToString() to enable printing a 3D point.
    public struct Point3D
    {  
        // 02. Static read-only field
        // Add a private static read-only field to hold the start of the 
        // coordinate system – the point O{0, 0, 0}.
        // Add a static property to return the point O.
        private static readonly Point3D zeroPoint = new Point3D(0, 0, 0);
                
        public Point3D(int x, int y, int z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public static Point3D ZeroPoint
        {
            get
            {
                return zeroPoint;
            }
        }

        public override string ToString()
        {
            return string.Format("X = {0} , Y = {1} , Z = {2}", X, Y, Z);
        }
    }
}

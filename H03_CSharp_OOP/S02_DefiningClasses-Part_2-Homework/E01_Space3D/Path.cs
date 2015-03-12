namespace E01_Space3D
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    // 04. Path
    // Create a class Path to hold a sequence of points in the 3D space.
    public class Path
    {
        private readonly ICollection<Point3D> pathOfPoints;

        public Path()
        {
            pathOfPoints = new List<Point3D>();
        }
          
        /// <summary>
        /// Zero Point
        /// </summary>
        public void AddPoint()
        {
            this.pathOfPoints.Add(Point3D.ZeroPoint);
        }
               
        public void AddPoint(Point3D point)
        {
            this.pathOfPoints.Add(point);
        }
               
        public void AddPoint(int x, int y, int z)
        {
            this.pathOfPoints.Add(new Point3D(x, y, z));
        }

        public void Clear()
        {
            this.pathOfPoints.Clear();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int pathIndex = 0;

            foreach (Point3D point in this.pathOfPoints)
            {
                sb.AppendFormat("Point {0} : {1}\r\n", pathIndex, point.ToString());

                pathIndex++;
            }
            return sb.ToString();
        }

    }
}

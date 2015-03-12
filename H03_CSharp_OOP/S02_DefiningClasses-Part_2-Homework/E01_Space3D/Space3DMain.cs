namespace E01_Space3D
{
    using System;

    public class Space3DMain
    {
        public static void Main(string[] args)
        {
            //test Point3D
            Console.WriteLine("Test \"Point3D\"");
            Point3D p1 = new Point3D();
            p1 = Point3D.ZeroPoint;

            Console.WriteLine(p1);            

            p1.X = 3;
            p1.Y = 9;
            Console.WriteLine(p1.ToString());
            Console.WriteLine();
                       
            //test Distance3D
            Console.WriteLine("Test \"Distance3D\"");
            Console.WriteLine("p1 -> {0}", p1);
            Console.WriteLine("ZeroPoint -> {0}", Point3D.ZeroPoint);
            Console.Write("Distance between p1 and ZeroPoint => ");
            Console.WriteLine(Distance3D.Calculate(p1, Point3D.ZeroPoint));

            Point3D p2 = new Point3D(4, 6, 2);
            Console.WriteLine("p2 = {0}", p2);
            Console.Write("Distance between p1 and p2 => ");
            Console.WriteLine(Distance3D.Calculate(p1, p2));
            Console.WriteLine();

            //test Path
            Console.WriteLine("Test \"Path\"");
            var pathArray = new Path[3];
            Random randomGenerator = new Random();

            for (int index = 0; index < pathArray.Length; index++)
            {
                pathArray[index] = new Path();

                for (int i = 0; i < 5; i++)
                {
                    Point3D point = new Point3D(randomGenerator.Next(100) + 1, 
                        randomGenerator.Next(100) + 1, randomGenerator.Next(100) + 1);
                    pathArray[index].AddPoint(point);
                }
            }

            Console.WriteLine("The new Path was created !");
            Console.WriteLine();

            //test PathStorage
            Console.WriteLine("Test \"PathStorage\"");
            PathStorage.Clear();

            for (int index = 0; index < pathArray.Length; index++)
            {
                PathStorage.SavePathToFile(pathArray[index]);
            }

            var pathList = PathStorage.GetPathList();

            foreach (var path in pathList)
            {
                Console.WriteLine("New Path:");
                Console.WriteLine(path);
            }

            Console.WriteLine();
        }
    }
}

namespace E01_Space3D
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    // 04. Path
    // Create a static class PathStorage with static methods to save and 
    // load paths from a text file. Use a file format of your choice.
    public static class PathStorage
    {
        public static void SavePathToFile(Path pathOfPoints)
        {
            StreamWriter writer = new StreamWriter("../../pathList.txt", true);
            using (writer)
            {
                writer.WriteLine("New Path:");
                writer.Write(pathOfPoints);
                writer.WriteLine("\r\n");
            }
        }

        public static void Clear()
        {
            StreamWriter clear = new StreamWriter("../../pathList.txt", false);
            using (clear)
            {
            }
        }

        public static List<Path> GetPathList()
        {
            List<Path> pathList = new List<Path>();
            StreamReader reader = new StreamReader("../../pathList.txt");

            using (reader)
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (line == "New Path:")
                    {
                        line = reader.ReadLine();
                        Path path = new Path();

                        while (!String.IsNullOrEmpty(line))
                        {
                            line = line.Substring(line.IndexOf(":") + 1);
                            char[] separators = new char[] { ',', ' ', '=', 'X', 'Y', 'Z' };

                            int[] coords = line.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();

                            path.AddPoint(coords[0], coords[1], coords[2]);

                            line = reader.ReadLine();
                        }

                        pathList.Add(path);
                    }

                    line = reader.ReadLine();
                }
            }

            return pathList;
        }
    }
}
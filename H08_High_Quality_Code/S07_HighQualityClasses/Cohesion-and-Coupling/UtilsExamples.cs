namespace CohesionAndCoupling
{
    using System;

    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine("UtilsFile.GetFileExtension");
            Console.WriteLine("example -> {0}", 
                UtilsFile.GetFileExtension("example"));
            Console.WriteLine("example.pdf -> {0}", 
                UtilsFile.GetFileExtension("example.pdf"));
            Console.WriteLine("example.new.pdf -> {0}", 
                UtilsFile.GetFileExtension("example.new.pdf"));

            Console.WriteLine("UtilsFile.GetFileNameWithoutExtension");
            Console.WriteLine("example -> {0}", 
                UtilsFile.GetFileNameWithoutExtension("example"));
            Console.WriteLine("example.pdf -> {0}", 
                UtilsFile.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine("example.new.pdf -> {0}", 
                UtilsFile.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine("Distance in the 2D space = {0:f2}",
                Utils2D.CalculateDistance(1, -2, 3, 4));
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Utils3D.CalculateDistance(5, 2, -1, 3, -6, 4));
                                   
            double width = 3;
            double height = 4;
            double depth = 5;

            Console.WriteLine("Volume in 3D = {0:f2}", 
                Utils3D.CalculateVolume(width, height, depth));
            Console.WriteLine("Diagonal in 3D = {0:f2}", 
                Utils3D.CalculateDiagonal(width, height, depth));

            Console.WriteLine("Diagonal (XY) in 2D = {0:f2}", 
                Utils2D.CalculateDiagonal(width, height));
            Console.WriteLine("Diagonal (XZ) in 2D = {0:f2}", 
                Utils2D.CalculateDiagonal(height, depth));
            Console.WriteLine("Diagonal (YZ) in 2D = {0:f2}", 
                Utils2D.CalculateDiagonal(width, depth));

            Console.WriteLine("Volume in 3D = {0}", Utils3D.CalculateVolume(403005430.43246622, 
                205001130.865776, 4001760.12988456));
        }
    }
}

namespace E02_MethodPrintStatisticsInCSharp
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            // Refactor the following code to apply variable usage and naming best practices:

            //            public void PrintStatistics(double[] arr, int count)
            //{
            //    double max, tmp;
            //    for (int i = 0; i < count; i++)
            //    {
            //        if (arr[i] > max)
            //        {
            //            max = arr[i];
            //        }
            //    }
            //    PrintMax(max);
            //    tmp = 0;
            //    max = 0;
            //    for (int i = 0; i < count; i++)
            //    {
            //        if (arr[i] < max)
            //        {
            //            max = arr[i];
            //        }
            //    }
            //    PrintMin(max);

            //    tmp = 0;
            //    for (int i = 0; i < count; i++)
            //    {
            //        tmp += arr[i];
            //    }
            //    PrintAvg(tmp/count);
            //}

        }


        public static void PrintStatistics(double[] array)
        {
            Console.WriteLine("The max value is: {0}", GetMaxValue(array));

            Console.WriteLine("The average value is: {0}", GetAverageValue(array));

            Console.WriteLine("The min value is: {0}", GetMinValue(array));
        }

        private static double GetMaxValue(double[] array)
        {
            double maxValue = double.MinValue;

            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] > maxValue)
                {
                    maxValue = array[index];
                }
            }

            return maxValue;
        }

        private static double GetMinValue(double[] array)
        {
            double minValue = double.MaxValue;

            for (int index = 0; index < array.Length; index++)
            {
                if (array[index] < minValue)
                {
                    minValue = array[index];
                }
            }

            return minValue;
        }

        private static double GetAverageValue(double[] array)
        {
            double averageValue = 0;
            double sum = 0;

            for (int index = 0; index < array.Length; index++)
            {
                sum += array[index];
            }

            averageValue = sum / array.Length;

            return averageValue;
        }
    }
}

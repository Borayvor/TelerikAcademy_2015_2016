namespace SqrtLogSin
{
    using System;
    using System.Diagnostics;

    public static class SqrtMethod
    {
        public static void Float(float startValue, float endValue, float stepValue)
        {
            double result = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(float value = startValue; value <= endValue; value = value + stepValue)
            {
                Math.Sqrt((double)value);
                //result = (double)value;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> SqrtMethod(Float)", stopwatch.Elapsed);
        }

        public static void Decimal(decimal startValue, decimal endValue, decimal stepValue)
        {
            double result = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(decimal value = startValue; value <= endValue; value = value + stepValue)
            {
                Math.Sqrt((double)value);
                //result = (double)value;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> SqrtMethod(Decimal)", stopwatch.Elapsed);
        }

        public static void Double(double startValue, double endValue, double stepValue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(double value = startValue; value <= endValue; value = value + stepValue)
            {
                Math.Sqrt(value);
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> SqrtMethod(Double)", stopwatch.Elapsed);
        }
    }
}

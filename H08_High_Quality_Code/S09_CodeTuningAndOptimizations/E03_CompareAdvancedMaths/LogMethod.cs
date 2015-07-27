namespace SqrtLogSin
{
    using System;
    using System.Diagnostics;

    public static class LogMethod
    {
        public static void Float(float startValue, float endValue, float stepValue)
        {
            double result = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(float value = startValue; value <= endValue; value = value + stepValue)
            {
                Math.Log((double)value);
                //result = (double)value;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> LogMethod(Float)", stopwatch.Elapsed);
        }

        public static void Decimal(decimal startValue, decimal endValue, decimal stepValue)
        {
            double result = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(decimal value = startValue; value <= endValue; value = value + stepValue)
            {
                Math.Log((double)value);
                //result = (double)value;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> LogMethod(Decimal)", stopwatch.Elapsed);
        }

        public static void Double(double startValue, double endValue, double stepValue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(double value = startValue; value <= endValue; value = value + stepValue)
            {
                Math.Log(value);
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> LogMethod(Double)", stopwatch.Elapsed);
        }
    }
}

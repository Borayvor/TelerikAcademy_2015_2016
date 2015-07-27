namespace AddSubtractIncrementMultiplyDivide
{
    using System;
    using System.Diagnostics;

    public static class DivideMethod
    {
        public static void Int(int startValue, int endValue, int divisor)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(int result = startValue; result >= endValue; )
            {
                result = result / divisor;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> DivideMethod(Int)", stopwatch.Elapsed);
        }

        public static void Long(long startValue, long endValue, long divisor)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(long result = startValue; result >= endValue; )
            {
                result = result / divisor;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> DivideMethod(Long)", stopwatch.Elapsed);
        }

        public static void Float(float startValue, float endValue, float divisor)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(float result = startValue; result >= endValue; )
            {
                result = result / divisor;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> DivideMethod(Float)", stopwatch.Elapsed);
        }

        public static void Double(double startValue, double endValue, double divisor)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(double result = startValue; result >= endValue; )
            {
                result = result / divisor;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> DivideMethod(Double)", stopwatch.Elapsed);
        }

        public static void Decimal(decimal startValue, decimal endValue, decimal divisor)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(decimal result = startValue; result >= endValue; )
            {
                result = result / divisor;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> DivideMethod(Decimal)", stopwatch.Elapsed);
        }

    }
}

namespace AddSubtractIncrementMultiplyDivide
{
    using System;
    using System.Diagnostics;

    public static class AddMethod
    {
        public static void Int(int startValue, int endValue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(int result = startValue; result < endValue; )
            {
                result++;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> AddMethod(Int)", stopwatch.Elapsed);
        }

        public static void Long(long startValue, long endValue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(long result = startValue; result < endValue; )
            {
                result++;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> AddMethod(Long)", stopwatch.Elapsed);
        }

        public static void Float(float startValue, float endValue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(float result = startValue; result < endValue; )
            {
                result++;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> AddMethod(Float)", stopwatch.Elapsed);
        }

        public static void Double(double startValue, double endValue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(double result = startValue; result < endValue; )
            {
                result++;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> AddMethod(Double)", stopwatch.Elapsed);
        }

        public static void Decimal(decimal startValue, decimal endValue)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(decimal result = startValue; result < endValue; )
            {
                result++;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> AddMethod(Decimal)", stopwatch.Elapsed);
        }

    }
}

namespace AddSubtractIncrementMultiplyDivide
{
    using System;
    using System.Diagnostics;

    public static class MultiplyMethod
    {
        public static void Int(int startValue, int endValue, int multiplier)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(int result = startValue; result <= endValue; )
            {
                result = result * multiplier;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> MultiplyMethod(Int)", stopwatch.Elapsed);
        }

        public static void Long(long startValue, long endValue, long multiplier)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(long result = startValue; result <= endValue; )
            {
                result = result * multiplier;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> MultiplyMethod(Long)", stopwatch.Elapsed);
        }

        public static void Float(float startValue, float endValue, float multiplier)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(float result = startValue; result <= endValue; )
            {
                result = result * multiplier;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> MultiplyMethod(Float)", stopwatch.Elapsed);
        }

        public static void Double(double startValue, double endValue, double multiplier)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(double result = startValue; result <= endValue; )
            {
                result = result * multiplier;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> MultiplyMethod(Double)", stopwatch.Elapsed);
        }

        public static void Decimal(decimal startValue, decimal endValue, decimal multiplier)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for(decimal result = startValue; result <= endValue; )
            {
                result = result * multiplier;
            }

            stopwatch.Stop();
            Console.WriteLine("Time elapsed: {0} --> MultiplyMethod(Decimal)", stopwatch.Elapsed);
        }

    }
}

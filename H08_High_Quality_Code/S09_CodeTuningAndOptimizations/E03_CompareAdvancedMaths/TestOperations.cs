namespace SqrtLogSin
{
    using System;

    public class TestOperations
    {
        public static void Main(string[] args)
        {
            Console.WriteLine();

            SqrtMethod.Double(2, 10000, 0.002);
            SqrtMethod.Decimal(2m, 10000m, 0.002m);
            SqrtMethod.Float(2f, 10000f, 0.002f);
            Console.WriteLine();


            LogMethod.Double(2, 10000, 0.002);
            LogMethod.Decimal(2m, 10000m, 0.002m);
            LogMethod.Float(2f, 10000f, 0.002f);
            Console.WriteLine();


            SinusMethod.Double(2, 10000, 0.002);
            SinusMethod.Decimal(2m, 10000m, 0.002m);
            SinusMethod.Float(2f, 10000f, 0.002f);
            Console.WriteLine();
        }
    }
}

namespace AddSubtractIncrementMultiplyDivide
{
    using System;

    public class TestOperations
    {
        public static void Main(string[] args)
        {
            Console.WriteLine();

            AddMethod.Decimal(-500000, 500000);
            AddMethod.Double(-500000, 500000);
            AddMethod.Float(-500000, 500000);
            AddMethod.Int(-500000, 500000);
            AddMethod.Long(-500000, 500000);
            Console.WriteLine();

            SubstractMethod.Decimal(500000, -500000);
            SubstractMethod.Double(500000, -500000);
            SubstractMethod.Float(500000, -500000);
            SubstractMethod.Int(500000, -500000);
            SubstractMethod.Long(500000, -500000);
            Console.WriteLine();

            MultiplyMethod.Decimal(2, 5000000, 2);
            MultiplyMethod.Double(2, 5000000, 2);
            MultiplyMethod.Float(2, 5000000, 2);
            MultiplyMethod.Int(2, 5000000, 2);
            MultiplyMethod.Long(2, 5000000, 2);
            Console.WriteLine();

            DivideMethod.Decimal(5000000, 4, 2);
            DivideMethod.Double(5000000, 4, 2);
            DivideMethod.Float(5000000, 4, 2);
            DivideMethod.Int(5000000, 4, 2);
            DivideMethod.Long(5000000, 4, 2);
            Console.WriteLine();
        }
    }
}

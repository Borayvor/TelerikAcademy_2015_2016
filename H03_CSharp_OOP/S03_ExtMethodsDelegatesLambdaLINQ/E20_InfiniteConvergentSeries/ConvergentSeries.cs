namespace E20_InfiniteConvergentSeries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    public class ConvergentSeries
    {
        public delegate decimal SumInfiniteConvergentSeries(decimal precision);

        public static decimal Calculate(decimal precision,
            SumInfiniteConvergentSeries _delegate)
        {            
            return _delegate(precision);
        }

        public static BigInteger Factorial(uint number)
        {
            BigInteger result = 1;

            for (uint i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }

        public static BigInteger TwoToPower(uint number)
        {
            BigInteger result = 1;

            for (uint i = 0; i < number; i++)
            {
                result *= 2;
            }

            return result;
        }

       
    }
}

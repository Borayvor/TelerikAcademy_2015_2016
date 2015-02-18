namespace E07_ArithmeticalExpressions
{
    using System;

    public class ArithmeticalExpressions
    {
        public static void Main(string[] args)
        {
            // Write a program that calculates the value of 
            // given arithmetical expression.
            // The expression can contain the following elements only:
            // Real numbers, e.g. 5, 18.33, 3.14159, 12.6
            // Arithmetic operators: +, -, *, / (standard priorities)
            // Mathematical functions: ln(x), sqrt(x), pow(x,y)
            // Brackets (for changing the default priorities): (, )
            // Examples:
            // input 	                                                output
            // (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) 	                ~10.6
            // pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) 	    ~21.22
            // 
            // Hint: Use the classical Shunting-yard algorithm and 
            // Reverse Polish notation.

            Console.WriteLine("Please, enter an arithmetical expression !");
            string arithmeticalExpression = Console.ReadLine().Trim();

            string result = ArithmeticExpression.Calculate(arithmeticalExpression);

            Console.WriteLine("Result = {0}", result);  
        }
    }
}

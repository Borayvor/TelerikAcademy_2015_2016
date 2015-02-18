namespace E07_ArithmeticalExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public class ArithmeticExpression
    {
        private static readonly string[] operators = { "+", "-", "*", "/" };

        private static Queue<string> queue = new Queue<string>();

        private static Stack<string> stack = new Stack<string>();

        public static string Calculate(string arithmeticalExpression)
        {
            string result = string.Empty;

            ShuntingYardAlgorithm(arithmeticalExpression);

            result = ReversePolishNotation();

            return result;
        }

        private static string ReversePolishNotation()
        {
            string result = string.Empty;
            double operFirst = 0.0, operSecond = 0.0;

            double number = 0;

            foreach (var item in queue)
            {
                if (double.TryParse(item, out number))
                {
                    stack.Push(item);
                }
                else if (item == operators[0])
                {
                    if (stack.Count >= 2)
                    {
                        operSecond = double.Parse(stack.Pop());
                        operFirst = double.Parse(stack.Pop());

                        stack.Push((operFirst + operSecond).ToString());
                    }
                    else
                    {
                        throw new ArgumentException("Not enough input values in expression !");
                    }
                }
                else if (item == operators[1])
                {
                    if (stack.Count >= 2)
                    {
                        operSecond = double.Parse(stack.Pop());
                        operFirst = double.Parse(stack.Pop());

                        stack.Push((operFirst - operSecond).ToString());
                    }
                    else
                    {
                        throw new ArgumentException("Not enough input values in expression !");
                    }
                }
                else if (item == operators[2])
                {
                    if (stack.Count >= 2)
                    {
                        operSecond = double.Parse(stack.Pop());
                        operFirst = double.Parse(stack.Pop());

                        stack.Push((operFirst * operSecond).ToString());
                    }
                    else
                    {
                        throw new ArgumentException("Not enough input values in expression !");
                    }
                }
                else if (item == operators[3])
                {
                    if (stack.Count >= 2)
                    {
                        operSecond = double.Parse(stack.Pop());
                        operFirst = double.Parse(stack.Pop());

                        stack.Push((operFirst / operSecond).ToString());
                    }
                    else
                    {
                        throw new ArgumentException("Not enough input values in expression !");
                    }
                }
                else if (item == FunctionsNames.pow.ToString())
                {
                    if (stack.Count >= 2)
                    {
                        operSecond = double.Parse(stack.Pop());
                        operFirst = double.Parse(stack.Pop());

                        stack.Push(Math.Pow(operFirst, operSecond).ToString());
                    }
                    else
                    {
                        throw new ArgumentException("Not enough input values in expression !");
                    }
                }
                else if (item == FunctionsNames.sqrt.ToString())
                {
                    if (stack.Count >= 1)
                    {
                        operFirst = double.Parse(stack.Pop());

                        stack.Push(Math.Sqrt(operFirst).ToString());
                    }
                    else
                    {
                        throw new ArgumentException("Not enough input values in expression !");
                    }
                }
                else if (item == FunctionsNames.sin.ToString())
                {
                    if (stack.Count >= 1)
                    {
                        operFirst = double.Parse(stack.Pop());

                        stack.Push(Math.Sin(operFirst).ToString());
                    }
                    else
                    {
                        throw new ArgumentException("Not enough input values in expression !");
                    }
                }
                else if (item == FunctionsNames.cos.ToString())
                {
                    if (stack.Count >= 1)
                    {
                        operFirst = double.Parse(stack.Pop());

                        stack.Push(Math.Cos(operFirst).ToString());
                    }
                    else
                    {
                        throw new ArgumentException("Not enough input values in expression !");
                    }
                }
                else if (item == FunctionsNames.tan.ToString())
                {
                    if (stack.Count >= 1)
                    {
                        operFirst = double.Parse(stack.Pop());

                        stack.Push(Math.Tan(operFirst).ToString());
                    }
                    else
                    {
                        throw new ArgumentException("Not enough input values in expression !");
                    }
                }
                else if (item == FunctionsNames.ln.ToString())
                {
                    if (stack.Count >= 1)
                    {
                        operFirst = double.Parse(stack.Pop());

                        stack.Push(Math.Log(operFirst).ToString());
                    }
                    else
                    {
                        throw new ArgumentException("Not enough input values in expression !");
                    }
                }
            }

            if (stack.Count == 1)
            {
                // That value is the result of the calculation.
                result = double.Parse(stack.Pop())
                    .ToString("F2", CultureInfo.InvariantCulture);
            }
            else
            {
                // If there are more values in the stack
                // (Error) The user input too many values.
                throw new ArgumentException("The user input too many values in expression !");
            }

            return result;
        }

        private static void ShuntingYardAlgorithm(string ArithmeticExpression)
        {
            string[] members = SplitArithmeticalExpression(ArithmeticExpression);

            string tempValue;

            for (int index = 0; index < members.Length; index++)
            {
                double doubleNumber = 0;

                if (members[index] == string.Empty)
                {
                    continue;
                }

                if (double.TryParse(members[index], out doubleNumber))
                {
                    queue.Enqueue(Convert.ToString(doubleNumber));
                }
                else if (IsFunction(members[index]))
                {
                    stack.Push(members[index]);
                }
                else if (members[index] == ",")
                {
                    if (stack.Contains("(") && stack.Count != 0)
                    {
                        while (stack.Peek() != "(")
                        {
                            tempValue = stack.Pop();
                            queue.Enqueue(tempValue);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Separator ',' was misplaced " +
                            "or parentheses () were mismatched !");
                    }
                }
                else if (IsOperator(members[index]))
                {
                    while (IsTheCorrectOperator(members[index]) && stack.Count != 0)
                    {
                        tempValue = stack.Pop();
                        queue.Enqueue(tempValue);
                    }

                    stack.Push(members[index]);
                }
                else if (members[index] == "(")
                {
                    stack.Push("(");
                }
                else if (members[index] == ")")
                {
                    if (stack.Contains("(") && stack.Count != 0)
                    {
                        while ((stack.Count != 0) && 
                            (stack.Peek() != "("))
                        {
                            tempValue = stack.Pop();
                            queue.Enqueue(tempValue);
                        }

                        if (stack.Count != 0)
                        {
                            tempValue = stack.Pop();
                        }
                        
                        while ((stack.Count != 0) &&
                            (stack.Peek() == "ln" ||
                            stack.Peek() == "sqrt" ||
                            stack.Peek() == "pow" ||
                            stack.Peek() == "sin" ||
                            stack.Peek() == "cos" ||
                            stack.Peek() == "tan"))
                        {
                            tempValue = stack.Pop();
                            queue.Enqueue(tempValue);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Parentheses () were mismatched !");
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid input ! Missing right bracket ')' !");
                }
            }

            while (stack.Count != 0)
            {
                if (stack.Peek() == "(" || stack.Peek() == ")")
                {
                    throw new ArgumentException("Parentheses () were mismatched !");
                }
                else
                {
                    tempValue = stack.Pop();
                    queue.Enqueue(tempValue);
                }
            }

        }

        private static int GetPriority(string arithmeticOperator)
        {
            if (arithmeticOperator == "+" || arithmeticOperator == "-")
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        private static bool IsFunction(string member)
        {
            bool stringIsFunctions = false;

            if (Enum.IsDefined(typeof(FunctionsNames), member.ToLower()))
            {
                stringIsFunctions = true;
            }

            return stringIsFunctions;
        }

        private static bool IsOperator(string member)
        {
            bool stringIsOperator = false;

            for (int index = 0; index < operators.Length; index++)
            {
                if (operators[index] == member.ToLower())
                {
                    stringIsOperator = true;
                }
            }

            return stringIsOperator;
        }

        private static string[] SplitArithmeticalExpression(string arithmeticalExpression)
        {
            arithmeticalExpression = arithmeticalExpression.ToLower();

            StringBuilder arithmeticalExpressionTemp = new StringBuilder();


            for (int index = 0; index < arithmeticalExpression.Length; index++)
            {
                if (arithmeticalExpression[index] == '(' || arithmeticalExpression[index] == ')' ||
                    arithmeticalExpression[index] == '+' || arithmeticalExpression[index] == '-' ||
                    arithmeticalExpression[index] == '*' || arithmeticalExpression[index] == '/' ||
                    arithmeticalExpression[index] == ',')
                {
                    arithmeticalExpressionTemp.Append(' ');

                    arithmeticalExpressionTemp.Append(arithmeticalExpression[index]);

                    if (arithmeticalExpression[index] != '-')
                    {
                        arithmeticalExpressionTemp.Append(' ');
                    }
                }
                else
                {
                    arithmeticalExpressionTemp.Append(arithmeticalExpression[index]);
                }
            }

            string arithmeticalExpressionNew = Convert.ToString(arithmeticalExpressionTemp);

            string[] members = arithmeticalExpressionNew
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return members;
        }

        private static bool IsTheCorrectOperator(string member)
        {
            if (stack.Count == 0)
            {
                return false;
            }

            string currentOperator = stack.Peek().ToString();

            int firstOperatorPriority = GetPriority(member);

            int secondOperatorPriority = GetPriority(currentOperator);

            bool isTrue = (IsOperator(currentOperator)) &&
                (firstOperatorPriority <= secondOperatorPriority);

            return isTrue;
        }
    }
}

namespace E01_BasicBASIC
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;

    public class BasicBASIC
    {
        const string RUN = "RUN";
        const string IF = "IF";
        const string THEN = "THEN";
        const string PRINT = "PRINT";
        const string GOTO = "GOTO";
        const string CLS = "CLS";
        const string STOP = "STOP";
        const char assign = '=';
        const char addition = '+';
        const char subtraction = '-';
        const char bigger = '>';
        const char smaller = '<';

        static Dictionary<string, int> variables = new Dictionary<string, int>();
        static List<string> code = new List<string>();
        static StringBuilder output = new StringBuilder();

        static int rowNumber = int.MinValue;
        static int indexCommands = 0;      

        public static void Main(string[] args)
        {
            variables.Add("V", 0);
            variables.Add("W", 0);
            variables.Add("X", 0);
            variables.Add("Y", 0);
            variables.Add("Z", 0);

            //StreamReader reader = new StreamReader("../../text.txt");
            //Console.SetIn(reader);
            
            string whitespaces = @"\s+";

            while (true)
            {
                string codeLine = Console.ReadLine().Trim();

                if (codeLine == RUN)
                {
                    break;
                }

                codeLine = Regex.Replace(codeLine, whitespaces, "");
                code.Add(codeLine);
            }

            for (; indexCommands < code.Count; indexCommands++)
            {
                var row = code[indexCommands];
                AllCommands(row);
            }

            Console.WriteLine(output.ToString().Trim());
        }

        private static void AllCommands(string row)
        {  
            if (row.Contains(STOP))
            {
                indexCommands = code.Count;
            }
            else if (row.Contains(IF))
            {
                CommandIF(row);
            }
            else if (row.Contains(PRINT))
            {
                CommandPRINT(row);
            }
            else if (row.Contains(CLS))
            {
                CommandCLS(row);
            }
            else if (row.Contains(GOTO))
            {
                CommandGOTO(row);
            }
            else
            {
                Calculate(row);
            }
        }

        private static void Calculate(string row)
        {
            int x = 0;
            int y = 0;

            string[] expression = row
                .Split(new char[] { assign })
                .ToArray();

            string[] arithmeticOperation = expression[1]
                    .Split(new char[] { addition, subtraction })
                    .ToArray();

            if (expression[1].Length > 2)
            {
                if (!string.IsNullOrWhiteSpace(arithmeticOperation[0]) &&
                !string.IsNullOrWhiteSpace(arithmeticOperation[1]))
                {
                    if (expression[1].Contains(addition))
                    {
                        x = GetVariable(arithmeticOperation[0]);
                        y = GetVariable(arithmeticOperation[1]);

                        variables[expression[0].Substring(expression[0].Length - 1)] = (x + y);
                    }
                    else if (expression[1].Contains(subtraction))
                    {
                        x = GetVariable(arithmeticOperation[0]);
                        y = GetVariable(arithmeticOperation[1]);

                        variables[expression[0].Substring(expression[0].Length - 1)] = (x - y);
                    }
                }
            }
            else
            {
                x = GetVariable(expression[1]);
                variables[expression[0].Substring(expression[0].Length - 1)] = x;
            }
        }

        private static void CommandGOTO(string row)
        {
            int start = row.IndexOf(GOTO) + GOTO.Length;
            string str = row.Substring(start);
            int variable = 0;

            variable = GetVariable(str);

            rowNumber = variable;

            for (int j = 0; j < code.Count; j++)
            {
                if (code[j].StartsWith(rowNumber.ToString()))
                {
                    indexCommands = (j - 1);
                    rowNumber = int.MinValue;
                    break;
                }
            }
        }

        private static void CommandCLS(string row)
        {
            output.Clear();
        }

        private static void CommandPRINT(string row)
        {
            int start = row.IndexOf(PRINT) + PRINT.Length;
            string str = row.Substring(start);
            int variable = 0;

            variable = GetVariable(str);
            output.AppendLine(variable.ToString());
        }

        private static void CommandIF(string row)
        {
            int start = row.IndexOf(IF) + IF.Length;
            int end = row.IndexOf(THEN);
            int x = 0;
            int y = 0;
            bool conditionIF = false;

            string[] condition = row.Substring(start, end - start)
                .Split(new char[] { assign, bigger, smaller }
                .ToArray());

            x = GetVariable(condition[0]);
            y = GetVariable(condition[1]);

            if (row.Contains(bigger))
            {
                conditionIF = (x > y);
            }

            if (row.Contains(smaller))
            {
                conditionIF = (x < y);
            }

            if (row.Contains(assign))
            {
                conditionIF = (x == y);
            }

            if (conditionIF)
            {
                string str = row.Substring(end + THEN.Length);

                AllCommands(str);
            }
        }

        private static int GetVariable(string str)
        {
            int variable = 0;

            if (variables.ContainsKey(str))
            {
                variable = variables[str];
            }
            else
            {
                variable = int.Parse(str);
            }

            return variable;
        }
    }
}

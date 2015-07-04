namespace E01_CodeDocumentation
{
    using System;

    /// <summary>
    /// Main class of the program
    /// </summary>
    public class ProgramEntryPoint
    {
        /// <summary>
        /// Main method
        /// </summary>
        public static void Main()
        {
            string str = "42";

            int strAsInt = str.ToInteger();

            Console.WriteLine("str + 2 = {0}", str + 2);
            Console.WriteLine("strAsInt + 2 = {0}", strAsInt + 2);
        }
    }
}

namespace E03_ReadFileContents
{
    using System;
    using System.IO;
    using System.Security;

    public class ReadFileContents
    {
        public static void Main(string[] args)
        {
            // Write a program that enters file name along with its 
            // full file path (e.g. C:\WINDOWS\win.ini), reads its 
            // contents and prints it on the console.
            //Find in MSDN how to use System.IO.File.ReadAllText(…).
            //Be sure to catch all possible exceptions and print 
            // user-friendly error messages.

            Console.Write("Enter the full name and path of file:");
            try
            {
                Console.WriteLine(System.IO.File.ReadAllText(Console.ReadLine()));
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Console.WriteLine(dnfe.Message);
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine(ane.Message);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (PathTooLongException ptle)
            {
                Console.WriteLine(ptle.Message);
            }
            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine(uae.Message);
            }
            catch (SecurityException se)
            {
                Console.WriteLine(se.Message);
            }
            catch (NotSupportedException nse)
            {
                Console.WriteLine(nse.Message);
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
    }
}

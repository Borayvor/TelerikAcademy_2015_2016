namespace E25_ExtractTextFromHTML
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class ExtractTextFromHTML
    {
        public static void Main(string[] args)
        {
            // Write a program that extracts from given HTML file its 
            // title (if available), and its body text without the HTML tags.
            // Example input:
            // <html>
            //   <head>
            //      <title>News</title>
            //  </head>
            //   <body>
            //      <p><a href="http://academy.telerik.com">Telerik
            //     Academy</a>aims to provide free real-world practical
            //     training for young people who want to turn into
            //     skilful .NET software engineers.</p>
            //   </body>
            // </html>
            // Output:
            // Title: News
            // Text: Telerik Academy aims to provide free real-world 
            // practical training for young people who want to turn 
            // into skilful .NET software engineers.

            StreamReader reader = new StreamReader("..\\..\\htmlText.txt");
                        
            string htmlText = reader.ReadToEnd();

            Console.WriteLine(htmlText);
            Console.WriteLine();
            Console.WriteLine("Result:");

            var pattern = "(?<=>).*?(?=<)"; 
            var matches = Regex.Matches(htmlText, pattern);
                        
            foreach (Match text in matches)
            {
                if (!String.IsNullOrWhiteSpace(text.Value))
                {
                    Console.WriteLine(text);
                }
            }
        }
    }
}

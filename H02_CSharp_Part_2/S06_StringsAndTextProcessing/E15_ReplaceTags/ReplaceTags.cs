namespace E15_ReplaceTags
{
    using System;
    using System.Text.RegularExpressions;

    public class ReplaceTags
    {
        public static void Main(string[] args)
        {
            // Write a program that replaces in a HTML document given 
            // as string all the tags <a href="…">…</a> with corresponding 
            // tags [URL=…]…/URL].
            // Example:
            // input:
            // <p>Please visit <a href="http://academy.telerik.com">our 
            // site</a> to choose a training course. Also visit <a 
            // href="www.devbg.org">our forum</a> to discuss the courses.</p>
            // output:
            // <p>Please visit [URL=http://academy.telerik. com]our site[/URL] to 
            // choose a training course. Also visit [URL=www.devbg.org]our 
            // forum[/URL] to discuss the courses.</p>

            string htmlText = "<p>Please visit <a href=\"http://academy.telerik.com\">our " +
                "site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our " +
                "forum</a> to discuss the courses.</p>";

            Console.WriteLine(htmlText);
            Console.WriteLine();
                        
            string tags = "<a href=\"(.*?)\">(.*?)</a>";
            string urlTags = "[URL=$1]$2[/URL]";

            string urlText = Regex.Replace(htmlText, tags, urlTags);

            Console.WriteLine(urlText);
        }
    }
}

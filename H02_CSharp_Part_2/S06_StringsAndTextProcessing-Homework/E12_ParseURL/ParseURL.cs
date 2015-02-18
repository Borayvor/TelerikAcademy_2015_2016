namespace E12_ParseURL
{
    using System;
    using System.Text.RegularExpressions;

    public class ParseURL
    {
        public static void Main(string[] args)
        {
            // Write a program that parses an URL address given in 
            // the format: [protocol]://[server]/[resource] and 
            // extracts from it the [protocol], [server] and [resource] elements.
            // Example:
            // URL 	
            // http://telerikacademy.com/Courses/Courses/Details/212
            // Information
            // [protocol] = http
            // [server] = telerikacademy.com
            // [resource] = /Courses/Courses/Details/212

            string url = "http://telerikacademy.com/Courses/Courses/Details/212";

            var fragments = Regex.Match(url, "(.*)://(.*?)(/.*)").Groups;

            Console.WriteLine("[protocol] = {0}", fragments[1]);
            Console.WriteLine("[server] = {0}", fragments[2]);
            Console.WriteLine("[resource] = {0}", fragments[3]);
        }
    }
}

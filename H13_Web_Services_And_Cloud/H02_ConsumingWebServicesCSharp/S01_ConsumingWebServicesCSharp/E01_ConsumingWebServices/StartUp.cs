namespace E01_ConsumingWebServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            const string UriString = "http://jsonplaceholder.typicode.com";

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(UriString);
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Start(httpClient);
        }

        private static void GetAlbums(HttpClient httpClient, string queryString, int count)
        {
            HttpResponseMessage albums = httpClient.GetAsync("albums").Result;

            if (albums.IsSuccessStatusCode)
            {
                var searchResult = albums.Content.ReadAsStringAsync().Result;
                var jsonResults = JsonConvert.DeserializeObject<List<Albums>>(searchResult);
                var page = jsonResults.Take(count);

                if (!string.IsNullOrWhiteSpace(queryString))
                {
                    page = jsonResults.Where(x => x.Title.Contains(queryString)).Take(count);
                }

                Console.WriteLine(
                    "Albums:" +
                    Environment.NewLine +
                    string.Join(Environment.NewLine, page));
            }
            else
            {
                throw new HttpRequestException(
                    string.Format(
                        "Get faild ! Statuse code: {0}. Reason: {1}",
                        (int)albums.StatusCode, albums.ReasonPhrase));
            }
        }

        private static void Start(HttpClient httpClient)
        {
            while (true)
            {
                int input;

                Console.WriteLine("Available commands are 1 = 'search', 2 = 'exit'");
                var isNumber = int.TryParse(Console.ReadLine(), out input);

                switch (input)
                {
                    case 1:
                        Search(httpClient);
                        break;

                    case 2:
                        return;

                    default:
                        Console.WriteLine("Invalid input !");
                        break;
                }
            }
        }

        private static void Search(HttpClient httpClient)
        {
            Console.Write("Please, enter a count of albums or press 'Enter': ");
            int count;
            bool isNumber = int.TryParse(Console.ReadLine(), out count);

            if (!isNumber)
            {
                count = 100;
            }

            Console.Write("Please, enter a query string or press 'Enter': ");
            string queryString = Console.ReadLine();

            GetAlbums(httpClient, queryString, count);
        }
    }
}

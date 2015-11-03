namespace MusicStoreSystem.ConsoleClient
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using Newtonsoft.Json.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var connection = new Uri("http://localhost:60824/");

            GetJsonAllSongs(connection, "api/Songs");

            GetXmlAllSongs(connection, "api/Songs");

            PostSong(connection, "api/Songs");

            UpdateSong(connection, "api/Songs", 2);

            DeleteSong(connection, "api/Songs", 2);

            Console.ReadLine();
        }

        private static void GetJsonAllSongs(Uri connection, string requestPath)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = connection;

                var response = client.GetAsync(requestPath).Result;

                Console.WriteLine(Environment.NewLine + "Songs Json: " + response.Content.ReadAsStringAsync().Result);
            }
        }

        private static void GetXmlAllSongs(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                var response = httpClient.GetAsync(requestPath).Result;

                Console.WriteLine(Environment.NewLine + "Songs Xml: " + response.Content.ReadAsStringAsync().Result);
            }
        }

        private static void PostSong(Uri connection, string requestPath)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var json = JObject.Parse("{\"Title\": \"Test Title\", \"AlbumId\":1}");

                var response = httpClient.PostAsync(
                    requestPath,
                    new StringContent(
                        json.ToString(),
                        Encoding.UTF8,
                        "application/json")).Result;

                Console.WriteLine(Environment.NewLine + "Added Song: " + response.Content.ReadAsStringAsync().Result);
            }
        }

        private static void UpdateSong(Uri connection, string requestPath, int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var json = JObject.Parse("{\"Title\": \"Turtle\", \"AlbumId\":1}");

                var response = httpClient.PutAsync(
                    requestPath + "/" + id,
                    new StringContent(
                        json.ToString(),
                        Encoding.UTF8,
                        "application/json")).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song with id: {0}, Updated !", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }

        private static void DeleteSong(Uri connection, string requestPath, int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = connection;

                var response = httpClient.DeleteAsync(requestPath + "/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Song with id: {0}, Deleted !", id);
                }
                else
                {
                    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                }
            }
        }
    }
}

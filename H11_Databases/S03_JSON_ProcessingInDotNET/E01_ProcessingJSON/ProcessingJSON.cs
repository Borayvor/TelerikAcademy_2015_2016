namespace E01_ProcessingJSON
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml;

    public class ProcessingJSON
    {
        public static void Main(string[] args)
        {
            string urlRss = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            string pathAndFileNameRssXml = "../../telerikAcademy.xml";
            string pathAndFileNameHTML = "../../telerikAcademy.html";

            DownloadContentRss(urlRss, pathAndFileNameRssXml);

            var xmlDoc = GetXml(pathAndFileNameRssXml);
            var jsonObj = ConvertXmlToJsonObject(xmlDoc);

            var videosTitles = GetVideosTitles(jsonObj);
            PrintTitles(videosTitles);
            Console.WriteLine();

            var videos = GetVideos(jsonObj);
            GenerateHtml(videos, pathAndFileNameHTML);
            Console.WriteLine();
        }

        public static void GenerateHtml(IEnumerable<Video> videos, string pathAndFileName)
        {
            StringBuilder html = new StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html>");
            html.AppendLine("<head>");
            html.AppendLine("<title>Telerik Academy Videos</title>");
            html.AppendLine("</head>");
            html.AppendLine("<body>");

            foreach (var video in videos)
            {
                html.AppendFormat("<div style=\"float:left; width: 320px; height: 350px; padding:10px; " +
                                  "margin:5px; background-color:lightgreen; border-radius:10px\">" +
                                  "<iframe width=\"320\" height=\"245\" " +
                                  "src=\"http://www.youtube.com/embed/{1}?autoplay=0\" " +
                                  "frameborder=\"0\" allowfullscreen></iframe>" +
                                  "<h3>{2}</h3><a href=\"{0}\">Go to YouTube</a></div>",
                                  video.Link.Href, video.Id, video.Title);
            }

            html.AppendLine("</body>");
            html.AppendLine("</html>");

            var htmlAsString = html.ToString();

            using (StreamWriter writer = new StreamWriter(pathAndFileName, 
                false, Encoding.UTF8))
            {
                writer.Write(htmlAsString);
            }
                        
            Console.WriteLine("telerikAcademy.html was generated !");
        }

        public static IEnumerable<Video> GetVideos(JObject jsonObj)
        {
            var videos = jsonObj["feed"]["entry"]
                .Select(entry => JsonConvert.DeserializeObject<Video>(entry.ToString()));

            return videos;
        }

        public static void PrintTitles(IEnumerable<JToken> titles)
        {
            Console.WriteLine("Titles of The Videos");
            Console.WriteLine("====================");
            Console.WriteLine(string.Join(Environment.NewLine, titles));
            Console.WriteLine("====================");
        }

        public static IEnumerable<JToken> GetVideosTitles(JObject jsonObj)
        {
            var titles = jsonObj["feed"]["entry"]
                .Select(entry => entry["title"]);

            return titles;
        }

        public static JObject ConvertXmlToJsonObject(XmlDocument xml)
        {
            var json = JsonConvert.SerializeXmlNode(xml);
            var jsonObj = JObject.Parse(json);

            return jsonObj;
        }

        public static XmlDocument GetXml(string pathAndFileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(pathAndFileName);

            return doc;
        }

        public static void DownloadContentRss(string url, string pathAndFileName)
        {
            WebClient myWebClient = new WebClient { Encoding = Encoding.UTF8 };

            using (myWebClient)
            {
                myWebClient.DownloadFile(url, pathAndFileName);
            }
        }
    }
}

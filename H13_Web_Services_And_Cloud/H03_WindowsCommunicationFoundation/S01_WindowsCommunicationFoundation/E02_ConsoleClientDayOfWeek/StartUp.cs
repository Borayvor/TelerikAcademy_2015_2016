namespace E02_ConsoleClientDayOfWeek
{
    using System;
    using System.Text;
    using GetDayBulService;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            GetDayServiceClient dayBul = new GetDayServiceClient();

            using (dayBul)
            {
                var day = dayBul.GetDateBul(DateTime.Now);

                Console.WriteLine(day);
            }
        }
    }
}

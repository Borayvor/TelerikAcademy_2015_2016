namespace E05_ConsoleClientIIS
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using E03_StringContainsService;
    using StringOccurrencesService;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var serviceAddress = new Uri("http://localhost:8733/strings");
            ServiceHost host = new ServiceHost(
                typeof(StringsService),
                serviceAddress);

            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            host.Open();
            Console.WriteLine("Running at " + serviceAddress);

            string text = "We are living in an yellow submarine. We don't have " +
                "anything else. Inside the submarine is very tight. " +
                "So we are drinking all the day. We will move out of it in 5 days.";

            string subText = @"in";

            StringsServiceClient client = new StringsServiceClient();

            using (client)
            {
                var result = client.GetNumberOfTimesSecondStringContainsFirstString(subText, text);

                Console.WriteLine("\"{0}\" is contained {1} times.", subText, result);
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}

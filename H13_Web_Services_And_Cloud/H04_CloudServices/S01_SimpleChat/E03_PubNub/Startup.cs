namespace E03_PubNub
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Process.Start("..\\..\\RecieverPage.html");

            System.Threading.Thread.Sleep(2000);

            PubnubAPI pubnub = new PubnubAPI(
                "pub-c-286d76c9-2fb5-4d8a-86b4-21998f115ff2",               // PUBLISH_KEY
                "sub-c-41fd8ef2-8d34-11e5-a7e4-0619f8945a4f",               // SUBSCRIBE_KEY
                "sec-c-ZmU5N2FkZGQtN2FjYi00YWMxLWFjY2MtMThiNjc2OGViZDJh",   // SECRET_KEY
                false);

            string channel = "PublishApp";

            // Publish a sample message to Pubnub
            List<object> publishResult = pubnub.Publish(channel, "Hello Pubnub!");
            Console.WriteLine(
                "Publish Success: " + publishResult[0].ToString() + "\n" +
                "Publish Info: " + publishResult[1]);

            // Show PubNub server time
            object serverTime = pubnub.Time();
            Console.WriteLine("Server Time: " + serverTime.ToString());

            // Subscribe for receiving messages (in a background task to avoid blocking)
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
                () =>
                pubnub.Subscribe(
                    channel,
                    delegate (object message)
                    {
                        Console.WriteLine("Received Message -> '" + message + "'");
                        return true;
                    }));

            t.Start();

            // Read messages from the console and publish them to Pubnub
            while (true)
            {
                Console.Write("Enter a message to be sent to Pubnub: ");

                string msg = Console.ReadLine();
                pubnub.Publish(channel, msg);

                Console.WriteLine("Message {0} sent.", msg);
            }
        }
    }
}

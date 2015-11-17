namespace E01_IronMQSender
{
    using System;
    using IronMQ;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Client client = new Client(
                GlobalConstants.ProjectId,
                GlobalConstants.Token);

            Queue queue = client.Queue(GlobalConstants.QueueName);

            Console.WriteLine("You can start entering messages:");

            while (true)
            {
                string msg = Console.ReadLine();
                queue.Push(msg);
                Console.WriteLine("Message sent to IronMQ server.");
            }
        }
    }
}

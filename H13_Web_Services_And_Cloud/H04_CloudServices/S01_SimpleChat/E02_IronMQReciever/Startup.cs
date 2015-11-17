namespace E02_IronMQReciever
{
    using System;
    using System.Threading;
    using E01_IronMQSender;
    using IronMQ;
    using IronMQ.Data;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Client client = new Client(
                GlobalConstants.ProjectId,
                GlobalConstants.Token);

            Queue queue = client.Queue(GlobalConstants.QueueName);

            Console.WriteLine("Listening for new messages from IronMQ server:");

            while (true)
            {
                Message msg = queue.Get();

                if (msg != null)
                {
                    Console.WriteLine(msg.Body);
                    queue.DeleteMessage(msg);
                }

                Thread.Sleep(100);
            }
        }
    }
}

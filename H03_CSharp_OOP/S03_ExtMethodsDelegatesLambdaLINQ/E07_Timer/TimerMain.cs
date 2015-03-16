namespace E07_Timer
{
    using System;
    using System.Threading;

    public class TimerMain
    {
        public static void Main(string[] args)
        {
            // Using delegates write a class Timer that can execute
            // certain method at each t seconds.

            int ticksCount = 10;
            int interval = 1000;

            ElapsedTime timerElapsedDelegate = new ElapsedTime(PrintElapsedTime);

            Timer timer = new Timer(ticksCount, interval, timerElapsedDelegate);

            Console.WriteLine("Timer started for {0} ticks, a tick " + 
                "occurring once every {1} second(s).", ticksCount, interval / 1000);

            Thread timerThread = new Thread(new ThreadStart(timer.Run));
            timerThread.Start();
        }


        static void PrintElapsedTime(int ticksLeft)
        {
            Console.WriteLine("Ticks left: {0}.", ticksLeft);
        }
    }
}

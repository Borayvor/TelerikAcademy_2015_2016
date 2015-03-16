namespace E07_Timer
{
    using System.Threading;

    public delegate void ElapsedTime(int ticksCount);

    public class Timer
    {
        private ElapsedTime callback;

        public Timer(int ticksCount, int interval, ElapsedTime callback)
        {
            this.TicksCount = ticksCount;
            this.Interval = interval;
            this.callback = callback;
        }

        public int TicksCount { get; private set; }
        public int Interval { get; private set; }        

        public void Run()
        {
            int tickCounter = this.TicksCount;

            while (tickCounter > 0)
            {
                Thread.Sleep(Interval);
                tickCounter--;
                this.callback(tickCounter);
            }
        }        
    }    
}

namespace E02_StudentsAndWorkers
{
    using E02_StudentsAndWorkers.AbstractClasses;

    public class Worker : Human
    {
        public Worker(string firstName, string lastName, decimal weekSalary, float workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary { get; private set; }

        public float WorkHoursPerDay { get; private set; }

        public decimal MoneyPerHour()
        {
            return (WeekSalary / (decimal)(WorkHoursPerDay * 5));
        }

        public override string Print()
        {
            return base.Print() + string.Format("Money per hour : {0:F2} $\r\n", 
                MoneyPerHour());
        }
    }
}

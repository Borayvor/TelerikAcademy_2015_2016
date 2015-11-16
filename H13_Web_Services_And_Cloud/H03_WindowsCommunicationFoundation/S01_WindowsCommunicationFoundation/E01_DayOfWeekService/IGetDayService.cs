namespace E01_DayOfWeekService
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IGetDayService
    {
        [OperationContract]
        string GetDateBul(DateTime date);
    }
}

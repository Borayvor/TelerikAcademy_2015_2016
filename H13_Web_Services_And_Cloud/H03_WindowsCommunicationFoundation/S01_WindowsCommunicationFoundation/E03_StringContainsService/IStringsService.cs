namespace E03_StringContainsService
{
    using System.ServiceModel;

    [ServiceContract]
    public interface IStringsService
    {
        [OperationContract]
        int GetNumberOfTimesSecondStringContainsFirstString(string first, string second);
    }
}

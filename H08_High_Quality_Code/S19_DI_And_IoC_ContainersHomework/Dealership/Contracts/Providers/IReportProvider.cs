namespace Dealership.Contracts.Providers
{
    using System.Collections.Generic;

    public interface IReportProvider
    {
        IEnumerable<string> GetReports(IEnumerable<IEnumerable<string>> commands);
    }
}

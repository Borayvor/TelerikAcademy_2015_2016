namespace SchoolSystem.Contracts
{
    /// <summary>
    /// Interface for creation of providers
    /// </summary>
    public interface IInterfaceProvider
    {
        /// <summary>
        /// Read input value.
        /// </summary>
        /// <returns>Value as string.</returns>
        string ReadLine();

        /// <summary>
        /// Write line as output.
        /// </summary>
        /// <param name="value">Output value as string.</param>
        void WriteLine(string value);
    }
}

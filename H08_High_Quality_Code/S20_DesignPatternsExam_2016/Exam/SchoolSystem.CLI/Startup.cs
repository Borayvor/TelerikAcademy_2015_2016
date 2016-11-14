namespace SchoolSystem.Cli
{
    using Framework.Core.Contracts;
    using Ninject;

    public class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new SchoolSystemModule());

            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
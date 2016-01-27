namespace E01_Cars
{
    using System.Collections.Generic;

    public class Producer
    {
        public string Name { get; set; }

        public IList<string> Models { get; set; }
    }
}
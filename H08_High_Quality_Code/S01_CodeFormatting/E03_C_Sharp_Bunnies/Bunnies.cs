namespace E03_C_Sharp_Bunnies
{
    using System.Collections.Generic;

    public class Bunnies
    {
        public static readonly List<Bunny> List = new List<Bunny>
            {
                new Bunny("Leonid", 1, FurType.NotFluffy),
                new Bunny("Rasputin", 2, FurType.ALittleFluffy),
                new Bunny("Tiberii", 3, FurType.ALittleFluffy),
                new Bunny("Neron", 1, FurType.ALittleFluffy),
                new Bunny("Klavdii", 3, FurType.Fluffy),
                new Bunny("Vespasian", 3, FurType.Fluffy),
                new Bunny("Domician", 4, FurType.FluffyToTheLimit),
                new Bunny("Tit", 2, FurType.FluffyToTheLimit),
            };
    }
}

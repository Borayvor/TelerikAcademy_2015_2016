namespace E01_ClassChefInCSharp
{
    using System.Collections.Generic;

    public class KitchenUtensils : List<Vegetable>
    {
        public KitchenUtensils(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}

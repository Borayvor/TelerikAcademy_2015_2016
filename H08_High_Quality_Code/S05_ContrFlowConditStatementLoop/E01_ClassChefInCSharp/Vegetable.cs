namespace E01_ClassChefInCSharp
{
    public class Vegetable
    {
        public Vegetable(Vegetable newVegetable)
        {
            this.Name = newVegetable.Name;
            this.IsRotten = newVegetable.IsRotten;
            this.IsPeeled = newVegetable.IsPeeled;
        }

        public Vegetable(string name, bool isRotten, bool isPeeled)
        {
            this.Name = name;
            this.IsRotten = isRotten;
            this.IsPeeled = isPeeled;
        }

        public string Name { get; private set; }

        public bool IsRotten { get; set; }

        public bool IsPeeled { get; set; }
    }
}

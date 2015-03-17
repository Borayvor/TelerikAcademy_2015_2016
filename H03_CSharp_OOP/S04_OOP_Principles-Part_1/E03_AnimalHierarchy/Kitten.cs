namespace E03_AnimalHierarchy
{
    using E03_AnimalHierarchy.Interfaces;

    public class Kitten : Cat, ISound
    {
        public Kitten(double age, string name)
            : base(age, name, 'F')
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

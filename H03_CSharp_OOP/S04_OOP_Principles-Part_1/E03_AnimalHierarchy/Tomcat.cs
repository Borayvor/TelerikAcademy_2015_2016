namespace E03_AnimalHierarchy
{
    using E03_AnimalHierarchy.Interfaces;

    public class Tomcat : Cat, ISound
    {
        public Tomcat(double age, string name)
            : base(age, name, 'M')
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

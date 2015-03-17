namespace E03_AnimalHierarchy
{  
    using E03_AnimalHierarchy.AbstractClasses;
    using E03_AnimalHierarchy.Interfaces;

    public class Cat : Animal, ISound
    {
        public Cat(double age, string name, char sex)
            : base(age, name, sex)
        {
        }

        public string Sound()
        {
            return "meow, meow !";
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" and say: {0}", Sound());
        }
    }
}

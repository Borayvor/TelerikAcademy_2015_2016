namespace E02_MakeHumanInCSharp
{
    public class TaskTwo
    {
        public static void Main()
        {
            MakeHuman(99);
        }

        public static void MakeHuman(int age)
        {
            Human human = new Human();

            human.Age = age;

            if (age % 2 == 0)
            {
                human.Name = "Pesho";
                human.GenderOfHuman = Gender.male;
            }
            else
            {
                human.Name = "Pepa";
                human.GenderOfHuman = Gender.female;
            }
        }
    }
}

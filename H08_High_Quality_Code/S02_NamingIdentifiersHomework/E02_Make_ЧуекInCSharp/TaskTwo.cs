namespace E02_Task_2_Make_ЧуекInCSharp
{
    public class TaskTwo
    {
        public static void Main() 
        {
            MakeHuman(99);
        }        

        public static void MakeHuman(int age)
        {
            Human newHuman = new Human();

            newHuman.Age = age;

            if (age % 2 == 0)
            {
                newHuman.Name = "Pesho";
                newHuman.GenderOfHuman = Gender.male;
            }
            else
            {
                newHuman.Name = "Pepa";
                newHuman.GenderOfHuman = Gender.female;
            }
        }
    }
}

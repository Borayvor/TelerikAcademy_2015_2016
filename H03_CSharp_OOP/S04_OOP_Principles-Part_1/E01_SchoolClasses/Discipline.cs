namespace E01_SchoolClasses
{

    using E01_SchoolClasses.AbstractClasses;

    public class Discipline : Info
    {
        public Discipline(string name, int numOfLectures, int numOfExercises)
            : base(name)
        {
            this.NumOfLectures = numOfLectures;

            this.NumOfExercises = numOfExercises;
        }

        public int NumOfLectures { get; private set; }

        public int NumOfExercises { get; private set; }
    }
}

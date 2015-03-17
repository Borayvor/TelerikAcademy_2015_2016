namespace E01_SchoolClasses
{    
    using System;

    using E01_SchoolClasses.AbstractClasses;
    using E01_SchoolClasses.Interfaces;

    public class Student : Human, ICommentable
    {
        private int classNumber;

        public Student(string name, int classNumber)
            : base(name)
        {
            this.ClassNumber = classNumber;
        }

        public int ClassNumber
        {
            get
            {
                return classNumber;
            }

            protected set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Students class number can not be less than 1 !");
                }

                this.classNumber = value;
            }
        }
    }
}

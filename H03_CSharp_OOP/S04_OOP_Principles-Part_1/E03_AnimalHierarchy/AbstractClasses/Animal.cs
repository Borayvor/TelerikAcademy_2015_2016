namespace E03_AnimalHierarchy.AbstractClasses
{
    using System;

    public abstract class Animal
    {
        private double age;
        private string name;
        private char sex;

        public Animal(double age, string name, char sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        public double Age
        {
            get
            {
                return this.age;
            }

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The age can not be zero or less !");
                }
                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name can not be null, empty or white-space !");
                }
                this.name = value;
            }
        }

        public char Sex
        {
            get
            {
                return this.sex;
            }

            protected set
            {
                if (value.Equals('M') || value.Equals('F'))
                {
                    this.sex = value;
                }
                else
                {
                    throw new ArgumentException("This sex is not valid !");
                }
            }
        }

        public override string ToString()
        {
            return string.Format("I am a {0}, my name is {1}, sex {2}, at age {3} years",
                this.GetType().Name, Name, Sex, Age);
        }
    }
}

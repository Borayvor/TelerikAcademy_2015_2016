namespace E01_StudentsAndCourses
{
    using System;

    using E01_StudentsAndCourses.Interfaces;

    public class Student : IStudent
    {
        private string firstName;
        private string lastName;
        private int id;

        public Student(string firstNameInitial, string lastNameInitial, int idInitial)
        {
            this.FirstName = firstNameInitial;
            this.LastName = lastNameInitial;
            this.ID = idInitial;
        }

        public string FirstName
        {
            get 
            {
                return this.firstName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name cannot be null, empty or white-space !");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name cannot be null, empty or white-space !");
                }

                this.lastName = value; 
            }
        }

        public int ID
        {
            get
            {
                return this.id;
            }

            private set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("ID is out of range !");
                }

                this.id = value;
            }
        }
    }
}

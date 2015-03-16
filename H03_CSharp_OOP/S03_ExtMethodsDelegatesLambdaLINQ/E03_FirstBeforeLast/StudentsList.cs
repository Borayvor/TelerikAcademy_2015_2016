namespace E03_FirstBeforeLast
{
    using System.Collections.Generic;

    public class StudentsList
    {
        private StudentsList()
        {
        }

        public static List<Student> students = new List<Student>
        {
            new Student 
            {                     
                FirstName = "Zornitsa",
                LastName = "Elenova",
                Age = 17,
            },
            new Student
            {                    
                FirstName = "Ivelina",
                LastName = "Zlateva",
                Age = 20,
            },
            new Student
            {                    
                FirstName = "Pesho",
                LastName = "Dimitrov",  
                Age = 27,
            },
            new Student
            {
                FirstName = "Boris",
                LastName = "Angelov",
                Age = 24,
            },
            new Student
            {
                FirstName = "Unufri",
                LastName = "Unufriev",
                Age = 18,
            },
                
            new Student
            {
                FirstName = "Ivelina",
                LastName = "Tosheva",
                Age = 37,
            },
        };
    }
}

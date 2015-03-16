namespace E09_StudentGroups
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public static class StudentsList
    {
        public static Student[] students = new Student[]
        {
                new Student 
                (                    
                    "Zornitsa",
                    "Elenova",
                    "361406",
                    "088 1234",
                    "edr@abv.bg",
                    1,
                    3,4,2,6,5,4
                ),
                new Student
                (                    
                    "Ivelina",
                    "Zlateva",
                    "756406",
                    "02 8352",
                    "fsdfs@wrwer.fg",
                    2,
                    4, 2, 5, 2, 3, 4
                ),
                new Student
                (                    
                    "Pesho",
                    "Dimitrov",  
                    "366405",
                    "02 1977",
                    "fdsf@abv.bg",
                    3,
                    2, 3, 2, 3, 2, 3
                ),
                new Student
                (
                    "Boris",
                    "Angelov",
                    "646405",
                    "088 3152",
                    "jhgjj@wrwer.fg",
                    1,
                    3, 4, 5, 3, 6, 4
                ),
                new Student
                (
                    "Unufri",
                    "Unufriev",
                    "756404",
                    "088 4242",
                    "rwerw@abv.bg",
                    2,
                    6, 6, 5, 6, 6, 5
                ),
                    
                new Student
                (
                    "Ivelina",
                    "Tosheva",
                    "646404",
                    "088 7657",
                    "dadad@wrwer.fg",
                    3,
                    1, 1, 5, 6, 6, 4
                ),
            };


        public static Group[] groups = new Group[]
                                            {
                                                new Group(1, "Mathematics"),
                                                new Group(2, "Medicine"),
                                                new Group(3, "Physics"),
                                                new Group(4, "Chemistry"),
                                                new Group(5, "Arts"),
                                                new Group(6, "Biology"),
                                            };

        public static void PrintList(IEnumerable list)
        {
            foreach (var student in list)
            {
                Console.WriteLine(student);
                Console.WriteLine();
            }
        }
    }
}

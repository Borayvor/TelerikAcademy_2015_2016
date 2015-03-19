namespace E01_StudentClass
{    
    using System;
    using System.Collections.Generic;

    using E01_StudentClass.EnumClasses;

    public class StudentClassMain
    {
        public static void Main(string[] args)
        {
            // 01. Student class:
            // Define a class Student, which contains data about a 
            // student – first, middle and last name, SSN, permanent 
            // address, mobile phone e-mail, course, specialty, university, 
            // faculty. Use an enumeration for the specialties, 
            // universities and faculties.
            // Override the standard methods, inherited by System.Object: 
            // Equals(), ToString(), GetHashCode() and operators == and !=.
            // 
            // 02. IClonable:
            // Add implementations of the ICloneable interface. The Clone() 
            // method should deeply copy all object's fields into a new 
            // object of type Student.
            // 
            // 03. IComparable:
            // Implement the IComparable<Student> interface to compare students 
            // by names (as first criteria, in lexicographic order) and by 
            // social security number (as second criteria, in increasing order).

            Student firstStudent = new Student();
            firstStudent.FirstName = "Pesho";
            firstStudent.MiddleName = "Goshev";
            firstStudent.LastName = "Peshev";
            firstStudent.SSN = "1000000";
            firstStudent.PermanentAddress = "New York street 17";
            firstStudent.MobilePhone = "0777 345 765";
            firstStudent.E_mail = "Pesho@York.zoo";
            firstStudent.Course = "IV";
            firstStudent.University = University.SU;
            firstStudent.Specialty = Specialty.MedicineMarketing;
            firstStudent.Faculty = Faculty.Management;

            Student secondStudent = new Student();
            secondStudent.FirstName = "Pesho";
            secondStudent.MiddleName = "Goshev";
            secondStudent.LastName = "Petrov";
            secondStudent.SSN = "4353762";
            secondStudent.PermanentAddress = "Moskow street 16";
            secondStudent.MobilePhone = "0769 385 965";
            secondStudent.E_mail = "Pesho@Moskow.tu";
            secondStudent.Course = "III";
            secondStudent.University = University.TU;
            secondStudent.Specialty = Specialty.Informatics;
            secondStudent.Faculty = Faculty.IT_technology;

            Student thirdStudent = new Student();
            thirdStudent.FirstName = "Pesho";
            thirdStudent.MiddleName = "Goshev";
            thirdStudent.LastName = "Peshev";
            thirdStudent.SSN = "1000055";
            thirdStudent.PermanentAddress = "Sofia street 16";
            thirdStudent.MobilePhone = "0464 312 325";
            thirdStudent.E_mail = "Pesho@Sofia.tu";
            thirdStudent.Course = "II";
            thirdStudent.University = University.TU;
            thirdStudent.Specialty = Specialty.Informatics;
            thirdStudent.Faculty = Faculty.Management;

            Console.WriteLine("firstStudent = secondStudent : {0}", (firstStudent == secondStudent));
            Console.WriteLine("firstStudent = thirdStudent : {0}", (firstStudent == thirdStudent));
            Console.WriteLine();
            Console.WriteLine("firstStudent Equals secondStudent : {0}", (firstStudent.Equals(secondStudent)));
            Console.WriteLine("firstStudent Equals thirdStudent : {0}", (firstStudent.Equals(thirdStudent)));
            Console.WriteLine();
            
            // 02. IClonable:
            Student cloneStudent = firstStudent.Clone();
            Console.WriteLine("firstStudent Equals cloneStudent : {0}", (firstStudent.Equals(cloneStudent)));
            Console.WriteLine("secondStudent Equals cloneStudent : {0}", (secondStudent.Equals(cloneStudent)));
            Console.WriteLine();

            // 03. IComparable:
            Console.WriteLine("firstStudent CompareTo cloneStudent : {0}", (firstStudent.CompareTo(cloneStudent)));
            Console.WriteLine("secondStudent CompareTo cloneStudent : {0}", (secondStudent.CompareTo(cloneStudent)));
            Console.WriteLine();

            List<Student> listStudents = new List<Student>();
            listStudents.Add(firstStudent);
            listStudents.Add(secondStudent);
            listStudents.Add(cloneStudent);
            listStudents.Add(thirdStudent);

            listStudents.Sort();

            foreach (var student in listStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}

namespace E01_StudentClass
{    
    using System;

    using E01_StudentClass.EnumClasses;

    public class Student : ICloneable, IComparable<Student>
    {
        public Student()
        {
        }

        public Student(string firstName, string middleName, string lastName, 
            string ssn, string permanentAddress, string mobilePhone, string e_mail, 
            string course, University university, Faculty faculty, Specialty specialty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.E_mail = e_mail;
            this.Course = course;
            this.University = university;
            this.Specialty = specialty;
            this.Faculty = faculty;
        }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string PermanentAddress { get; set; }
        public string MobilePhone { get; set; }
        public string E_mail { get; set; }
        public string Course { get; set; }
        public Specialty Specialty { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }

        public override bool Equals(object param)
        {
            Student student = param as Student;
                        
            if (student == null)
            {
                throw new ArgumentException("The object is not Student !");
            }
                        
            if (!Object.Equals(this.FirstName, student.FirstName))
            {
                return false;
            }

            if (!Object.Equals(this.MiddleName, student.MiddleName))
            {
                return false;
            }

            if (!Object.Equals(this.LastName, student.LastName))
            {
                return false;
            }

            if (!Object.Equals(this.SSN, student.SSN))
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Student first, Student second)
        {
            return Student.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !(Student.Equals(first, second));
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ MiddleName.GetHashCode() ^ 
                LastName.GetHashCode() ^ SSN.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format("Student : \r\nFirst name: {0}\r\nMiddle " + 
                "name: {1}\r\nLast name: {2}\r\nSSN: {3}\n\r" + 
                "Permanent address: {4}\r\nMobile phone: {5}\r\nEMail: " + 
                "{6}\r\nCourse: {7}\r\nUniversity: {8}\r\n" +
                "Faculty: {9}\r\nSpecialty: {10}\r\n",
                this.FirstName, this.MiddleName, this.LastName, this.SSN, 
                this.PermanentAddress, this.MobilePhone, this.E_mail, this.Course, 
                this.University, this.Faculty, this.Specialty);
        }

        public Student Clone()
        {
            Student cloneStudent = new Student(this.FirstName, 
                this.MiddleName, this.LastName, this.SSN, this.PermanentAddress, 
                this.MobilePhone, this.E_mail, this.Course, this.University, 
                this.Faculty, this.Specialty);

            return cloneStudent;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(Student comparedStudent)
        {
            if (this.FirstName != comparedStudent.FirstName)
            {
                return (this.FirstName.CompareTo(comparedStudent.FirstName));
            }

            if (this.MiddleName != comparedStudent.MiddleName)
            {
                return (this.MiddleName.CompareTo(comparedStudent.MiddleName));
            }

            if (this.LastName != comparedStudent.LastName)
            {
                return (this.LastName.CompareTo(comparedStudent.LastName));
            }

            if (this.SSN != comparedStudent.SSN)
            {
                return (this.SSN.CompareTo(comparedStudent.SSN));
            }

            return 0;
        }
    }
}

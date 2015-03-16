namespace E09_StudentGroups
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public class Student
    {
        private string firstName;
        private string lastName;
        private string fn;
        private string email;
        private List<int> marks;
        private int groupNumber;

        public Student(string firstName, string lastName, string fn, string tel, 
            string email, int groupNumber, params int[] marks)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.GroupNumber = groupNumber;
            this.marks = new List<int>(marks);
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
                    throw new ArgumentException("First name can't be null, whitespace or empty!");
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name can't be null, whitespace or empty!");
                }
                this.lastName = value;
            }
        }

        public string FN
        {
            get
            {
                return this.fn;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("FN can't be null, whitespace or empty!");
                }
                this.fn = value;
            }
        }

        public string Tel
        {
            get;
            private set;
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            private set
            {
                if (value == null || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Email can't be null, whitespace or empty!");
                }
                this.email = value;
            }
        }

        public int GroupNumber
        {
            get
            {
                return this.groupNumber;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Group number can't be negative or zero !");
                }
                this.groupNumber = value;
            }
        }

        public string Marks
        {
            get { return string.Join(", ", this.marks); }
        }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("First name: {0}", this.FirstName);
            result.AppendLine();
            result.AppendLine("Last name: " + this.LastName);
            result.AppendLine("FN: " + this.FN);
            result.AppendLine("Tel: " + this.Tel);
            result.AppendLine("Email: " + this.Email);
            result.AppendLine("Marks: " + Marks);
            result.AppendLine("Group number: " + this.GroupNumber);
            result.Append("Department name: " + 
                StudentsList.groups[this.GroupNumber - 1].DepartmentName);

            return result.ToString();
        }
    }
}

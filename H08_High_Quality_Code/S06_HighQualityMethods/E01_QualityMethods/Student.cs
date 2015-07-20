namespace E01_QualityMethods
{
    using System;
    using System.Globalization;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string dateOfBirth;
        private string location;
        private string profession;
              
        public Student(string firstNameValue, string lastNameValue)
        {
            this.FirstName = firstNameValue;
            this.LastName = lastNameValue;
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
                    throw new ArgumentException("\"First name\" cannot be " + 
                        "null, empty, or consists only of white-space characters !");
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
                    throw new ArgumentException("\"Last name\" cannot " + 
                        "be null, empty, or consists only of white-space characters !");
                }

                this.lastName = value;
            }
        }

        public string DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("\"Date Of Birth\" cannot " + 
                        "be null, empty, or consists only of white-space characters !");
                }

                DateTime dateOfBirthValue;

                bool isDate = DateTime.TryParseExact(value, "dd.MM.yyyy", 
                    CultureInfo.InvariantCulture, DateTimeStyles.None,
                    out dateOfBirthValue);

                if (isDate == false)
                {
                    throw new ArgumentException("Invalid date format !");
                }

                this.dateOfBirth = dateOfBirthValue.ToShortDateString();
            }
        }               

        public string Location
        {
            get
            {
                return this.location;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("\"Location\" cannot " + 
                        "be null, empty, or consists only of white-space characters !");
                }

                this.location = value;
            }
        }

        public string Profession
        {
            get
            {
                return this.profession;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("\"Profession\" cannot " + 
                        "be null, empty, or consists only of white-space characters !");
                }

                this.profession = value;
            }
        }

        //private bool IsData (string dataValue)
        //{
        //    DateTime dateOfBirthValue;

        //    bool isDate = DateTime.TryParseExact (dataValue, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None,
        //        out dateOfBirthValue);

        //    return isDate;
        //}

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student secondStudent)
        {
            //DateTime firstDate =
            //    DateTime.Parse(this.OtherInfo.Substring(this.OtherInfo.Length - 10));
            //DateTime secondDate =
            //    DateTime.Parse(other.OtherInfo.Substring(other.OtherInfo.Length - 10));
            //return firstDate > secondDate;

            bool isOlder = false;

            isOlder = (Convert.ToDateTime(this.DateOfBirth) < Convert.ToDateTime(secondStudent.DateOfBirth));

            return isOlder;
        }
    }
}

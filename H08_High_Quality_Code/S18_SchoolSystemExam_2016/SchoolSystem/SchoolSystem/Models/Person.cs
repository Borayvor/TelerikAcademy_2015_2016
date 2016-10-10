namespace SchoolSystem.Models
{
    using Common;
    using Contracts;

    public abstract class Person : IPerson
    {
        private const string FirstNameAsString = "Firts name";
        private const string LastNameAsString = "Last name";

        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                Validator.ValidateIsStringNullOrWhiteSpace(value, LastNameAsString);
                Validator.ValidateNameLength(value, FirstNameAsString);
                Validator.ValidateNameCharacters(value, FirstNameAsString);

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
                Validator.ValidateIsStringNullOrWhiteSpace(value, LastNameAsString);
                Validator.ValidateNameLength(value, LastNameAsString);
                Validator.ValidateNameCharacters(value, LastNameAsString);

                this.lastName = value;
            }
        }
    }
}

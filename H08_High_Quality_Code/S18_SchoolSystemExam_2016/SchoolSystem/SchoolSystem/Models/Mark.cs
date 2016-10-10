namespace SchoolSystem.Models
{
    using Common;
    using Contracts;
    using EnumTypes;

    public class Mark : IMark
    {
        private float value;
        private SubjectType subject;

        public Mark(SubjectType subject, float value)
        {
            this.Subject = subject;
            this.Value = value;
        }

        public SubjectType Subject
        {
            get
            {
                return this.subject;
            }

            private set
            {
                this.subject = value;
            }
        }

        public float Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                Validator.ValidateMarkValue(value);

                this.value = value;
            }
        }
    }
}

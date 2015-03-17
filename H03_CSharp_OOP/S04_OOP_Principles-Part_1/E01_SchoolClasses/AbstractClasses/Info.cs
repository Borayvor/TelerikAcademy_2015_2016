namespace E01_SchoolClasses.AbstractClasses
{    
    using System;

    using E01_SchoolClasses.Interfaces;

    public class Info : ICommentable
    {
        private string name;
        private string comments;

        public Info(string name)
        {
            this.Identifier = name;
        }

        public string Identifier
        {
            get
            {
                return this.name;
            }

            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can not be null or empty !");
                }

                this.name = value;
            }
        }

        public string Comment
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this.comments))
                {
                    return "No comments yet";
                }

                return this.comments;
            }

            set
            {
                this.comments = value;
            }
        }
    }
}

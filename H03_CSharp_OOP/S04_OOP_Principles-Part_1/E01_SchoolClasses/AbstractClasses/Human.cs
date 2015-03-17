namespace E01_SchoolClasses.AbstractClasses
{    
    using System;

    using E01_SchoolClasses.Interfaces;

    public abstract class Human : Info, ICommentable
    {
        public Human(string name)
            : base(name)
        {
        }
    }
}

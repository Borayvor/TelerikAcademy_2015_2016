namespace E01_SchoolClasses
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        private List<SchoolClass> classList;

        public School(List<SchoolClass> classList)
        {
            this.classList = classList;
        }

        public List<SchoolClass> SchoolClassList
        {
            get
            {
                return this.classList;
            }
        }

        public void AddSchoolClass(SchoolClass schoolClass)
        {
            this.classList.Add(schoolClass);
        }

        public void RemoveSchoolClass(SchoolClass schoolClass)
        {
            if (!this.classList.Contains(schoolClass))
            {
                throw new ArgumentException("No such class in this school found !");
            }

            this.classList.Remove(schoolClass);
        }
    }
}

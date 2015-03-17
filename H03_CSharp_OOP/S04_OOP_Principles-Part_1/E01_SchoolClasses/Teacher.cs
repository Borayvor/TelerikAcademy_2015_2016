namespace E01_SchoolClasses
{    
    using System;
    using System.Collections.Generic;

    using E01_SchoolClasses.AbstractClasses;
    using E01_SchoolClasses.Interfaces;

    public class Teacher : Human, ICommentable
    {
        private List<Discipline> disciplines;

        public Teacher(string name, List<Discipline> disciplinesList)
            : base(name)
        {
            this.disciplines = disciplinesList;
        }

        public List<Discipline> DisciplinesList
        {
            get
            {
                return this.disciplines;
            }
        }

        public void AddDiscipline(Discipline discipline)
        {
            this.disciplines.Add(discipline);
        }

        public void RemoveDiscipline(Discipline discipline)
        {
            if (!this.disciplines.Contains(discipline))
            {
                throw new ArgumentException("No such teacher in this class found !");
            }

            this.disciplines.Remove(discipline);
        }
    }
}

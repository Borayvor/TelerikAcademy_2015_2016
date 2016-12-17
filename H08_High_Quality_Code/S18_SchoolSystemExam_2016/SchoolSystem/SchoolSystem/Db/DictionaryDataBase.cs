namespace SchoolSystem.Db
{
    using System.Collections.Generic;
    using Contracts;

    public class DictionaryDataBase : IDataBase
    {
        private static IDictionary<int, IStudent> students;
        private static IDictionary<int, ITeacher> teachers;

        public DictionaryDataBase()
        {
            students = new Dictionary<int, IStudent>();
            teachers = new Dictionary<int, ITeacher>();
        }

        public void AddStudent(IStudent student)
        {
            students.Add(student.Id, student);
        }

        public void AddTeacher(ITeacher teacher)
        {
            teachers.Add(teacher.Id, teacher);
        }

        public IStudent GetStudentById(int id)
        {
            return students[id];
        }

        public ITeacher GetTeacherById(int id)
        {
            return teachers[id];
        }

        public bool RemoveStudentById(int id)
        {
            var isRemoved = students.Remove(id);

            return isRemoved;
        }

        public bool RemoveTeacherById(int id)
        {
            var isRemoved = teachers.Remove(id);

            return isRemoved;
        }
    }
}

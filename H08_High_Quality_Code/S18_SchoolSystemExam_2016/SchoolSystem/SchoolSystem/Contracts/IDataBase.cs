namespace SchoolSystem.Contracts
{
    public interface IDataBase
    {
        IStudent GetStudentById(int id);

        void AddStudent(IStudent student);

        bool RemoveStudentById(int id);

        ITeacher GetTeacherById(int id);

        void AddTeacher(ITeacher teacher);

        bool RemoveTeacherById(int id);
    }
}

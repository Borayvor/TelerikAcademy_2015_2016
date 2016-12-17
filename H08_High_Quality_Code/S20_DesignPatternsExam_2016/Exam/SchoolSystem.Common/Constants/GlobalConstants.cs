namespace SchoolSystem.Common.Constants
{
    public class GlobalConstants
    {
        public const string InvalidCommandMessage = "Invalid command !";
        public const string NotFoundMessage = "The given key was not present in the dictionary.";

        public const string CreateStudentCommandName = "CreateStudent";
        public const string RemoveStudentCommandName = "RemoveStudent";
        public const string CreateTeacherCommandName = "CreateTeacher";
        public const string RemoveTeacherCommandName = "RemoveTeacher";

        /// <summary>
        /// 0 = First name; 1 = Last name; 2 = Grade; 3 = Id;
        /// </summary>
        public const string CreateStudentSuccessMessageTemplate =
            "A new student with name {0} {1}, grade {2} and ID {3} was created.";

        /// <summary>
        /// 0 = First name; 1 = Last name; 2 = Subject; 3 = Id;
        /// </summary>
        public const string CreateTeacherSuccessMessageTemplate =
            "A new teacher with name {0} {1}, subject {2} and ID {3} was created.";

        /// <summary>
        /// 0 = Id;
        /// </summary>
        public const string RemoveStudentSuccessMessageTemplate =
            "Student with ID {0} was sucessfully removed.";

        /// <summary>
        /// 0 = Id;
        /// </summary>
        public const string RemoveTeacherSuccessMessageTemplate =
            "Teacher with ID {0} was sucessfully removed.";

        /// <summary>
        /// 0 = teacher.FirstName; 1 = teacher.LastName; 2 = mark;
        /// 3 = student.FirstName; 4 = student.LastName; 5 = teacher.Subject;
        /// </summary>
        public const string TeacherAddMarkSuccessMessageTemplate =
            "Teacher {0} {1} added mark {2} to student {3} {4} in {5}.";
    }
}

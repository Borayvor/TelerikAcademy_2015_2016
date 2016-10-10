namespace SchoolSystem.Tests
{
    using Common;
    using EnumTypes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class StudentTest
    {
        private Student student;

        [TestInitialize]
        public void InitializeStudent()
        {
            this.student = new Student("Gogo", "Petrov", GradeType.Fifth);
        }

        [TestMethod]
        public void StudentCannotBeNullWhenInstantiated()
        {
            Assert.IsNotNull(this.student);
        }

        [TestMethod]
        public void StudentFirstNameCannotBeNullEmptyOrWhiteSpace()
        {
            Assert.IsNotNull(this.student.FirstName);
        }

        [TestMethod]
        public void StudentLastNameCannotBeNullEmptyOrWhiteSpace()
        {
            Assert.IsNotNull(this.student.LastName);
        }

        [TestMethod]
        public void StudentIntegerGradeMustBeInRange()
        {
            Assert.IsFalse((int)this.student.Grade < GlobalConstants.GradeMinValue || (int)this.student.Grade > GlobalConstants.GradeMaxValue);
        }
    }
}

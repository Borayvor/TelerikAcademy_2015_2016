namespace SchoolSystem.Tests
{
    using System;
    using Common;
    using EnumTypes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Models;

    [TestClass]
    public class MarkTest
    {
        private Mark mark;

        [TestInitialize]
        public void InitializeStudent()
        {
            this.mark = new Mark(SubjectType.Bulgarian, 5.56f);
        }

        [TestMethod]
        public void MarkCannotBeNullWhenInstantiated()
        {
            Assert.IsNotNull(this.mark);
        }

        [TestMethod]
        public void MustThrowArgumentOutOfRangeExceptionIfMarkValueIsNotValid()
        {
            string actual = string.Empty;

            try
            {
                var markOne = new Mark(SubjectType.Bulgarian, 1.45f);
            }
            catch (ArgumentOutOfRangeException aore)
            {
                actual = aore.Message;
            }


            Assert.AreNotEqual(ExceptionMessages.MarkValueOutOfRange, actual);
        }
    }
}

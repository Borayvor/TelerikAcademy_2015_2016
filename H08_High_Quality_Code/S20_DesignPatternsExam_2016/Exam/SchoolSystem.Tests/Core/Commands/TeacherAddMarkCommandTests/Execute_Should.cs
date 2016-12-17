namespace SchoolSystem.Tests.Core.Commands.TeacherAddMarkCommandTests
{
    using System;
    using System.Collections.Generic;
    using Common.Constants;
    using Framework.Core.Commands;
    using Framework.Models.Contracts;
    using Framework.Models.Enums;
    using Moq;
    using NUnit.Framework;
    using Repositories;

    [TestFixture]
    public class Execute_Should
    {
        private const string SourcesListVariableName = "_sourceLists";

        private static object[] _sourceLists =
        {
            new object[] { new List<string> { "0", "1", "5" } },
            new object[] { new List<string> { "1", "0", "3" } }
        };

        [Test, TestCaseSource(SourcesListVariableName)]
        public void AddMarkToStudent_WhenParametersAreCorrect(IList<string> parameters)
        {
            // Arrange
            var parametersTuple = GetParameters(parameters);
            var studentMock = new Mock<IStudent>();
            var teacherMock = new Mock<ITeacher>();
            var mockedStudentRepository = new MockedRepository<IStudent>();
            var mockedTeacherRepository = new MockedRepository<ITeacher>();

            var teacherAddMarkCommand = new TeacherAddMarkCommand(
                mockedTeacherRepository,
                mockedStudentRepository);

            mockedStudentRepository.Add(studentMock.Object);
            mockedStudentRepository.Add(studentMock.Object);
            mockedTeacherRepository.Add(teacherMock.Object);
            mockedTeacherRepository.Add(teacherMock.Object);

            // Act
            teacherAddMarkCommand.Execute(parameters);

            // Assert
            teacherMock.Verify(t => t.AddMark(studentMock.Object, parametersTuple.Item3), Times.Once());
        }

        [Test, TestCaseSource(SourcesListVariableName)]
        public void ReturnSuccessMessage_WhenParametersAreCorrect(IList<string> parameters)
        {
            // Arrange
            var parametersTuple = GetParameters(parameters);

            var studentFirstName = "studentFirstName";
            var studentLastName = "studentLastName";
            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(s => s.FirstName).Returns(studentFirstName);
            studentMock.SetupGet(s => s.LastName).Returns(studentLastName);

            var teacherFirstName = "teacherFirstName";
            var teacherLastName = "teacherLastName";
            var teacherSubject = Subject.English;
            var teacherMock = new Mock<ITeacher>();
            teacherMock.SetupGet(s => s.FirstName).Returns(teacherFirstName);
            teacherMock.SetupGet(s => s.LastName).Returns(teacherLastName);
            teacherMock.SetupGet(s => s.Subject).Returns(teacherSubject);

            var mockedStudentRepository = new MockedRepository<IStudent>();
            var mockedTeacherRepository = new MockedRepository<ITeacher>();

            var expectedResult = string.Format(
                GlobalConstants.TeacherAddMarkSuccessMessageTemplate,
                teacherFirstName,
                teacherLastName,
                parametersTuple.Item3,
                studentFirstName,
                studentLastName,
                teacherSubject);

            var teacherAddMarkCommand = new TeacherAddMarkCommand(
                mockedTeacherRepository,
                mockedStudentRepository);

            mockedStudentRepository.Add(studentMock.Object);
            mockedStudentRepository.Add(studentMock.Object);
            mockedTeacherRepository.Add(teacherMock.Object);
            mockedTeacherRepository.Add(teacherMock.Object);

            // Act
            var result = teacherAddMarkCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        private static Tuple<int, int, float> GetParameters(IList<string> parameters)
        {
            return new Tuple<int, int, float>(int.Parse(parameters[0]), int.Parse(parameters[1]), float.Parse(parameters[2]));
        }
    }
}

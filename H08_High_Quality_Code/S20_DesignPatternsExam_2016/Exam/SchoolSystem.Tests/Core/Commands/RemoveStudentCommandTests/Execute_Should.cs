namespace SchoolSystem.Tests.Core.Commands.RemoveStudentCommandTests
{
    using System.Collections.Generic;
    using Common.Constants;
    using Framework.Core.Commands;
    using Framework.Models.Contracts;
    using Moq;
    using NUnit.Framework;
    using Repositories;

    [TestFixture]
    public class Execute_Should
    {
        private const string SourcesListVariableName = "_sourceLists";

        private static object[] _sourceLists =
        {
            new object[] { new List<string> { "0" } },
            new object[] { new List<string> { "1" } }
        };

        [Test, TestCaseSource(SourcesListVariableName)]
        public void RemoveStudentWithCorrectId_WhenParametersAreCorrect(IList<string> parameters)
        {
            // Arrange             
            var mockStudentFirst = new Mock<IStudent>();
            var mockStudentSecond = new Mock<IStudent>();

            var mockedStudentRepository = new MockedRepository<IStudent>();
            var removeStudentCommand = new RemoveStudentCommand(mockedStudentRepository);

            var studentId = int.Parse(parameters[0]);
            mockedStudentRepository.Add(mockStudentFirst.Object);
            mockedStudentRepository.Add(mockStudentSecond.Object);

            // Act            
            removeStudentCommand.Execute(parameters);

            // Assert
            Assert.IsNull(mockedStudentRepository.GetById(studentId));
        }

        [Test, TestCaseSource(SourcesListVariableName)]
        public void ReturnSuccessMessage_WhenParametersAreCorrect(IList<string> parameters)
        {
            // Arrange
            var mockStudentFirst = new Mock<IStudent>();
            var mockStudentSecond = new Mock<IStudent>();            
            var mockedStudentRepository = new MockedRepository<IStudent>();

            var studentId = int.Parse(parameters[0]);
            var expectedResult = string.Format(
                GlobalConstants.RemoveStudentSuccessMessageTemplate,
                studentId);

            var removeStudentCommand = new RemoveStudentCommand(mockedStudentRepository);
            
            mockedStudentRepository.Add(mockStudentFirst.Object);
            mockedStudentRepository.Add(mockStudentSecond.Object);

            // Act
            var result = removeStudentCommand.Execute(parameters);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}

using Business.Commands;
using Business.Handlers;
using Core.Interfaces;
using Data.Entity;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test
{
    [TestClass]
    public class AddTaskCommandHandlerTests
    {
        private Mock<ILogger<AddTaskCommandHandler>> _loggerMock = default!;
        private Mock<ICrud<TTask>> _taskCrudMock = default!;
        private AddTaskCommandHandler _handler = default!;

        [TestInitialize]
        public void SetUp()
        {
            _loggerMock = new Mock<ILogger<AddTaskCommandHandler>>();
            _taskCrudMock = new Mock<ICrud<TTask>>();
            _handler = new AddTaskCommandHandler(_loggerMock.Object, _taskCrudMock.Object);
        }

        [TestMethod]
        public async Task Execute_ShouldReturnTrue_WhenTaskIsAddedSuccessfully()
        {
            var command = new AddTaskCommand { ClientId = Guid.NewGuid().ToString(),  Name = "Test Task" };
            
            _taskCrudMock.Setup(crud => crud.AddAsync( It.IsAny<TTask>() )).Returns(Task.CompletedTask);

            var result = await _handler.Execute(command);

            Assert.IsTrue(result);

            _taskCrudMock.Verify(crud => crud.AddAsync(It.Is<TTask>(t => t.Name == command.Name)), Times.Once);
        }

        [TestMethod]
        public async Task Execute_ShouldReturnError_WhenExceptionIsThrown()
        {
            var command = new AddTaskCommand { ClientId = Guid.NewGuid().ToString(), Name = "Test Task" };
            _taskCrudMock.Setup(crud => crud.AddAsync(It.IsAny<TTask>())).Throws(new Exception("Database error"));

            var result = await _handler.Execute(command);

            Assert.IsFalse(result);
            Assert.AreEqual("Something went wrong adding task", result.Error);
        }
    }
}

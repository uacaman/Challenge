using Business.Commands;
using Business.Handlers;
using Core;
using Core.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace Test
{
    [TestClass]
    public class CompleteTaskCommandHandlerTests
    {
        private Mock<ILogger<CompleteTaskCommandHandler>> _loggerMock = default!;
        private Mock<ICommandHandler<UpdateTaskCommand, Result<bool>>> _updateTaskCommandHandlerMock = default!;
        private CompleteTaskCommandHandler _handler = default!;

        [TestInitialize]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<CompleteTaskCommandHandler>>();
            _updateTaskCommandHandlerMock = new Mock<ICommandHandler<UpdateTaskCommand, Result<bool>>>();
            _handler = new CompleteTaskCommandHandler(_loggerMock.Object, _updateTaskCommandHandlerMock.Object);
        }

        [TestMethod]
        public async Task Execute_ShouldReturnSuccess_WhenTaskCompletesSuccessfully()
        {
            var completeTaskCommand = new CompleteTaskCommand
            {
                ClientId = Guid.NewGuid().ToString(),
                Id = 1
            };

            _updateTaskCommandHandlerMock.Setup(x => x.Execute(It.IsAny<UpdateTaskCommand>()))
                .ReturnsAsync(true);

            var result = await _handler.Execute(completeTaskCommand);
            Assert.IsTrue(result.Value);

            _updateTaskCommandHandlerMock.Verify(x => x.Execute(It.IsAny<UpdateTaskCommand>()), Times.Once);
        }

        [TestMethod]
        public async Task Execute_ShouldReturnError_WhenUpdateTaskFails()
        {
            // Arrange
            var completeTaskCommand = new CompleteTaskCommand
            {
                ClientId = Guid.NewGuid().ToString(),
                Id = 1
            };

            _updateTaskCommandHandlerMock
                .Setup(x => x.Execute(It.IsAny<UpdateTaskCommand>()))
                .ReturnsAsync(new Error("Failed to update task") );

            var result = await _handler.Execute(completeTaskCommand);

            Assert.IsFalse(result);
            Assert.AreEqual("Failed to update task", result.Error);

            _updateTaskCommandHandlerMock.Verify(x => x.Execute(It.IsAny<UpdateTaskCommand>()), Times.Once);
        }
    }
}

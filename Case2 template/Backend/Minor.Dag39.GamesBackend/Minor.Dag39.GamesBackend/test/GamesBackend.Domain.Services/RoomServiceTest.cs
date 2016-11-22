using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag39.GamesBackend.DAL.Repositories;
using Minor.Dag39.GamesBackend.Entities;
using Minor.Dag39.GamesBackend.Incoming.Commands;
using Minor.Dag39.GamesBackend.Services;
using Minor.WSA.Commons;
using Moq;

namespace GamesBackend.Domain.Services {
    [TestClass]
    public class RoomServiceTest 
    {
        [TestMethod]
        public void StartGameProcessesCommandTest() 
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Room, int>>(MockBehavior.Strict);
            var publisherMock = new Mock<IEventPublisher>(MockBehavior.Strict);

            repositoryMock.Setup(x => x.Insert(It.IsAny<Room>())).Returns(1);
            publisherMock.Setup(x => x.Publish(It.IsAny<DomainEvent>()));

            var target = new RoomService(repositoryMock.Object, publisherMock.Object);
            var createRoomCommand = new CreateRoomCommand();

            // Act
            target.StartGame(createRoomCommand);

            // Assert
            repositoryMock.Verify(x => x.Insert(It.IsAny<Room>()), Times.Once());
            publisherMock.Verify(x => x.Publish(It.IsAny<DomainEvent>()), Times.Once());
        }

        [TestMethod]
        public void StartGameRoomSameNameAsGameRoomCommandTest() {
            // Arrange
            var repositoryMock = new Mock<IRepository<Room, int>>(MockBehavior.Strict);
            var publisherMock = new Mock<IEventPublisher>(MockBehavior.Strict);

            repositoryMock.Setup(x => x.Insert(It.IsAny<Room>())).Returns(1);
            publisherMock.Setup(x => x.Publish(It.IsAny<DomainEvent>()));

            var target = new RoomService(repositoryMock.Object, publisherMock.Object);
            var createRoomCommand = new CreateRoomCommand() { RoomName = "Chess-01" };

            // Act
            var result = target.StartGame(createRoomCommand);

            // Assert
            repositoryMock.Verify(x => x.Insert(It.IsAny<Room>()), Times.Once());
            publisherMock.Verify(x => x.Publish(It.IsAny<DomainEvent>()), Times.Once());

            Assert.IsNotNull(result);
            Assert.AreEqual(createRoomCommand.RoomName, result.Name);
        }
    }
}

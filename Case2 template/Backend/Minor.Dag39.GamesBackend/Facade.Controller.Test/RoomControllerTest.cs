using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minor.Dag39.GamesBackend.Incoming.Commands;
using Minor.Dag39.GamesBackend.Services;
using Minor.Dag39.GamesBackend.WebApi.Controllers;
using Moq;

namespace Facade.Controller.Test
{
    [TestClass]
    public class RoomControllerTest
    {
        [TestMethod]
        public void SuccesStartingGame()
        {
            //Arrange
            var mock = new Mock<RoomService>(MockBehavior.Strict);
            mock.Setup(x => x.StartGame(It.IsAny<CreateRoomCommand>()));

            var target = new RoomController(mock.Object);

            var command = new CreateRoomCommand();

            //Act
            target.CreateGame(command);

            //Assert
            mock.Verify(y => y.StartGame(It.IsAny<CreateRoomCommand>()), Times.Once);
        }

        [TestMethod]
        public void SuccesStartingGameCorrectCommand()
        {
            //Arrange
            var mock = new Mock<RoomService>(MockBehavior.Strict);
            var command = new CreateRoomCommand();

            mock.Setup(x => x.StartGame(It.Is<CreateRoomCommand>(y => y == command)));
            var target = new RoomController(mock.Object);


            //Act
            target.CreateGame(command);

            //Assert
            mock.Verify(x => x.StartGame(It.Is<CreateRoomCommand>(y => y == command)), Times.Once);
        }

        [TestMethod]
        public void SuccesEndingGameCorrectCommand()
        {
            //Arrange
            var mock = new Mock<RoomService>(MockBehavior.Strict);
            var command = new EndGameCommand();

            mock.Setup(x => x.EndGame(It.Is<EndGameCommand>(y => y == command)));
            var target = new RoomController(mock.Object);


            //Act
            target.EndGame(command);

            //Assert
            mock.Verify(x => x.EndGame(It.Is<EndGameCommand>(y => y == command)), Times.Once);
        }
    }
}

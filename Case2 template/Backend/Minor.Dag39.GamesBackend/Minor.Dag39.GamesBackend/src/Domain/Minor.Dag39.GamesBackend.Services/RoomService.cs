using System;
using Minor.Dag39.GamesBackend.Entities;
using Minor.Dag39.GamesBackend.DAL.Repositories;
using Minor.Dag39.GamesBackend.Incoming.Commands;
using Minor.WSA.Commons;
using Minor.Dag39.GamesBackend.Outgoing.Events;

namespace Minor.Dag39.GamesBackend.Services {
    public class RoomService : IDisposable
    {
        private readonly IRepository<Room, long> _repository;
        private readonly IEventPublisher _publisher;

        public RoomService(IRepository<Room, long> repository, IEventPublisher publisher)
        {
            _repository = repository;
            _publisher = publisher;
        }

        public Room StartGame(CreateRoomCommand command)
        {
            var room = new Room() { Name = command.RoomName };
            _repository.Insert(room);

            // (optional) throw RoomCreatedEvent
            var roomCreatedEvent = new RoomCreatedEvent() { GUID = Guid.NewGuid().ToString(), RoutingKey = "Minor.GameRooms", TimeStamp = DateTime.UtcNow };
            _publisher.Publish(roomCreatedEvent);

            return room;
        }

        public Room EndGame(EndGameCommand endCommand)
        {
            var room = _repository.Find(endCommand.RoomId);
            room.Running = false;
            _repository.Update(room);

            return room;
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }


    }
}

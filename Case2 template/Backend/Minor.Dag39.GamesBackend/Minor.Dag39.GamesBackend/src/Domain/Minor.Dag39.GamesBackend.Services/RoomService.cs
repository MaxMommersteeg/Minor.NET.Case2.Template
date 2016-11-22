using System;
using Minor.Dag39.GamesBackend.DAL;
using Minor.Dag39.GamesBackend.Entities;
using Minor.Dag39.GamesBackend.Outgoing;
using Minor.Dag39.GamesBackend.Incoming;
using Minor.Dag39.GamesBackend.DAL.Repositories;
using Minor.Dag39.GamesBackend.Incoming.Commands;
using Minor.WSA.Commons;
using Minor.WSA.EventBus.Publisher;
using Minor.Dag39.GamesBackend.Outgoing.Events;

namespace Minor.Dag39.GamesBackend.Services
{
    public class RoomService : IDisposable
    {
        private readonly IRepository<Room, int> _repository;
        private readonly IEventPublisher _publisher;

        public RoomService(IRepository<Room, int> repository, IEventPublisher publisher)
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

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}

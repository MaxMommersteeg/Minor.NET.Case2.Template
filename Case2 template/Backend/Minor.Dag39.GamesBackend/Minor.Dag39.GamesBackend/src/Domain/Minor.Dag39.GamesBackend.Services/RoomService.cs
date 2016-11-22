using System;
using Minor.Dag39.GamesBackend.DAL;
using Minor.Dag39.GamesBackend.Entities;
using Minor.Dag39.GamesBackend.Outgoing;
using Minor.Dag39.GamesBackend.Incoming;
using Minor.Dag39.GamesBackend.DAL.Repositories;

namespace Minor.Dag39.GamesBackend.Services
{
    public class RoomService : IDisposable
    {
        private readonly IRepository<Room, int> _repository;

        public RoomService(IRepository<Room, int> repository)
        {
            _repository = repository;
        }

        public Room StartGame(CreateRoomCommand command)
        {
            var room = new Room() { Name = command.RoomName };
            _repository.Insert(room);
            return room;
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}

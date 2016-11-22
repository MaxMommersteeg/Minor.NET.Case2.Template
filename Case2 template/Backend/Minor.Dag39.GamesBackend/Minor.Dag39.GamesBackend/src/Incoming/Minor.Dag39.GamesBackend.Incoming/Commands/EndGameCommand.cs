using System;

namespace Minor.Dag39.GamesBackend.Incoming.Commands
{
    public class EndGameCommand : ICommand
    {
        public Guid CommandId { get; set; }

        public DateTime Timestamp { get; set; }

        public string RoomName { get; set; }
    }
}
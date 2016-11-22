using Minor.Dag39.GamesBackend.Entities;
using Minor.WSA.Commons;

namespace Minor.Dag39.GamesBackend.Outgoing
{
    public class GameCreatedEvent
        : DomainEvent
    {
        public GameCreatedEvent(Room room)
        {
            Room = room;
        }
        public Room Room { get; set; }
    }
}

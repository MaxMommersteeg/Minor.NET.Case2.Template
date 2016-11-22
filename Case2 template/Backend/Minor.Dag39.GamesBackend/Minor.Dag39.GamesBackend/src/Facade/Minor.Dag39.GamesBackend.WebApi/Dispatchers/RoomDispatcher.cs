using Minor.WSA.EventBus.Dispatcher;
using Minor.WSA.EventBus.Config;
using Minor.Dag39.GamesBackend.Incoming.Events;

namespace Minor.Dag39.GamesBackend.WebApi.Dispatchers 
{
    [RoutingKey("#")]
    public class RoomDispatcher : EventDispatcher 
    {
        public RoomDispatcher(EventBusConfig config) : base(config) 
        {

        }

        public void OnRoomCreated(IncomingEvent incomingEvent) 
        {
            // Do whatever you want with incoming event (persist or process)
        }
    }
}

using Minor.WSA.EventBus.Dispatcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minor.WSA.EventBus.Config;
using Minor.Dag39.GamesBackend.Outgoing.Events;
using Minor.Dag39.GamesBackend.Incoming.Events;

namespace Minor.Dag39.GamesBackend.WebApi.Dispatchers
{
    public class RoomDispatcher : EventDispatcher {
        public RoomDispatcher(EventBusConfig config) : base(config) 
        {

        }

        public void OnRoomCreated(IncomingEvent incomingEvent) 
        {

        }
    }
}

using Minor.WSA.Commons;
using Minor.WSA.EventBus.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Minor.WSA.EventBus.Config;

namespace Minor.Dag39.GamesBackend.DAL.EventBus
{
    public class Publisher
        : EventPublisher
    {
        public Publisher(EventBusConfig config) : base(config)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag39.GamesBackend.Incoming
{
    public class BaseCommand
        : ICommand
    {
        public Guid CommandId { get; set; }

        public DateTime Timestamp { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag39.GamesBackend.Incoming.Commands
{
    public interface ICommand
    {
        Guid CommandId { get; set; }
        DateTime Timestamp { get; set; }
    }
}

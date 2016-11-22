using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag39.GamesBackend.Incoming
{
    public class CreateRoomCommand
        : BaseCommand
    {
        public string RoomName { get; set; }
    }
}

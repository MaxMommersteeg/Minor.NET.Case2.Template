﻿using System.Collections.Generic;

namespace Minor.Dag39.GamesBackend.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Running { get; set; }
        
        public int WinnerId { get; set; }
        public Player Winner { get; set; }

        public IList<Player> Players { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int Lives { get; set; }
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
    }
}

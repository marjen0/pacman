using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Pacman
    {
        public string Id { get; set; }
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        private int xStart { get; set; }
        private int yStart { get; set; }
        public int currentDirection { get; set; }
        public int nextDirection { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Coordinates
    {
        public long PlayerID { get; set; }
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }

        public Coordinates()
        {
        }
    }
}

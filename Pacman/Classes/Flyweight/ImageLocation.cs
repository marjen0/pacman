using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Flyweight
{
    public class ImageLocation : Flyweight
    {
        public override void SetX(int x)
        {
            point.X = x;
        }

        public override void SetY(int y)
        {
            point.Y = y;
        }

        public override Point GetPoint()
        {
            return point;
        }
    }
}

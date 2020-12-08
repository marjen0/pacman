using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Flyweight
{
    public abstract class Flyweight
    {
        protected Point point = new Point(0, 0);

        public abstract void SetX(int x);
        public abstract void SetY(int y);
        public abstract Point GetPoint();
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Flyweight
{
    public class ImageLocation
    {
        private static readonly ImageLocation singleObject = new ImageLocation();
        private Point point = new Point(0, 0);

        private ImageLocation()
        { }

        public void SetX(int x)
        {
            point.X = x;
        }

        public void SetY(int y)
        {
            point.Y = y;
        }

        public Point GetPoint()
        {
            return point;
        }

        public static ImageLocation GetInstance()
        {
            return singleObject;
        }
    }
}

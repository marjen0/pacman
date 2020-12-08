using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Flyweight
{
    public class ImageLocationFactory
    {
        private static Dictionary<int, ImageLocation> flyweights = new Dictionary<int, ImageLocation>();

        public static ImageLocation GetImageLocation(int x)
        {
            ImageLocation il = null;

            if (flyweights.ContainsKey(x))
                il = flyweights[x];
            else
            {
                il = new ImageLocation();
                il.SetX(x);
                flyweights.Add(x, il);
            }

            return il;
        }
    }
}

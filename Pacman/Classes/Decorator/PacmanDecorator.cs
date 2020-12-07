using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Decorator
{
    public abstract class PacmanDecorator : Pacman
    {
        private Pacman _wrappee;
        public PacmanDecorator(Pacman p)
        {
            _wrappee = p;
        }
        public override int AddPacmanImages()
        {
            _wrappee.AddPacmanImages();

            return PacmanImages.Images.Count;
        }
        public override bool Set_Pacman()
        {
            _wrappee.Set_Pacman();

            if (PacmanImage.Image != null)
                return true;
            else
                return false;
        }
    }
}

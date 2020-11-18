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
        public override void AddPacmanImages()
        {
            _wrappee.AddPacmanImages();
        }
        public override void Set_Pacman()
        {
            _wrappee.Set_Pacman();
        }

    }
}

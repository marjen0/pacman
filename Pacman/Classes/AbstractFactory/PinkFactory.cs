using Pacman.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes
{
    public class PinkFactory : AbstractFactory
    {
        public override Ghost CreateGhost()
        {
            return new PinkGhost();
        }

        public override Pacman CreatePacman(SignalR signalr, string id)
        {
            return new PinkPacman(signalr, id);
        }
    }
}

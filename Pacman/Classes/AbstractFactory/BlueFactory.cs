using Pacman.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes
{
    public class BlueFactory : AbstractFactory
    {
        public override Ghost CreateGhost()
        {
            return new BlueGhost();
        }

        public override Pacman CreatePacman(SignalR signalr, string id)
        {
            return new BluePacman(signalr, id);
        }
    }
}

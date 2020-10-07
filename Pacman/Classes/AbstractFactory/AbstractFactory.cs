using Pacman.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes
{
    public abstract class AbstractFactory
    {
        public abstract Pacman CreatePacman(SignalR signalr, string id);
        public abstract Ghost CreateGhost();
    }
}

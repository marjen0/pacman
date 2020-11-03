using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacman.Classes.Strategy
{
    public interface MoveAlgorithm
    {
        public void PlayerMoveSpeed(Pacman pacman);
    }
}

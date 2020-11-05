using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Strategy
{
    public class PlayerMoveFast : MoveAlgorithm
    {
        public void PlayerMoveSpeed(Pacman pacman)
        {
            pacman.GetTimer().Interval = 50;
            pacman.GetStateTimer().Start();
        }
    }
}

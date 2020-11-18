using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Strategy
{
    public class PlayerMoveSlow : MoveAlgorithm
    {
        public void PlayerMoveSpeed(Pacman pacman)
        {
            pacman.GetTimer().Interval = 200;
            pacman.GetStateTimer().Start();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.State
{
    public class NormalState : State
    {
        Ghost ghost;

        public NormalState(Ghost newGhost)
        {
            ghost = newGhost;
        }

        public void Killable()
        {
            AutoMessageBox.Show("Ghost is in normal state, you can't kill it", "Normal state", 2500);
        }

        public void Normal()
        {
            AutoMessageBox.Show("Ghost is now normal", "Normal state", 2500);
            ghost.SetState(ghost.GetStateKillable());
        }
    }
}

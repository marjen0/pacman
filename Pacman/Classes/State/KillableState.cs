using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.State
{
    public class KillableState : State
    {
        Ghost ghost;

        public KillableState(Ghost newGhost)
        {
            ghost = newGhost;
        }

        public void Killable()
        {
            AutoMessageBox.Show("Ghost is now killable", "Killable state", 2500);
        }

        public void Normal()
        {
            AutoMessageBox.Show("Ghosts switching to normal state", "Killable state", 2500);
            ghost.SetState(ghost.GetStateNormal());
        }
    }
}

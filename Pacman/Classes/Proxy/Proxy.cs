using Pacman.Classes.State;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Proxy
{
    class Proxy : Subject
    {
        private Ghost _ghost;

        public Proxy(Ghost ghost)
        {
            _ghost = ghost;
        }

        public void CreateGhostImage(Form form)
        {
            _ghost.CreateGhostImage(form);
            AutoMessageBox.Show("Using proxy to create ghosts", "Proxy", 1500);
        }

        public void DisableTimer()
        {
            _ghost.DisableTimer();
        }

        public void EnableTimer()
        {
            _ghost.EnableTimer();
        }
    }
}

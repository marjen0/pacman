using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Pacman.Classes.Bridge
{
    public abstract class Implementor 
    {
        public abstract void CreateGhostImage(Form formInstance);
        public abstract void Set_Ghosts();
        public abstract void ResetGhosts();
    }
}

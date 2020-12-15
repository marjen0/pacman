using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Proxy
{
    public interface Subject
    {
        void CreateGhostImage(Form form);
        void DisableTimer();
        void EnableTimer();
    }
}

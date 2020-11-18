using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Command
{
    public interface Command
    {
        public void execute();
        public void undo();
    }
}

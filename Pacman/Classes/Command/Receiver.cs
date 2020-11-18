using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Command
{
    public interface Receiver
    {
        public void MoveUp();
        public void MoveDown();
        public void MoveLeft();
        public void MoveRight();
    }
}

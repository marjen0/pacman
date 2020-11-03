using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Command
{
    public class MoveLeftCommand : Command
    {
        Receiver receiver;

        public MoveLeftCommand(Receiver r)
        {
            receiver = r;
        }

        public void execute()
        {
            receiver.MoveLeft();
            //MessageBox.Show("Left");
        }

        public void undo()
        {
            receiver.MoveRight();
        }
    }
}

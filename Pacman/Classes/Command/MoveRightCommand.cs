using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Command
{
    public class MoveRightCommand : Command
    {
        Receiver receiver;

        public MoveRightCommand(Receiver r)
        {
            receiver = r;
        }

        public void execute()
        {
            receiver.MoveRight();
            //MessageBox.Show("Right");
        }

        public void undo()
        {
            receiver.MoveLeft();
        }
    }
}

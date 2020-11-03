using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Command
{
    public class MoveUpCommand : Command
    {
        Receiver receiver;

        public MoveUpCommand(Receiver r)
        {
            receiver = r;
        }

        public void execute()
        {
            receiver.MoveUp();
            //MessageBox.Show("Up");
        }

        public void undo()
        {
            receiver.MoveDown();
        }
    }
}

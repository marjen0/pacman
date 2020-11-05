using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Command
{
    public class MoveDownCommand : Command
    {
        Receiver receiver;

        public MoveDownCommand(Receiver r)
        {
            receiver = r;
        }

        public void execute()
        {
            receiver.MoveDown();
            //MessageBox.Show("Down");
        }

        public void undo()
        {
            receiver.MoveUp();
        }
    }
}

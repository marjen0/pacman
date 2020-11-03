using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Command
{
    public class Invoker
    {
        Command[] commands = new Command[5];
        int position;

        public Invoker()
        {
            position = -1;
        }

        public void SetCommand(Command c)
        {
            if (position < commands.Length - 1)
            {
                position++;
                commands[position] = c;
            }
            else
            {
                for (int i = 0; i < commands.Length - 2; i++)
                {
                    commands[i] = commands[i + 1];
                }
                commands[commands.Length - 1] = c;
            }
        }

        public void run()
        {
            commands[position].execute();
        }

        public void undo()
        {
            if (position >= 0)
            {
                commands[position].undo();
            }
            position--;
        }
    }
}

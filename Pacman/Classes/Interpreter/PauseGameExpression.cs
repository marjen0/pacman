using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Interpreter
{
    class PauseGameExpression : Expression
    {
        public override void Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.Equals("p") && Form1.players.GetCount() > 1)
            {
                if (Form1.pacmansList.Single(p => p.Id == Form1._hubConnection.ConnectionId).IsTimerEnabled() &&
                    Form1.ghost.IsTimerEnabled())
                {
                    Form1.pacmansList.Single(p => p.Id == Form1._hubConnection.ConnectionId).StopTimer();
                    Form1.ghost.StopTimer();
                }
                else
                {
                    Form1.pacmansList.Single(p => p.Id == Form1._hubConnection.ConnectionId).StartTimer();
                    Form1.ghost.StartTimer();
                }
            }
        }
    }
}

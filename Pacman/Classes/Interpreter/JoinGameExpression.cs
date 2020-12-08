using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Interpreter
{
    class JoinGameExpression : Expression
    {
        public override void Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.Equals("f1") && Form1.players.GetCount() < 2)
            {
                Form1._signalR.ConnectPlayer().GetAwaiter();
            }
        }
    }
}

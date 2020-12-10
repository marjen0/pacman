using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Interpreter
{
    public class JoinGameExpression : Expression
    {
        public override bool Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return false;

            if (context.Input.Equals("f1") && Form1.players.GetCount() < 2)
            {
                if (Form1._signalR != null)
                    Form1._signalR.ConnectPlayer().GetAwaiter();

                return true;
            }
            
            return false;
        }
    }
}

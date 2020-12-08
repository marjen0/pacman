using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Interpreter
{
    class QuitGameExpression : Expression
    {
        public override void Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return;

            if (context.Input.Equals("q"))
            {
                Form1.ActiveForm.Close();
            }
        }
    }
}

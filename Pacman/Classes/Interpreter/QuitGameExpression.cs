using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Interpreter
{
    public class QuitGameExpression : Expression
    {
        public override bool Interpret(Context context)
        {
            if (context.Input.Length == 0)
                return false;

            if (context.Input.Equals("q"))
            {
                if (Form1.ActiveForm != null)
                    Form1.ActiveForm.Close();

                return true;
            }
            
            return false;
        }
    }
}

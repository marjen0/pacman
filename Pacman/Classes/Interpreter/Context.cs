using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Interpreter
{
    public class Context
    {
        private string _input;

        public Context()
        {
            _input = "";
        }

        public Context(string input)
        {
            _input = input;
        }

        public string Input
        {
            get { return _input; }
            set { _input = value; }
        }
    }
}

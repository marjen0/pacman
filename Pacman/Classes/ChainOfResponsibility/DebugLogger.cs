using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman.Classes.Adapter;

namespace Pacman.Classes.ChainOfResponsibility
{
    class DebugLogger : AbstractLogger
    {
        private Form1 _form;
        public override Form1 Form { get => _form; set => _form = value; }
        public DebugLogger(Form1 form, int logLevel): base(logLevel)
        {
            _form = form;
        }

        public override void LogData(string message)
        {
            _form.formElements.DebugLog.AppendText(string.Format("{0}\n", message));
        }
    }
}

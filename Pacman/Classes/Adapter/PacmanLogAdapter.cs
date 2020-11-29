using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Adapter
{
    public class PacmanLogAdapter : ILog
    {
        private Form1 _form;
        private Pacman _adaptee;
        public PacmanLogAdapter(Pacman p, Form1 form)
        {
            _form = form;
            _adaptee = p;
        }
        public void LogData(string message)
        {
            _adaptee.LogDataToRichTextBox(_form);
        
        }

        public string getPacmanId()
        {
            return _adaptee.Id;
        }
    }
}

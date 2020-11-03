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
        private Pacman _adaptee;
        public PacmanLogAdapter(Pacman p)
        {
           
            _adaptee = p;
        }
        public void LogData(string message)
        {
            _adaptee.LogDataToRichTextBox();
        
        }

        public string getPacmanId()
        {
            return _adaptee.Id;
        }
    }
}

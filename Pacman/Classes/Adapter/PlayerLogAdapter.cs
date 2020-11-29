using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Adapter
{
    public class PlayerLogAdapter : ILog
    {
        private Form1 _form;
        private Player _adaptee;

        public PlayerLogAdapter(Player p, Form1 form)
        {
            _form = form;
            _adaptee = p;
        }
        public void LogData(string message)
        {
            _adaptee.LogDataToRichTextBox(_form);
        }
        public string getPlayerId()
        {
            return _adaptee.Id;
        }
    }
}

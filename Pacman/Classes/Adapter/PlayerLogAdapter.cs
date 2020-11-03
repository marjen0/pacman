using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Adapter
{
    public class PlayerLogAdapter : ILog
    {
        private Player _adaptee;

        public PlayerLogAdapter(Player p)
        {
            _adaptee = p;
        }
        public void LogData(string message)
        {
            _adaptee.LogDataToRichTextBox();
        }
        public string getPlayerId()
        {
            return _adaptee.Id;
        }
    }
}

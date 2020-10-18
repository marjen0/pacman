using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Adapter
{
    public class PlayerLogAdapter : ILogAdapter
    {
        private Player _player;

        public PlayerLogAdapter(Player p)
        {
            _player = p;
        }
        public string LogData()
        {
            return _player.ToString();
        }
        public string getPlayerId()
        {
            return _player.Id;
        }
    }
}

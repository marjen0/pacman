using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Adapter
{
    public class PacmanLogAdapter : ILogAdapter
    {
        private Pacman _pacman;
        public PacmanLogAdapter(Pacman p)
        {
            _pacman = p;
        }
        public string LogData()
        {
            return _pacman.ToString();
        }

        public string getPacmanId()
        {
            return _pacman.Id;
        }
    }
}

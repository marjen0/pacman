using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Observer
{
    public interface IObserver
    {
        public void UpdateLives(int lives);
        public void UpdateHighScore(int amount);
    }
}

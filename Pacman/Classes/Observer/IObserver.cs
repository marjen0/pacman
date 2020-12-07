using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Observer
{
    public interface IObserver
    {
        void UpdateLives(int lives);
        void UpdateHighScore(int amount);
    }
}

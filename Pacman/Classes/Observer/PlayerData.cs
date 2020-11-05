using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Observer
{
    public sealed class PlayerData : ISubject
    {
        private static readonly PlayerData instance = new PlayerData();
        public List<IObserver> observers = new List<IObserver>();
        private int Lives;
        private int Amount;

        private PlayerData()
        { }

        public static PlayerData GetInstance()
        {
            return instance;
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.UpdateLives(Lives);
                o.UpdateHighScore(Amount);
            }
        }

        public void EditLives(int lives)
        {
            Lives = lives;
            NotifyObservers();
        }

        public void EditHighScore(int score)
        {
            Amount = score;
            NotifyObservers();
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }
    }
}

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

        public bool NotifyObservers()
        {
            bool ok = true;

            foreach (IObserver o in observers)
            {
                if (o != null)
                {
                    bool updatedLives = o.UpdateLives(Lives);
                    bool updatedHighScore = o.UpdateHighScore(Amount);

                    if (!updatedLives || !updatedHighScore)
                        ok = false;
                }
            }

            return ok;
        }

        public void EditLives(int lives)
        {
            Lives = lives;
            NotifyObservers();
        }

        public int GetLives()
        {
            return Lives;
        }

        public void EditHighScore(int score)
        {
            Amount = score;
            NotifyObservers();
        }

        public int GetHighScore()
        {
            return Amount;
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void RemoveObservers()
        {
            for (int i = 0; i < observers.Count; i++)
                observers.RemoveAt(i);
        }
    }
}

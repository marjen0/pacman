using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Iterator
{
    public class Players : IEnumerable
    {
        private Player[] players = new Player[2];
        private int number = 0;

        public Players()
        { }

        public void Add(Player p)
        {
            players[number++] = p;
        }

        public Player[] GetPlayers()
        {
            return players;
        }

        public int GetCount()
        {
            return number;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < players.Count(); i++)
                yield return players[i];
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Iterator
{
    public class PlayersIterator : IEnumerator
    {
        private Player[] players;
        private int position = -1;

        public PlayersIterator(Player[] p)
        {
            players = p;
        }

        public bool MoveNext()
        {
            position++;
            return position < players.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Player Current
        {
            get
            {
                try
                {
                    return players[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}

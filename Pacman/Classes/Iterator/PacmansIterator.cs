using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Iterator
{
    public class PacmansIterator : IEnumerator
    {
        private int position = -1;
        private List<Pacman> pacmans;

        public PacmansIterator(List<Pacman> p)
        {
            pacmans = p;
        }

        public bool MoveNext()
        {
            position++;
            return position < pacmans.Count;
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

        public Pacman Current
        {
            get
            {
                try
                {
                    return pacmans.ElementAt(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}

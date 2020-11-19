﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.Iterator
{
    public class Pacmans : IEnumerable
    {
        private List<Pacman> pacmans = new List<Pacman>();

        public Pacmans()
        { }

        public void Add(Pacman p)
        {
            pacmans.Add(p);
        }

        public List<Pacman> GetPacmans()
        {
            return pacmans;
        }

        public int GetCount()
        {
            return pacmans.Count;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return new PacmansIterator(pacmans);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Interpreter
{
    abstract class Expression
    {
        public abstract void Interpret(Context context);
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.FactoryMethod
{
    public abstract class FoodCreator
    {
        public abstract Food CreateFood();
    }
}

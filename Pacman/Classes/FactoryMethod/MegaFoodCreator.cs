using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Classes.FactoryMethod
{
    public class MegaFoodCreator : FoodCreator
    {
        public override Food CreateFood()
        {
            return new MegaFood();
        }
    }
}

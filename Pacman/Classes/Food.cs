using Pacman.Classes.Strategy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public abstract class Food
    {
        public abstract int Amount { get; set; }
        public abstract int FoodScore { get; set; }
        public abstract int SuperFoodScore { get; set; }
        public abstract string Type { get; set; }
        public abstract void CreateFoodImages(Form formInstance);
        public abstract void EatFood(int x, int y);
        //public abstract void EatSuperFood(int x, int y);
        public abstract PictureBox[,] FoodImage { get; set; }// = new PictureBox[30,27];

        private MoveAlgorithm moveAlgorithm;

        public Food()
        {

        }

        public void SetMoveAlgorithm(MoveAlgorithm algorithm)
        {
            moveAlgorithm = algorithm;
        }

        public void PlayerMoveSpeed(Pacman pacman)
        {
            moveAlgorithm.PlayerMoveSpeed(pacman);
        }
    }
}

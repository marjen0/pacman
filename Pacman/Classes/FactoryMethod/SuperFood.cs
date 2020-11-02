using Pacman.Classes.Strategy;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.FactoryMethod
{
    class SuperFood : Food
    {
        private string _type;
        private int _amount;
        private int _foodScore;
        private int _superFoodScore;
        private PictureBox[,] _foodImage;
        public override PictureBox[,] FoodImage { get => _foodImage; set => _foodImage = value; }
        public override int Amount { get => _amount; set => _amount = value; }
        public override int FoodScore { get => _foodScore; set => _foodScore = value; }
        public override string Type { get => _type; set => _type = value; }
        public override int SuperFoodScore { get => _superFoodScore; set => _superFoodScore = value; }

        public SuperFood()
        {
            _type = "SuperFood";
            _foodImage = new PictureBox[30, 27];
            //Set moveSlowAlgorithm when player eats super candy
            SetMoveAlgorithm(new PlayerMoveSlow());
        }
        public override void CreateFoodImages(Form formInstance)
        {
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 27; x++)
                {
                    if (Form1.gameboard.Matrix[y, x] == 2)
                    {
                        FoodImage[y, x] = new PictureBox();
                        FoodImage[y, x].Name = "FoodImage" + Amount.ToString();
                        FoodImage[y, x].SizeMode = PictureBoxSizeMode.AutoSize;
                        FoodImage[y, x].Location = new Point(x * 16 - 1, y * 16 + 47);

                        if (Form1.gameboard.Matrix[y, x] != 1)
                        {
                            FoodImage[y, x].Image = Properties.Resources.Block_2;
                        }

                        formInstance.Controls.Add(FoodImage[y, x]);
                        FoodImage[y, x].BringToFront();

                    }
                }
            }
        }

        public override void EatFood(int x, int y)
        {
            // Eat food
            FoodImage[x, y].Visible = false;
            Form1.gameboard.Matrix[x, y] = 0;
            Form1.player.UpdateScore(SuperFoodScore);
            Form1.ghost.ChangeGhostState();
        }

        //public override void EatSuperFood(int x, int y)
        //{
        //    // Eat food
        //    FoodImage[x, y].Visible = false;
        //    Form1.gameboard.Matrix[x, y] = 0;
        //    Form1.player.UpdateScore(SuperFoodScore);
        //    Form1.ghost.ChangeGhostState();
        //}
    }
}

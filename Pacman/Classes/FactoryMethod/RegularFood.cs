using Pacman.Classes.Flyweight;
using Pacman.Classes.Strategy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.FactoryMethod
{
    public class RegularFood : Food
    {
        private int _foodScore;
        private int _superFoodScore;
        private int _amount;
        private string _type;
        private PictureBox[,] _foodImage;

        public override PictureBox[,] FoodImage { get => _foodImage; set => _foodImage = value; }
        public override int Amount { get => _foodScore; set => _foodScore = value; }
        public override int FoodScore { get => _amount; set => _amount = value; }
        public override string Type { get => _type; set => _type = value; }
        public override int SuperFoodScore { get => _superFoodScore; set => _superFoodScore = value; }

        public RegularFood()
        {
            _foodImage = new PictureBox[30, 27];
            _type = "RegularFood";
        }

        public override void CreateFoodImages(Form formInstance)
        {
            var point = ImageLocation.GetInstance();

            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 27; x++)
                {
                    if (Form1.gameboard.Matrix[y, x] == 1)
                    {
                        FoodImage[y, x] = new PictureBox();
                        FoodImage[y, x].Name = "FoodImage" + Amount.ToString();
                        FoodImage[y, x].SizeMode = PictureBoxSizeMode.AutoSize;

                        // Replaced with Flyweight Pattern -->
                        //FoodImage[y, x].Location = new Point(x * 16 - 1, y * 16 + 47);
                        // <-- Replaced with Flyweight Pattern

                        // Flyweight Pattern -->
                        point.SetX(x * 16 - 1);
                        point.SetY(y * 16 + 47);
                        FoodImage[y, x].Location = point.GetPoint();
                        // <-- Flyweight Pattern

                        if (Form1.gameboard.Matrix[y, x] == 1)
                        {
                            FoodImage[y, x].Image = Properties.Resources.Block_1;
                            Amount++;
                        }
                        //else
                        //{
                        //    FoodImage[y, x].Image = Properties.Resources.Block_2;
                        //}

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
            //Form1.player.UpdateScore(FoodScore);
            Form1.playerData.EditHighScore(100);
            Amount--;
            if (Amount < 1) { Form1.player.LevelComplete(); }
            //Form1.audio.Play(1);
        }

        //public override void EatSuperFood(int x, int y)
        //{
        //    // Eat food
        //    FoodImage[x, y].Visible = false;
        //    Form1.gameboard.Matrix[x, y] = 0;
        //    //Form1.player.UpdateScore(SuperFoodScore);
        //    Form1.playerData.EditHighScore(300);
        //    Form1.ghost.ChangeGhostState();
        //}
    }
}

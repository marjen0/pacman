﻿using Pacman.Classes.Flyweight;
using Pacman.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes
{
    public class PinkPacman : Pacman
    {
        public PinkPacman(string id)
        {
            Id = id;
            _signalR = null;
        }
        public PinkPacman(SignalR signalr, string id)
        {
            _signalR = signalr;
            Id = id;
        }

        override public int AddPacmanImages()
        {
            
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_1_0);
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_1_1);
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_1_2);
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_1_3);

            PacmanImages.Images.Add(Properties.Resources.PinkPacman_2_0);
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_2_1);
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_2_2);
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_2_3);

            PacmanImages.Images.Add(Properties.Resources.PinkPacman_3_0);
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_3_1);
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_3_2);
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_3_3);

            PacmanImages.Images.Add(Properties.Resources.PinkPacman_4_0);
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_4_1);
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_4_2);
            PacmanImages.Images.Add(Properties.Resources.PinkPacman_4_3);

            return PacmanImages.Images.Count;
        }

        public override bool Set_Pacman()
        {
            PacmanImage.Image = Properties.Resources.PinkPacman_2_1;

            if (PacmanImage.Image != null)
            {
                currentDirection = 0;
                nextDirection = 0;
                xCoordinate = xStart;
                yCoordinate = yStart;
                var point = ImageLocationFactory.GetImageLocation(xStart * 16 - 3);
                point.SetY(yStart * 16 + 43);
                PacmanImage.Location = point.GetPoint();

                return true;
            }

            return false;
        }
    }
}

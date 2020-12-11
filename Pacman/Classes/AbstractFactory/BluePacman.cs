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
    public class BluePacman : Pacman
    {
        public BluePacman(string id)
        {
            Id = id;
            _signalR = null;
        }

        public BluePacman(SignalR signalr, string id)
        {
            _signalR = signalr;
            Id = id;
        }

        public override int AddPacmanImages()
        {
            PacmanImages.Images.Add(Properties.Resources.BluePacman_1_0);
            PacmanImages.Images.Add(Properties.Resources.BluePacman_1_1);
            PacmanImages.Images.Add(Properties.Resources.BluePacman_1_2);
            PacmanImages.Images.Add(Properties.Resources.BluePacman_1_3);

            PacmanImages.Images.Add(Properties.Resources.BluePacman_2_0);
            PacmanImages.Images.Add(Properties.Resources.BluePacman_2_1);
            PacmanImages.Images.Add(Properties.Resources.BluePacman_2_2);
            PacmanImages.Images.Add(Properties.Resources.BluePacman_2_3);

            PacmanImages.Images.Add(Properties.Resources.BluePacman_3_0);
            PacmanImages.Images.Add(Properties.Resources.BluePacman_3_1);
            PacmanImages.Images.Add(Properties.Resources.BluePacman_3_2);
            PacmanImages.Images.Add(Properties.Resources.BluePacman_3_3);

            PacmanImages.Images.Add(Properties.Resources.BluePacman_4_0);
            PacmanImages.Images.Add(Properties.Resources.BluePacman_4_1);
            PacmanImages.Images.Add(Properties.Resources.BluePacman_4_2);
            PacmanImages.Images.Add(Properties.Resources.BluePacman_4_3);

            return PacmanImages.Images.Count;
        }

        public override void Set_Pacman()
        {
            PacmanImage.Image = Properties.Resources.BluePacman_2_1;
            currentDirection = 0;
            nextDirection = 0;
            xCoordinate = xStart;
            yCoordinate = yStart;
            var point = ImageLocationFactory.GetImageLocation(xStart * 16 - 3);
            point.SetY(yStart * 16 + 43);
            PacmanImage.Location = point.GetPoint();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Pacman.Classes.Flyweight;

namespace Pacman.Classes.Bridge
{
    public class GhostImg : Implementor
    {
        private const int GhostAmount = 4;
        public int Ghosts = GhostAmount;
        private ImageList GhostImages = new ImageList();
        public PictureBox[] GhostImage = new PictureBox[GhostAmount];
        public int[] State = new int[GhostAmount];
        public int[] xCoordinate = new int[GhostAmount];
        public int[] yCoordinate = new int[GhostAmount];
        private int[] xStart = new int[GhostAmount];
        private int[] yStart = new int[GhostAmount];
        public int[] Direction = new int[GhostAmount];

        public override void CreateGhostImage(Form formInstance)
        {
            for (int x = 0; x < Ghosts; x++)
            {
                GhostImage[x] = new PictureBox();
                GhostImage[x].Name = "GhostImage" + x.ToString();
                GhostImage[x].SizeMode = PictureBoxSizeMode.AutoSize;
                formInstance.Controls.Add(GhostImage[x]);
                GhostImage[x].BringToFront();
            }

            Set_Ghosts();
            ResetGhosts();
        }

        public override void Set_Ghosts()
        {
            // Find Ghost locations
            int Amount = -1;

            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 27; x++)
                {
                    if (Form1.gameboard.Matrix[y, x] == 15)
                    {
                        Amount++;
                        xStart[Amount] = x;
                        yStart[Amount] = y;
                    }
                }
            }
        }

        public override void ResetGhosts()
        {
            // Reset Ghost States
            for (int x = 0; x < GhostAmount; x++)
            {
                xCoordinate[x] = xStart[x];
                yCoordinate[x] = yStart[x];
                var point = ImageLocationFactory.GetImageLocation(xStart[x] * 16 - 3);
                point.SetY(yStart[x] * 16 + 43);
                GhostImage[x].Location = point.GetPoint();
                GhostImage[x].Image = GhostImages.Images[x * 4];
                Direction[x] = 0;
                State[x] = 0;
            }
        }
    }
}

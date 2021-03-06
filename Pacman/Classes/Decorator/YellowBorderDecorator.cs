﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Decorator
{
    public class YellowBorderDecorator: PacmanDecorator
    {
        public YellowBorderDecorator(Pacman decoratedPacman) : base(decoratedPacman)
        {

        }
        public override void AddPacmanImages()
        {
            base.AddPacmanImages();
            AddYellowBorder(PacmanImages);
        }
        public override void Set_Pacman()
        {
            base.Set_Pacman();
        }
        private void AddYellowBorder(ImageList images)
        {

            foreach (Image image in images.Images)
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawRectangle(new Pen(Brushes.Yellow, 5), new Rectangle(0, 0, image.Width, image.Height));
                }
            }
        }
    }
}

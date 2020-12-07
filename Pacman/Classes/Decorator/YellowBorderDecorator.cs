using System;
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
        public override int AddPacmanImages()
        {
            base.AddPacmanImages();
            AddYellowBorder(PacmanImages);

            return PacmanImages.Images.Count;
        }
        public override bool Set_Pacman()
        {
            base.Set_Pacman();

            if (PacmanImage.Image != null)
                return true;
            else
                return false;
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

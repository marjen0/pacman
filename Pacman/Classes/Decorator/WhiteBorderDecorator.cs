using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Decorator
{
    class WhiteBorderDecorator : PacmanDecorator
    {
        public WhiteBorderDecorator(Pacman decoratedPacman) : base(decoratedPacman)
        {

        }
        public override int AddPacmanImages()
        {
            base.AddPacmanImages();
            AddWhiteBorder(PacmanImages);

            return PacmanImages.Images.Count;
        }
        public override void Set_Pacman()
        {
            base.Set_Pacman();
        }
        private void AddWhiteBorder(ImageList images)
        {

            foreach (Image image in images.Images)
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawRectangle(new Pen(Brushes.White, 5), new Rectangle(0, 0, image.Width, image.Height));
                }
            }
        }
    }
}

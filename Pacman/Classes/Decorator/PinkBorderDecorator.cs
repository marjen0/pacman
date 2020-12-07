using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Decorator
{
    public class PinkBorderDecorator : PacmanDecorator
    {
        public PinkBorderDecorator(Pacman decoratedPacman) : base(decoratedPacman)
        {
            
        }
        public override int AddPacmanImages()
        {
            base.AddPacmanImages();
            AddPinkBorder(PacmanImages);

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
        private void AddPinkBorder(ImageList images)
        {
            
            foreach (Image image in images.Images)
            {
                using (Graphics g = Graphics.FromImage(image))
                {
                    g.DrawRectangle(new Pen(Brushes.Pink, 5), new Rectangle(0, 0, image.Width, image.Height));
                }
                image.Save(string.Format(@"D:\Desktop\image{0}.jpg", new Random().Next()));
            }
        }
    }
}

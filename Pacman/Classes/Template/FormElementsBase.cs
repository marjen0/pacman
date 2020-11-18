using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Template
{
    public abstract class FormElementsBase
    {
        public virtual void CreateFormElements(Form form) {
            throw new NotImplementedException();
        }
    }
}

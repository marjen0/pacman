using System.Windows.Forms;

namespace Pacman.Classes.Template
{
    public abstract class FormElements : FormElementsBase
    {
        public abstract bool AddLogBox { get; set; }
        public abstract Label PlayerOneScoreText { get; set; }
        public abstract Label HighScoreText { get; set; }
        public abstract RichTextBox Log { get; set; }
        public sealed override void CreateFormElements(Form formInstance)
        {
            CreatePlayerOneScoreLabel(formInstance);
            if (AddLogBox)
            {
                CreateLogBox(formInstance);
            }
            CreateHighScoreLabel(formInstance);
            
        }
        public abstract void CreatePlayerOneScoreLabel(Form formInstance);
        public abstract void CreateHighScoreLabel(Form formInstance);
        public abstract void CreateLogBox(Form formInstance);
       
    }
}

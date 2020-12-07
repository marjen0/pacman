using System.Windows.Forms;

namespace Pacman.Classes.Template
{
    public abstract class FormElements : FormElementsBase
    {
        public abstract bool AddLogBox { get; set; }
        public abstract Label PlayerOneScoreText { get; set; }
        public abstract Label HighScoreText { get; set; }
        public abstract Label NotJoinedText { get; set; }
        public abstract RichTextBox Log { get; set; }
        public abstract RichTextBox DebugLog { get; set; }

        public sealed override void CreateFormElements(Form formInstance)
        {
            CreatePlayerOneScoreLabel(formInstance);
            if (AddLogBox)
            {
                CreateLogBox(formInstance);
                CreateDebugLogBox(formInstance);
            }
            CreateHighScoreLabel(formInstance);
            CreateNotJoinedLabel(formInstance);
            
        }
        public abstract void CreatePlayerOneScoreLabel(Form formInstance);
        public abstract void CreateHighScoreLabel(Form formInstance);
        public abstract void CreateLogBox(Form formInstance);
        public abstract void CreateDebugLogBox(Form formInstance);
        public abstract void CreateNotJoinedLabel(Form formInstance);

    }
}

using System.Windows.Forms;

namespace DataAccessLayer
{
    public class FormElements
    {
        public Label PlayerOneScoreText = new Label();
        public Label HighScoreText = new Label();
        public RichTextBox Log = new RichTextBox();
        public void CreateFormElements(Form formInstance)
        {
            PlayerOneScoreText.ForeColor = System.Drawing.Color.White;
            PlayerOneScoreText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            PlayerOneScoreText.Top = 5;
            PlayerOneScoreText.Left = 20;
            PlayerOneScoreText.Height = 20;
            PlayerOneScoreText.Width = 100;
            PlayerOneScoreText.Text = "1UP";
            formInstance.Controls.Add(PlayerOneScoreText);

            HighScoreText.ForeColor = System.Drawing.Color.White;
            HighScoreText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            HighScoreText.Top = 5;
            HighScoreText.Left = 155;
            HighScoreText.Height = 20;
            HighScoreText.Width = 200;
           
            HighScoreText.Text = "HIGH SCORE";
            formInstance.Controls.Add(HighScoreText);

            Log.Height = 500;
            Log.Width = 345;
            Log.Top = 5;
            Log.Left = 475;
            Log.Enabled = false;
            formInstance.Controls.Add(Log);
        }
    }
}

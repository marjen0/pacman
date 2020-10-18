using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Pacman.Classes.Observer;

namespace Pacman
{
    public class HighScore : IObserver
    {
        public const int InitalScore = 100;
        public Label HighScoreText = new Label();
        public int Score = InitalScore;

        public void CreateHighScore(Form formInstance)
        {
            // Create Score label
            HighScoreText.ForeColor = System.Drawing.Color.White;
            HighScoreText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            HighScoreText.Top = 23;
            HighScoreText.Left = 170;
            HighScoreText.Height = 20;
            HighScoreText.Width = 100;
            formInstance.Controls.Add(HighScoreText);
            HighScoreText.BringToFront();
            UpdateScore();
        }

        public void UpdateScore(int value = InitalScore)
        {
            Score = value;
            HighScoreText.Text = Score.ToString();
        }

        public void UpdateLives(int lives)
        { }

        public void UpdateHighScore(int amount)
        {
            
        }
    }
}

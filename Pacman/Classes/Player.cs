using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Pacman.Classes.Observer;
using Pacman.Classes.Flyweight;

namespace Pacman
{
    public class Player : IObserver
    {
        public string Id { get; set; }
        public string Name { get; set; }

        private const int MaxLives = 10;
        
        public int Score = 0;
        public int Lives = 3;
        public Label ScoreText = new Label();
        public PictureBox[] LifeImage = new PictureBox[MaxLives];

        public Player() { }

        public Player(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public void CreateLives(Form formInstance)
        {
            for(int x = 0; x < MaxLives; x++)
            {
                LifeImage[x] = new PictureBox();
                LifeImage[x].Name = "Life" + x.ToString();
                LifeImage[x].SizeMode = PictureBoxSizeMode.AutoSize;

                var point = ImageLocationFactory.GetImageLocation(x * 30 + 3);
                point.SetY(550);
                LifeImage[x].Location = point.GetPoint();

                LifeImage[x].Image = Properties.Resources.Life;
                formInstance.Controls.Add(LifeImage[x]);
                LifeImage[x].BringToFront();
            }

            SetLives();
        }

        public void CreatePlayerDetails(Form formInstance)
        {
            // Create Score label
            ScoreText.ForeColor = System.Drawing.Color.White;
            ScoreText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            ScoreText.Top = 23;
            ScoreText.Left = 30;
            ScoreText.Height = 20;
            ScoreText.Width = 100;
            formInstance.Controls.Add(ScoreText);
            ScoreText.BringToFront();
            UpdateScore(0);
        }

        public void UpdateScore(int amount = 1)
        {
            // Update score value and text
            Score += amount;
            ScoreText.Text = Score.ToString();
            if (Score > Form1.highscore.Score) {
                //Form1.highscore.UpdateHighScore(Score);
                Form1.highscore.UpdateScore(Score);
            }
        }

        public void SetLives()
        {
            // Display lives in form
            for (int x = Lives - 1; x < MaxLives; x++)
                LifeImage[x].Visible = false;

            for (int x = 0; x < Lives; x++)
                LifeImage[x].Visible = true;
        }

        public void LoseLife()
        {
            // Lose a life
            if (Form1.playerData != null)
                Form1.playerData.EditLives(Lives - 1);

            if (Lives > 0)
            {
                if (Form1.pacman != null)
                    Form1.pacman.Set_Pacman();

                if (Form1.ghost != null)
                    Form1.ghost.ResetGhosts();

                SetLives();
            }
            else
            {
                //Application.Exit();

                // FOR TESTING
                Lives = 3;
                SetLives();
                // FOR TESTING
            }
        }

        public void LevelComplete()
        {
            Application.Exit();
        }

        public bool UpdateLives(int lives)
        {
            Lives = lives;

            if (Lives == lives)
                return true;

            return false;
        }

        public bool UpdateHighScore(int amount)
        {
            UpdateScore(amount);

            if (Score == amount)
                return true;

            return false;
        }

        public override string ToString()
        {
            return $"Player - Id:{Id} | Name:{Name} | Score:{Score} | Lives:{Lives}\n";
        }

        public void LogDataToRichTextBox(Form1 form)
        {
            form.formElements.Log.AppendText(string.Format("{0}\n", this.ToString()));
        }
    }
}

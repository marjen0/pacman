using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pacman.Classes.Observer;
using System.Drawing;

namespace Pacman.Classes.Facade
{
    public class GameDetailFacade
    {
        protected FormElements _formElements;
        protected GameBoard _gameBoard;
        protected HighScore _highscore;

        //Game board
        public PictureBox BoardImage = new PictureBox();
        public int[,] Matrix = new int[30, 27];

        //Highscore
        public const int InitalScore = 100;
        public Label HighScoreText = new Label();
        public int Score = InitalScore;

        //Form elements
        public Label PlayerOneScoreText = new Label();
        public RichTextBox Log = new RichTextBox();

        public GameDetailFacade()
        {
            this._formElements = new FormElements();
            this._gameBoard = new GameBoard();
            this._highscore = new HighScore();
        }
        public void CreateBoardImage(Form formInstance, int Level)
        {
            // Create Board Image
            BoardImage.Name = "BoardImage";
            BoardImage.SizeMode = PictureBoxSizeMode.AutoSize;
            BoardImage.Location = new Point(0, 50);
            switch (Level)
            {
                case 1: BoardImage.Image = Properties.Resources.Board_1; break;
            }
            formInstance.Controls.Add(BoardImage);
        }

        public Tuple<int, int> InitialiseBoardMatrix(int Level)
        {
            // Initialise Game Board Matrix
            switch (Level)
            {
                case 1:
                    Matrix = new int[,] {
                        { 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,10,10,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,01,10 },
                        { 10,02,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,02,10 },
                        { 10,01,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,01,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,01,10 },
                        { 10,01,01,01,01,01,01,10,10,01,01,01,01,10,10,01,01,01,01,10,10,01,01,01,01,01,01,10 },
                        { 10,10,10,10,10,10,01,10,10,10,10,10,00,10,10,00,10,10,10,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,10,10,10,00,10,10,00,10,10,10,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,00,00,00,00,00,00,00,00,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,11,11,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,15,15,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 00,00,00,00,00,00,01,00,00,00,10,10,10,15,15,10,10,10,00,00,00,01,00,00,00,00,00,00 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,10,10,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,10,10,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,03,00,00,00,00,00,00,00,00,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,10,10,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,10,10,10,10,10,01,10,10,00,10,10,10,10,10,10,10,10,00,10,10,01,10,10,10,10,10,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,10,10,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,01,10,10,10,10,10,01,10,10,01,10,10,10,10,10,01,10,10,10,10,01,10 },
                        { 10,02,01,01,10,10,01,01,01,01,01,01,01,00,00,01,01,01,01,01,01,01,10,10,01,01,02,10 },
                        { 10,10,10,01,10,10,01,10,10,01,10,10,10,10,10,10,10,10,01,10,10,01,10,10,01,10,10,10 },
                        { 10,10,10,01,10,10,01,10,10,01,10,10,10,10,10,10,10,10,01,10,10,01,10,10,01,10,10,10 },
                        { 10,01,01,01,01,01,01,10,10,01,01,01,01,10,10,01,01,01,01,10,10,01,01,01,01,01,01,10 },
                        { 10,01,10,10,10,10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10,10,10,10,01,10 },
                        { 10,01,10,10,10,10,10,10,10,10,10,10,01,10,10,01,10,10,10,10,10,10,10,10,10,10,01,10 },
                        { 10,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,01,10 },
                        { 10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10 } };
                    break;
            }
            int StartX = 0;
            int StartY = 0;
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 27; x++)
                {
                    if (Matrix[y, x] == 3) { StartX = x; StartY = y; }
                }
            }
            Tuple<int, int> StartLocation = new Tuple<int, int>(StartX, StartY);
            return StartLocation;
        }
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

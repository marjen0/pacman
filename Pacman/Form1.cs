using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pacman
{
    public partial class Form1 : Form
    {
        public static HttpClient httpCient = new HttpClient();
        public ICollection<Player> currentPlayers;
        
        public static GameBoard gameboard = new GameBoard();
        public static Food food = new Food();
        public static Pacman pacman = new Pacman();
        public static Ghost ghost = new Ghost();
        public static Player player = new Player();
        public static HighScore highscore = new HighScore();
        //public static Audio audio = new Audio();
        private static FormElements formelements = new FormElements();
        

        public Form1()
        {
            InitializeComponent();
            SetupGame(1);
            pacman.DisableTimer();
            ghost.DisableTimer(); 
        }

        public void SetupGame(int Level)
        {
            // Create Game Board
            gameboard.CreateBoardImage(this, Level);

            // Create Board Matrix
            Tuple<int, int> PacmanStartCoordinates = gameboard.InitialiseBoardMatrix(Level);

            // Create Player
            player.CreatePlayerDetails(this);
            player.CreateLives(this);

            // Create Form Elements
            formelements.CreateFormElements(this);

            // Create High Score
            highscore.CreateHighScore(this);

            // Create Food
            food.CreateFoodImages(this);

            // Create Ghosts
            ghost.CreateGhostImage(this);

            // Create Pacman
            pacman.CreatePacmanImage(this, PacmanStartCoordinates.Item1, PacmanStartCoordinates.Item2);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up: 
                    pacman.nextDirection = 1; pacman.MovePacman(1);
                    formelements.Log.AppendText("\nPacman moving up");
                    break;
                case Keys.Right: 
                    pacman.nextDirection = 2; pacman.MovePacman(2);
                    formelements.Log.AppendText("\nPacman moving right");
                    break;
                case Keys.Down: 
                    pacman.nextDirection = 3; pacman.MovePacman(3);
                    formelements.Log.AppendText("\nPacman moving down");
                    break;
                case Keys.Left: 
                    pacman.nextDirection = 4; pacman.MovePacman(4);
                    formelements.Log.AppendText("\nPacman moving left");
                    break;
                case Keys.S:
                    ghost.EnableTimer();
                    pacman.EnableTImer();
                    break;
                case Keys.P:
                    if(pacman.IsTimerEnabled() && ghost.IsTimerEnabled())
                    {
                        pacman.StopTimer();
                        ghost.StopTimer();   
                    }
                    else
                    {
                        pacman.StartTimer();
                        ghost.StartTimer();
                    }
                    break;
                case Keys.F1:
                    formelements.Log.AppendText("\n Player Logged in");
                    break;
            }
        }

    }
}

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
using Microsoft.AspNetCore.SignalR.Client;
using Pacman.Services;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private HubConnection _hubConnection;
        private static SignalR _signalR;
        //public static HttpClient httpCient = new HttpClient();
        public List<Player> currentPlayers = new List<Player>(2);
        
        public static GameBoard gameboard = new GameBoard();
        public static Food food = new Food();
        public static Pacman pacman;
        public static Ghost ghost = new Ghost();
        public static Player player = new Player();
        public static HighScore highscore = new HighScore();
        //public static Audio audio = new Audio();
        private static FormElements formelements = new FormElements();
        
        

        public Form1()
        {
            InitializeComponent();
           
            _hubConnection = new HubConnectionBuilder().WithUrl("https://localhost:44394/hub").Build();
            _hubConnection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await _hubConnection.StartAsync();
            };
            _signalR = new SignalR(_hubConnection);
            pacman = new Pacman(_signalR,1);
            SetupGame(1);
            pacman.DisableTimer();
            ghost.DisableTimer(); 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            _hubConnection.On<string,int>("ReceiveConnectedMessage", (username, id) =>
            {
                this.Invoke((Action)(() =>
                {

                    formelements.Log.AppendText($"\n{username} joined the game with player ID {id}");
                }));
            });
            _hubConnection.On<int, int, int>("ReceivePacmanCoordinates", (xCoordinate, yCordinate, id) =>
            {
                this.Invoke((Action)(() =>
                {
                    pacman.xCoordinate = xCoordinate; pacman.yCoordinate = yCordinate;
                    formelements.Log.AppendText($"\nPacman id = {id} | x:{xCoordinate} y:{yCordinate}");
                }));
            });
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

        protected async override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up: 
                    pacman.nextDirection = 1; pacman.MovePacman(1);                
                    break;
                case Keys.Right: 
                    pacman.nextDirection = 2; pacman.MovePacman(2);
                    break;
                case Keys.Down: 
                    pacman.nextDirection = 3; pacman.MovePacman(3);
                    break;
                case Keys.Left: 
                    pacman.nextDirection = 4; pacman.MovePacman(4);

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
                    Player p = new Player("Naujas",1);
                    bool isOK =await _signalR.ConnectPlayer(p);
                    break;
            }
        }
        
    }
}

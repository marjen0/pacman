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
        private static API _api;
        //public static HttpClient httpCient = new HttpClient();
        public List<Player> currentPlayers = new List<Player>(2);
        
        public static GameBoard gameboard = new GameBoard();
        public static Food food = new Food();
        public static Pacman pacman;
        public static Ghost ghost = new Ghost();
        public static Player player = new Player();
        public static HighScore highscore = new HighScore();

        private static FormElements formelements = new FormElements();

        List<Player> players = new List<Player>(2);
        List<Pacman> pacmans = new List<Pacman>(2);
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
            _api = new API();
            ghost.DisableTimer(); 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            _hubConnection.On<string>("ReceiveConnectedMessage", (connnectionId) =>
            {
                this.Invoke((Action)(() =>
                {
                    pacman = new Pacman(_signalR, connnectionId);
                    pacmans.Add(pacman);
                    SetupGame(1);
                    Player newPlayer = new Player("Player-" + players.Count, _hubConnection.ConnectionId);
                    _api.CreatePlayer(newPlayer);
                    players.Add(newPlayer);
                    
                    
                    formelements.Log.AppendText($"\nplayer joined the game with connection id {connnectionId} | Total players {players.Count}");
                }));
            });
            _hubConnection.On<int, int,int, string>("ReceivePacmanCoordinates", (xCoordinate, yCordinate,direction, id) =>
            {
                this.Invoke((Action)(() =>
                {
                    //pacmans.First(p => p.Id != id).MovePacman(direction);
                    //pacman.xCoordinate = xCoordinate; pacman.yCoordinate = yCordinate;
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
            pacmans.Single(p => p.Id == _hubConnection.ConnectionId).CreatePacmanImage(this, PacmanStartCoordinates.Item1, PacmanStartCoordinates.Item2);
        }

        protected async override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up:
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).nextDirection = 1;
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).MovePacman(1);
                    //_signalR.SendCoordinates(pacman);                
                    break;
                case Keys.Right:
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).nextDirection = 2;
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).MovePacman(2);
                    //_signalR.SendCoordinates(pacman);
                    break;
                case Keys.Down:
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).nextDirection = 3;
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).MovePacman(4);
                    //_signalR.SendCoordinates(pacman);
                    break;
                case Keys.Left:
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).nextDirection = 4;
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).MovePacman(4);
                    //_signalR.SendCoordinates(pacman);
                    break;
                case Keys.S:
                    ghost.EnableTimer();
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).EnableTImer();
                    break;
                case Keys.P:
                    if(pacmans.Single(p => p.Id == _hubConnection.ConnectionId).IsTimerEnabled() && ghost.IsTimerEnabled())
                    {
                        pacmans.Single(p => p.Id == _hubConnection.ConnectionId).StopTimer();
                        ghost.StopTimer();   
                    }
                    else
                    {
                        pacmans.Single(p => p.Id == _hubConnection.ConnectionId).StartTimer();
                        ghost.StartTimer();
                    }
                    break;
                case Keys.F1:
                    //prisijungti prie zaidimo
                    await _signalR.ConnectPlayer();  
                    break;
            }
        }
        
    }
}

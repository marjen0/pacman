using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.AspNetCore.SignalR.Client;
using Pacman.Classes;
using Pacman.Services;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private HubConnection _hubConnection;
        private static SignalR _signalR;
        private static API _api;
        public List<Player> currentPlayers = new List<Player>(2);
        
        public static GameBoard gameboard = new GameBoard();
        public static FoodCreator foodCreator = new MegaFoodCreator();
        public static Food food = foodCreator.CreateFood();
        public static BlueFactory blueFactory = new BlueFactory();
        public static RedFactory redFactory = new RedFactory();

        public static Pacman pacman, opponent;
        public static Ghost ghost = new Ghost();
        public static Player player = new Player();
        public static HighScore highscore = new HighScore();

        private static readonly FormElements formelements = new FormElements();
        readonly List<Player> players = new List<Player>(2);
        readonly List<Pacman> pacmans = new List<Pacman>(2);

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
            _signalR.RegisterPlayer();

            // Create Board Matrix
            Tuple<int, int> PacmanStartCoordinates = gameboard.InitialiseBoardMatrix(1);
            SetupGame(1);

            _hubConnection.On("ReceiveRegisterCompletedMessage", () =>
            {
                formelements.Log.AppendText($"\nWait until your friend opens this game then press F1 to join the game!\n" +
                    $"Player1 plays with blue pacman, Player2 plays with red.\n");
            });

            _hubConnection.On<string>("ReceiveConnectedMessage", (connnectionId) =>
            {
                this.Invoke((Action)(() =>
                {
                    Player newPlayer = new Player(connnectionId, "Player" + (players.Count + 1));
                    _api.CreatePlayer(newPlayer);
                    players.Add(newPlayer);

                    if (players.Count == 2)
                    {
                        pacman = blueFactory.CreatePacman(_signalR, players.First().Id);
                        opponent = redFactory.CreatePacman(_signalR, players.Last().Id);
                        pacmans.Add(pacman);
                        pacmans.Add(opponent);

                        ghost.EnableTimer();

                        foreach (var p in pacmans)
                        {
                            p.CreatePacmanImage(this, PacmanStartCoordinates.Item1, PacmanStartCoordinates.Item2);
                            p.EnableTImer();
                        }
                    }

                    formelements.Log.AppendText($"\n{newPlayer.Name} with id {connnectionId} joined the game!" +
                        $"\nTotal players: {players.Count}");
                }));
            });

            _hubConnection.On<int, int, int, string>("ReceivePacmanCoordinates", (xCoordinate, yCoordinate, direction, id) =>
            {
                this.Invoke((Action)(() =>
                {
                    // Logging movement
                    //formelements.Log.AppendText($"\nPacman id = {id} | x:{xCoordinate} y:{yCoordinate}");
                    pacmans.Single(p => p.Id == id).nextDirection = direction;
                }));
            });
        }
        public void SetupGame(int Level)
        {
            // Create Game Board
            gameboard.CreateBoardImage(this, Level);

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
        }

        protected async override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (players.Count < 2)
                        return;
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).nextDirection = 1;
                    //pacmans.Single(p => p.Id == _hubConnection.ConnectionId).MovePacman(1);
                    //_signalR.SendCoordinates(pacman);
                    break;
                case Keys.Right:
                    if (players.Count < 2)
                        return;
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).nextDirection = 2;
                    //pacmans.Single(p => p.Id == _hubConnection.ConnectionId).MovePacman(2);
                    //_signalR.SendCoordinates(pacman);
                    break;
                case Keys.Down:
                    if (players.Count < 2)
                        return;
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).nextDirection = 3;
                    //pacmans.Single(p => p.Id == _hubConnection.ConnectionId).MovePacman(4);
                    //_signalR.SendCoordinates(pacman);
                    break;
                case Keys.Left:
                    if (players.Count < 2)
                        return;
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).nextDirection = 4;
                    //pacmans.Single(p => p.Id == _hubConnection.ConnectionId).MovePacman(4);
                    //_signalR.SendCoordinates(pacman);
                    break;
                case Keys.S:
                    if (players.Count < 2)
                        return;
                    ghost.EnableTimer();
                    pacmans.Single(p => p.Id == _hubConnection.ConnectionId).EnableTImer();
                    break;
                case Keys.P:
                    if (players.Count < 2)
                        return;
                    if (pacmans.Single(p => p.Id == _hubConnection.ConnectionId).IsTimerEnabled() && ghost.IsTimerEnabled())
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
                    // Join the game
                    if (players.Count < 2)
                        await _signalR.ConnectPlayer();
                    break;
            }
        }
    }
}

﻿using System;
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
using Pacman.Classes.Observer;
using Pacman.Classes.FactoryMethod;
using Pacman.Services;
using Pacman.Classes.Adapter;
using Pacman.Classes.Decorator;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private HubConnection _hubConnection;
        private static SignalR _signalR;
        private static API _api;
        public List<Player> currentPlayers = new List<Player>(2);
        
        public static GameBoard gameboard = new GameBoard();

        // Factory pattern for food objects
        public static FoodCreator regularFoodCreator = new RegularFoodCreator();
        public static Food regularFood = regularFoodCreator.CreateFood();
        public static FoodCreator superFoodCreator = new SuperFoodCreator();
        public static Food superFood = superFoodCreator.CreateFood();
        public static FoodCreator megaFoodCreator = new MegaFoodCreator();
        public static Food megaFood = megaFoodCreator.CreateFood();

        // Abstract Factory pattern for pacmans and ghosts
        public static BlueFactory blueFactory = new BlueFactory();
        public static RedFactory redFactory = new RedFactory();

        // Observer pattern
        public static PlayerData playerData = PlayerData.GetInstance();

        public static Pacman pacman, opponent;
        public static Ghost ghost = new Ghost();
        public static Player player = new Player();
        public static HighScore highscore = new HighScore();
       
        // Adapter pattern for Player and Pacman data logging
        private static ILog _pacmanLogAdapter;
        private static ILog _playerLogAdapter;

        private static readonly FormElements formelements = new FormElements();
        public static List<Player> players = new List<Player>(2);
        public static List<Pacman> pacmans = new List<Pacman>(2);

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

            playerData.RegisterObserver(player);
            playerData.RegisterObserver(highscore);

            _hubConnection.On("ReceiveRegisterCompletedMessage", () =>
            {
                formelements.Log.AppendText($"\nWait until your friend opens this game then press F1 to join the game!\n" +
                    $"Player1 plays with blue pacman, Player2 plays with red.\n");
                formelements.Log.AppendText($"\nPlayer lives: {player.Lives}");
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
                        // Decrator


                        pacman = blueFactory.CreatePacman(_signalR, players.First().Id);
                        //pacman = new PinkBorderDecorator(pacman); 
                        pacman.AddPacmanImages();
                        opponent = redFactory.CreatePacman(_signalR, players.Last().Id);
                        opponent.AddPacmanImages();
                        pacmans.Add(pacman);
                        pacmans.Add(opponent);
                        
                        ghost.EnableTimer();

                        foreach (var p in pacmans)
                        {
                            p.CreatePacmanImage(this, PacmanStartCoordinates.Item1, PacmanStartCoordinates.Item2);
                            p.EnableTImer();
                        }

                        playerData.EditLives(5);
                        formelements.Log.AppendText($"\nPlayer lives: {player.Lives}");
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
                    _pacmanLogAdapter = new PacmanLogAdapter(pacmans.Single(p => p.Id == id));
                    _playerLogAdapter = new PlayerLogAdapter(players.Single(p => p.Id == id));
                    formelements.Log.AppendText(_pacmanLogAdapter.LogData());
                    formelements.Log.AppendText(_playerLogAdapter.LogData());
                    formelements.Log.ScrollToCaret();
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
            regularFood.CreateFoodImages(this);
            superFood.CreateFoodImages(this);
            megaFood.CreateFoodImages(this);

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

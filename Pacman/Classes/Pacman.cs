using Pacman.Classes;
using Pacman.Classes.Command;
using Pacman.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public abstract class Pacman : Receiver
    {
        public string Id { get; set; }
        protected SignalR _signalR;
        
        // Initialise variables
        public int xCoordinate = 0;
        public int yCoordinate = 0;
        protected int xStart = 0;
        protected int yStart = 0;
        public int currentDirection = 0;
        public int nextDirection = 0;
        public PictureBox PacmanImage = new PictureBox();
        protected ImageList PacmanImages = new ImageList(); 
        Timer timer = new Timer();
        Timer slowTimer = new Timer();
        Timer fastTimer = new Timer();
        Timer stateTimer = new Timer();

        private int imageOn = 0;

        public Pacman()
        {
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += new EventHandler(Timer_Tick);

            stateTimer.Interval = 10000;
            stateTimer.Tick += new EventHandler(StateTimer_Tick);

            PacmanImages.ImageSize = new Size(27,28);

            //AddPacmanImages();
        }

        public abstract void AddPacmanImages();
        public abstract void Set_Pacman();

        //Strategy pattern methods
        public Timer GetTimer()
        {
            return timer;
        }

        public Timer GetStateTimer()
        {
            return stateTimer;
        }

        public void CreatePacmanImage(Form formInstance, int StartXCoordinate, int StartYCoordinate)
        {
            // Create Pacman Image
            xStart = StartXCoordinate;
            yStart = StartYCoordinate;
            PacmanImage.Name = "PacmanImage";
            PacmanImage.SizeMode = PictureBoxSizeMode.AutoSize;
            Set_Pacman();
            formInstance.Controls.Add(PacmanImage);
            PacmanImage.BringToFront();
        }

        public void MovePacman(int direction)
        {
            // Move Pacman
            bool CanMove = check_direction(nextDirection);
            if (!CanMove) { CanMove = check_direction(currentDirection); direction = currentDirection; } else { direction = nextDirection; }
            if (CanMove) { currentDirection = direction; }

            if (CanMove)
            {
                switch (direction)
                {
                    case 1: PacmanImage.Top -= 16; yCoordinate--; break;
                    case 2: PacmanImage.Left += 16; xCoordinate++; break;
                    case 3: PacmanImage.Top += 16; yCoordinate++; break;
                    case 4: PacmanImage.Left -= 16; xCoordinate--; break;
                }
                currentDirection = direction;

                UpdatePacmanImage();
                CheckPacmanPosition();
                _signalR.SendCoordinates(this);
                Form1.ghost.CheckForPacman();
            }
        }

        private void CheckPacmanPosition()
        {
            // Check Pacmans position
            switch (Form1.gameboard.Matrix[yCoordinate, xCoordinate])
            {
                case 1: Form1.regularFood.EatFood(yCoordinate, xCoordinate); break;
                case 2: Form1.superFood.EatFood(yCoordinate, xCoordinate); Form1.superFood.PlayerMoveSpeed(this); break;
                case 3: Form1.megaFood.EatFood(yCoordinate, xCoordinate); Form1.megaFood.PlayerMoveSpeed(this); break;
            }
        }

        private void UpdatePacmanImage()
        {
            // Update Pacman image
            PacmanImage.Image = PacmanImages.Images[((currentDirection - 1) * 4) + imageOn];
            imageOn++;
            if (imageOn > 3) { imageOn = 0; }
        }

        private bool check_direction(int direction)
        {
            // Check if pacman can move to space
            switch (direction)
            {
                case 1: return direction_ok(xCoordinate, yCoordinate - 1);
                case 2: return direction_ok(xCoordinate + 1, yCoordinate);
                case 3: return direction_ok(xCoordinate, yCoordinate + 1);
                case 4: return direction_ok(xCoordinate - 1, yCoordinate);
                default: return false;
            }
        }

        private bool direction_ok(int x, int y)
        {
            // Check if board space can be used
            if (x < 0) { xCoordinate = 27; PacmanImage.Left = 429; return true ; }
            if (x > 27) { xCoordinate = 0; PacmanImage.Left = -5; return true; }
            if (Form1.gameboard.Matrix[y, x] < 4) { return true; } else { return false; }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Keep moving pacman
            MovePacman(currentDirection);
        }

        private void StateTimer_Tick(object sender, EventArgs e)
        {
            timer.Interval = 100;
            stateTimer.Stop();
        }

        public void Move(int direction)
        {
            nextDirection = direction;
        }

        //Command pattern methods
        public void MoveUp()
        {
            Move(1);
        }

        public void MoveRight()
        {
            Move(2);
        }

        public void MoveDown()
        {
            Move(3);
        }

        public void MoveLeft()
        {
            Move(4);
        }

        public void DisableTimer()
        {
            timer.Enabled = false;
        }
        public void EnableTImer()
        {
            timer.Enabled = true;
        }
        public void StopTimer()
        {
            timer.Stop();
        }
        public void StartTimer()
        {
            timer.Start();
        }
        public bool IsTimerEnabled()
        {
            return timer.Enabled;
        }
        public override string ToString()
        {
            return $"Pacman: Id:{Id} | xCoordinate:{xCoordinate} | yCoordinate:{yCoordinate} | direction:{currentDirection}\n";
        }
        public void LogDataToRichTextBox()
        {
            Form1.formElements.Log.AppendText(string.Format("{0}\n", this.ToString()));
        }

    }
}

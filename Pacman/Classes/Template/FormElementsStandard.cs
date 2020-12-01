﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman.Classes.Template
{
    public class FormElementsStandard : FormElements
    {
        private readonly bool _addLogBox = true;
        private Label _playerOneScoreText;
        private Label _notJoinedText;
        private Label _highscoreText;
        private RichTextBox _log;
        private RichTextBox _debugLog;
        public override bool AddLogBox { get => _addLogBox; set => throw new NotImplementedException(); }
        public override Label PlayerOneScoreText { get => _playerOneScoreText; set => _playerOneScoreText = value; }
        public override Label HighScoreText { get => _highscoreText; set => _highscoreText = value; }
        public override RichTextBox Log { get => _log; set => _log = value; }
        public override RichTextBox DebugLog { get => _debugLog; set => _debugLog = value; }
        public override Label NotJoinedText { get => _notJoinedText; set => _notJoinedText = value; }

        public FormElementsStandard()
        {
            _playerOneScoreText = new Label();
            _highscoreText = new Label();
            _notJoinedText = new Label();
            _log = new RichTextBox();
            _debugLog = new RichTextBox();
        }
        public override void CreateHighScoreLabel(Form formInstance)
        {
            HighScoreText.Name = "HighscoreLabel";
            HighScoreText.ForeColor = System.Drawing.Color.White;
            HighScoreText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            HighScoreText.Top = 5;
            HighScoreText.Left = 155;
            HighScoreText.Height = 20;
            HighScoreText.Width = 200;
            HighScoreText.Text = "HIGH SCORE";
            formInstance.Controls.Add(HighScoreText);
        }

        public override void CreateLogBox(Form formInstance)
        {
            Log.Name = "LogBox";
            Log.Height = 250;
            Log.Width = 345;
            Log.Top = 5;
            Log.Left = 475;
            Log.Enabled = false;
            formInstance.Controls.Add(Log);
        }
        public override void CreateDebugLogBox(Form formInstance)
        {
            DebugLog.Name = "DebugLogBox";
            DebugLog.Height = 250;
            DebugLog.Width = 345;
            DebugLog.Top = 260;
            DebugLog.Left = 475;
            DebugLog.Enabled = false;
            formInstance.Controls.Add(DebugLog);
        }

        public override void CreatePlayerOneScoreLabel(Form formInstance)
        {
            PlayerOneScoreText.Name = "PayerOneScoreLabel";
            PlayerOneScoreText.ForeColor = System.Drawing.Color.White;
            PlayerOneScoreText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            PlayerOneScoreText.Top = 5;
            PlayerOneScoreText.Left = 20;
            PlayerOneScoreText.Height = 20;
            PlayerOneScoreText.Width = 100;
            PlayerOneScoreText.Text = "1UP";
            formInstance.Controls.Add(PlayerOneScoreText);
        }

        public override void CreateNotJoinedLabel(Form formInstance)
        {
            NotJoinedText.Name = "NotJoinedLabel";
            NotJoinedText.ForeColor = System.Drawing.Color.Aqua;
            NotJoinedText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            NotJoinedText.Top = 20;
            NotJoinedText.Left = 300;
            NotJoinedText.Height = 20;
            NotJoinedText.Width = 200;
            NotJoinedText.Text = "JOIN THE GAME! ";
            NotJoinedText.BringToFront();
            formInstance.Controls.Add(NotJoinedText);
        }
    }
}

using Moq;
using Pacman.Classes.Flyweight;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Xunit;

namespace Pacman.UnitTests
{
    public class HighScoreTests
    {
        private HighScore CreateHighScore()
        {
            return new HighScore();
        }

        [Fact]
        public void CreateHighScore_CreatesHighScore_HighScoreParametersIsSetUpCorrectly()
        {
            var highScore = this.CreateHighScore();
            var formInstance = new Form();
            var highScoreText = new Label();

            var color = Color.White;
            var font = new Font("Folio XBd BT", 14);
            int top = 23;
            int left = 170;
            int height = 20;
            int width = 100;
            int count = formInstance.Controls.Count;

            highScoreText.ForeColor = color;
            highScoreText.Font = font;
            highScoreText.Top = top;
            highScoreText.Left = left;
            highScoreText.Height = height;
            highScoreText.Width = width;
            formInstance.Controls.Add(highScoreText);
            highScoreText.BringToFront();

            Assert.Equal(highScoreText.ForeColor, color);
            Assert.Equal(highScoreText.Font, font);
            Assert.Equal(highScoreText.Top, top);
            Assert.Equal(highScoreText.Left, left);
            Assert.Equal(highScoreText.Height, height);
            Assert.Equal(highScoreText.Width, width);
            Assert.True(formInstance.Controls.Count > count);
        }

        [Fact]
        public void UpdateScore_UpdatesScore_ScoreIsUpdated()
        {
            var highScore = this.CreateHighScore();
            int initialScore = highScore.Score;
            int modifiedScore = initialScore * 5;

            highScore.UpdateScore(modifiedScore);

            Assert.Equal(modifiedScore, highScore.Score);
        }
    }
}

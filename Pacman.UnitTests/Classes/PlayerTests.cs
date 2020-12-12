using Moq;
using Pacman;
using System;
using System.Windows.Forms;
using Xunit;

namespace Pacman.UnitTests.Classes
{
    public class PlayerTests
    {
        private Player CreatePlayer()
        {
            return new Player();
        }

        [Fact]
        public void UpdateScore_UpdatesPlayerScore_ScoreIsUpdated()
        {
            // Arrange
            var player = this.CreatePlayer();
            int amount = 500;
            int initialScore = player.Score;

            // Act
            player.UpdateScore(amount);

            // Assert
            Assert.True(player.Score > initialScore);
            Assert.Equal(initialScore + amount, player.Score);
        }

        [Fact]
        public void UpdateLives_UpdatesPlayerLives_PlayerLivesAreUpdated()
        {
            // Arrange
            var player = this.CreatePlayer();
            int lives = 5;

            // Act
            var result = player.UpdateLives(lives);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void UpdateHighScore_UpdatesHighScore_PlayerHighScoreIsUpdated()
        {
            // Arrange
            var player = this.CreatePlayer();
            int amount = 500;

            // Act
            var result = player.UpdateHighScore(amount);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ToString_ReturnsPlayerDataInString_TypeIsString()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            var result = player.ToString();

            // Assert
            Assert.IsType<string>(result);
        }

        [Fact]
        public void LogDataToRichTextBox_LogsPlayerDataToRichTextBox_RichTextBoxLengthIsLonger()
        {
            // Arrange
            var player = this.CreatePlayer();
            Form1 form = new Form1();
            var initialLog = form.formElements.Log.Text;

            // Act
            player.LogDataToRichTextBox(form);
            var log = form.formElements.Log.Text;

            // Assert
            Assert.True(log.Length > initialLog.Length);
        }
    }
}

using Moq;
using Pacman;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes
{
    public class PlayerTests
    {
        private MockRepository mockRepository;



        public PlayerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Player CreatePlayer()
        {
            return new Player();
        }

        [Fact]
        public void CreateLives_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();
            Form formInstance = null;

            // Act
            player.CreateLives(
                formInstance);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void CreatePlayerDetails_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();
            Form formInstance = null;

            // Act
            player.CreatePlayerDetails(
                formInstance);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UpdateScore_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();
            int amount = 0;

            // Act
            player.UpdateScore(
                amount);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void SetLives_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            player.SetLives();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void LoseLife_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            player.LoseLife();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void LevelComplete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            player.LevelComplete();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UpdateLives_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();
            int lives = 0;

            // Act
            var result = player.UpdateLives(
                lives);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void UpdateHighScore_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();
            int amount = 0;

            // Act
            var result = player.UpdateHighScore(
                amount);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void ToString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();

            // Act
            var result = player.ToString();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void LogDataToRichTextBox_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var player = this.CreatePlayer();
            Form1 form = null;

            // Act
            player.LogDataToRichTextBox(
                form);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

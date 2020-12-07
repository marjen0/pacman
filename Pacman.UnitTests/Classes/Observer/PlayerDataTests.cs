using Moq;
using Pacman.Classes.Observer;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Observer
{
    public class PlayerDataTests
    {
        private MockRepository mockRepository;



        public PlayerDataTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private PlayerData CreatePlayerData()
        {
            return new PlayerData();
        }

        [Fact]
        public void GetInstance_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var playerData = this.CreatePlayerData();

            // Act
            var result = playerData.GetInstance();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void NotifyObservers_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var playerData = this.CreatePlayerData();

            // Act
            playerData.NotifyObservers();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void EditLives_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var playerData = this.CreatePlayerData();
            int lives = 0;

            // Act
            playerData.EditLives(
                lives);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void EditHighScore_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var playerData = this.CreatePlayerData();
            int score = 0;

            // Act
            playerData.EditHighScore(
                score);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void RegisterObserver_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var playerData = this.CreatePlayerData();
            IObserver o = null;

            // Act
            playerData.RegisterObserver(
                o);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void RemoveObserver_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var playerData = this.CreatePlayerData();
            IObserver o = null;

            // Act
            playerData.RemoveObserver(
                o);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

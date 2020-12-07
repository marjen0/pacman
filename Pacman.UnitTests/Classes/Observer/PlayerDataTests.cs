using Moq;
using Pacman.Classes.Observer;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace Pacman.UnitTests.Classes.Observer
{
    public class PlayerDataTests
    {
        private List<PlayerData> playerDatas = new List<PlayerData>();

        private PlayerData CreatePlayerData()
        {
            return PlayerData.GetInstance();
        }

        [Fact]
        public void GetInstance_GetsPlayerDataInstance_OnlyOneInstanceIsCreated()
        {
            // Arrange
            var playerData = this.CreatePlayerData();
            var t1 = new Thread(new ThreadStart(ThreadProc));
            var t2 = new Thread(new ThreadStart(ThreadProc));
            int lives = 5;

            // Act
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            var localPlayerData = CreatePlayerData();
            localPlayerData.EditLives(lives);

            // Assert
            foreach (var elem in playerDatas)
            {
                Assert.Equal(localPlayerData, elem);
                Assert.Equal(lives, elem.GetLives());
            }
        }

        public void ThreadProc()
        {
            for (int i = 0; i < 2; i++)
            {
                playerDatas.Add(PlayerData.GetInstance());
                playerDatas[i].EditLives(i);
                Thread.Sleep(10);
            }
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
        }

        [Fact]
        public void EditLives_SetsPlayersLives_PlayerLivesIsSetCorrectly()
        {
            // Arrange
            var playerData = this.CreatePlayerData();
            int lives = 5;

            // Act
            playerData.EditLives(lives);

            // Assert
            Assert.Equal(lives, playerData.GetLives());
        }

        [Fact]
        public void GetLives_GetsPlayersLives_TypeIsInt()
        {
            // Arrange
            var playerData = this.CreatePlayerData();

            // Act
            var result = playerData.GetLives();

            // Assert
            Assert.IsType<int>(result);
        }

        [Fact]
        public void EditHighScore_SetsPlayersHighscore_PlayersHighscoreAmountIsSetCorrectly()
        {
            // Arrange
            var playerData = this.CreatePlayerData();
            int score = 9999;

            // Act
            playerData.EditHighScore(score);
            var result = playerData.GetHighScore();

            // Assert
            Assert.Equal(score, result);
        }

        [Fact]
        public void GetHighScore_GetsPlayersHighsSore_TypeIsInt()
        {
            // Arrange
            var playerData = this.CreatePlayerData();

            // Act
            var result = playerData.GetHighScore();

            // Assert
            Assert.IsType<int>(result);
        }

        [Fact]
        public void RegisterObserver_AddsObserverToObserversList_ObserversListIsNotEmpty()
        {
            // Arrange
            var playerData = this.CreatePlayerData();
            IObserver o = null;

            // Act
            playerData.RegisterObserver(o);

            // Assert
            Assert.NotEmpty(playerData.observers);
        }

        [Fact]
        public void RemoveObserver_RemovesObserverFromObserversList_ObserversListCountIsLower()
        {
            // Arrange
            var playerData = this.CreatePlayerData();
            IObserver o = null;
            playerData.RegisterObserver(o);
            playerData.RegisterObserver(o);
            int count = playerData.observers.Count;

            // Act
            playerData.RemoveObserver(o);
            int count2 = playerData.observers.Count;

            // Assert
            Assert.True(count2 < count);
        }
    }
}

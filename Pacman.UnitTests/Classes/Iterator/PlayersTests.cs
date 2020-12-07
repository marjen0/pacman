using Moq;
using Pacman.Classes.Iterator;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Iterator
{
    public class PlayersTests
    {
        private MockRepository mockRepository;



        public PlayersTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Players CreatePlayers()
        {
            return new Players();
        }

        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var players = this.CreatePlayers();
            Player p = null;

            // Act
            players.Add(
                p);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetPlayers_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var players = this.CreatePlayers();

            // Act
            var result = players.GetPlayers();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetCount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var players = this.CreatePlayers();

            // Act
            var result = players.GetCount();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetEnumerator_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var players = this.CreatePlayers();

            // Act
            var result = players.GetEnumerator();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

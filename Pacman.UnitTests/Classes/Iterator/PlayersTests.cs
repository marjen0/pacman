using Moq;
using Pacman.Classes.Iterator;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Iterator
{
    public class PlayersTests
    {
        private Players CreatePlayers()
        {
            return new Players();
        }

        [Fact]
        public void Add_AddsPlayerToArray_ArrayLengthIsNot0()
        {
            // Arrange
            var players = this.CreatePlayers();
            Player p = null;

            // Act
            players.Add(p);
            var result = players.GetCount();

            // Assert
            Assert.NotEqual(0, result);
        }

        [Fact]
        public void GetPlayers_GetsPlayersArray_TypeIsArrayOfTypePlayer()
        {
            // Arrange
            var players = this.CreatePlayers();

            // Act
            var result = players.GetPlayers();

            // Assert
            Assert.IsType<Player[]>(result);
        }

        [Fact]
        public void GetCount_GetPlayersCount_TypeIsInt()
        {
            // Arrange
            var players = this.CreatePlayers();

            // Act
            var result = players.GetCount();

            // Assert
            Assert.IsType<int>(result);
        }

        [Fact]
        public void GetEnumerator_GetsEnumerator_ContainsSpecifiedPlayers ()
        {
            // Arrange
            var players = this.CreatePlayers();
            var p1 = new Player("1", "1");
            var p2 = new Player("1", "1");

            // Act
            players.Add(p1);
            players.Add(p2);
            var result = players.GetEnumerator();

            // Assert
            result.MoveNext();
            Assert.True(result.Current == p1);

            result.MoveNext();
            Assert.True(result.Current == p2);
        }
    }
}

using Moq;
using Pacman.Classes;
using Pacman.Classes.Iterator;
using Pacman.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace Pacman.UnitTests.Classes.Iterator
{
    public class PacmansTests
    {
        private Pacmans CreatePacmans()
        {
            return new Pacmans();
        }

        [Fact]
        public void Add_AddsPacmanToList_ListLengthIsNot0()
        {
            // Arrange
            var pacmans = this.CreatePacmans();
            var result = 0;
            Pacman p = null;

            // Act
            pacmans.Add(p);
            result = pacmans.GetCount();

            // Assert
            Assert.NotEqual(0, result);
        }

        [Fact]
        public void GetPacmans_GetsPacmansList_TypeIsListOfTypePacman()
        {
            // Arrange
            var pacmans = this.CreatePacmans();

            // Act
            var result = pacmans.GetPacmans();

            // Assert
            Assert.IsType<List<Pacman>>(result);
        }

        [Fact]
        public void GetCount_GetPacmansCount_TypeIsInt()
        {
            // Arrange
            var pacmans = this.CreatePacmans();

            // Act
            var result = pacmans.GetCount();

            // Assert
            Assert.IsType<int>(result);
        }

        [Fact]
        public void GetEnumerator_GetsEnumerator_ContainsSpecifiedPacmans()
        {
            // Arrange
            var pacmans = this.CreatePacmans();
            var factory = new BlueFactory();
            SignalR signalr = null;
            var p1 = factory.CreatePacman(signalr, "1");
            var p2 = factory.CreatePacman(signalr, "2");

            // Act
            pacmans.Add(p1);
            pacmans.Add(p2);
            var result = pacmans.GetEnumerator();

            // Assert
            result.MoveNext();
            Assert.True(result.Current == p1);

            result.MoveNext();
            Assert.True(result.Current == p2);
        }
    }
}

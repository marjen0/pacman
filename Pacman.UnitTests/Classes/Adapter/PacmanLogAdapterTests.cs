using Pacman;
using Pacman.Classes.Adapter;
using Pacman.Classes;
using System;
using Xunit;
using Pacman.Services;
using Moq;

namespace Pacman.UnitTests.Classes.Adapter
{
    public class PacmanLogAdapterTests
    {
        [Fact]
        public void LogData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            
            Pacman p = new RedPacman("pacmanId");
            var pacmanLogAdapter = new PacmanLogAdapter(p);
            string message = null;

            // Act
            pacmanLogAdapter.LogData(message);

            // Assert
            Assert.True(false);
        }

       /* [Fact]
        public void getPacmanId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pacmanLogAdapter = new PacmanLogAdapter(TODO);

            // Act
            var result = pacmanLogAdapter.getPacmanId();

            // Assert
            Assert.True(false);
        }*/
    }
}

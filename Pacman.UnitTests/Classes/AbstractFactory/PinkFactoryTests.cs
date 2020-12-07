using Moq;
using Pacman.Classes;
using Pacman.Services;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class PinkFactoryTests
    {
        
        private PinkFactory CreateFactory()
        {
            return new PinkFactory();
        }

        [Fact]
        public void CreateGhost_CreatesGhostOfTypePinkGhost_TypeIsPinkGhost()
        {
            // Arrange
            var factory = this.CreateFactory();

            // Act
            var result = factory.CreateGhost();

            // Assert
            Assert.IsType<PinkGhost>(result);
        }

        [Fact]
        public void CreatePacman_CreatesPacmanOfTypePinkPacman_TypeIsPinkPacman()
        {
            // Arrange
            var factory = this.CreateFactory();
            SignalR signalr = null;
            string id = null;

            // Act
            var result = factory.CreatePacman(
                signalr,
                id);

            // Assert
            Assert.IsType<PinkPacman>(result);
        }
    }
}

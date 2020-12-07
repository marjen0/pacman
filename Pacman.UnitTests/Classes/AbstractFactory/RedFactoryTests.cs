using Moq;
using Pacman.Classes;
using Pacman.Services;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class RedFactoryTests
    {
        private RedFactory CreateFactory()
        {
            return new RedFactory();
        }

        [Fact]
        public void CreateGhost_CreatesGhostOfTypeRedGhost_TypeIsRedGhost()
        {
            // Arrange
            var factory = this.CreateFactory();

            // Act
            var result = factory.CreateGhost();

            // Assert
            Assert.IsType<RedGhost>(result);
        }

        [Fact]
        public void CreatePacman_CreatesPacmanOfTypeRedPacman_TypeIsRedPacman()
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
            Assert.IsType<RedPacman>(result);
        }
    }
}

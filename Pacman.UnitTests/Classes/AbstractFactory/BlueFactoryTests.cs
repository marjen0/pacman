using Moq;
using Pacman.Classes;
using Pacman.Services;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class BlueFactoryTests
    {
        private BlueFactory CreateFactory()
        {
            return new BlueFactory();
        }

        [Fact]
        public void CreateGhost_CreatesGhostOfTypeBlueGhosts_TypeIsBlueGhost()
        {
            var factory = this.CreateFactory();

            var result = factory.CreateGhost();

            Assert.IsType<BlueGhost>(result);
        }

        [Fact]
        public void CreatePacman_CreatesPacmanOfTypeBluePacman_TypeIsBluePacman()
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
            Assert.IsType<BluePacman>(result);
        }
    }
}

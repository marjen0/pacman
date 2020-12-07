using Moq;
using Pacman.Classes;
using Pacman.Services;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class OrangeFactoryTests
    {        
        private OrangeFactory CreateFactory()
        {
            return new OrangeFactory();
        }

        [Fact]
        public void CreateGhost_CreatesGhostOfTypeOrangeGhost_TypeIsOrangeGhost()
        {
            // Arrange
            var factory = this.CreateFactory();

            // Act
            var result = factory.CreateGhost();

            // Assert
            Assert.IsType<OrangeGhost>(result);
        }

        [Fact]
        public void CreatePacman_CreatesPacmanOfTypeOrangePacman_TypeIsOrangePacman()
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
            Assert.IsType<OrangePacman>(result);
        }
    }
}

using Moq;
using Pacman.Classes;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class PinkPacmanTests
    {
        
        private PinkPacman CreatePinkPacman()
        {
            string id = null;

            return new PinkPacman(id);
        }

        [Fact]
        public void AddPacmanImages_AddPacmanImages_PacmanImagesCountIsNot0()
        {
            // Arrange
            var pinkPacman = this.CreatePinkPacman();

            // Act
            var result = pinkPacman.AddPacmanImages();

            // Assert
            Assert.NotEqual(0, result);
        }

        [Fact]
        public void Set_Pacman_SetsPacmanObject_SetPacmanReturnsTrue()
        {
            // Arrange
            var pinkPacman = this.CreatePinkPacman();

            // Act
            var result = pinkPacman.Set_Pacman();

            // Assert
            Assert.True(result);
        }
    }
}

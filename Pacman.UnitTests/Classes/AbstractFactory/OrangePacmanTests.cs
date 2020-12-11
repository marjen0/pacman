using Moq;
using Pacman.Classes;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class OrangePacmanTests
    {
        private OrangePacman CreateOrangePacman()
        {
            string id = null;

            return new OrangePacman(id);
        }

        [Fact]
        public void AddPacmanImages_AddPacmanImages_PacmanImagesCountIsNot0()
        {
            // Arrange
            var orangePacman = this.CreateOrangePacman();

            // Act
            var result = orangePacman.AddPacmanImages();

            // Assert
            Assert.NotEqual(0, result);
        }

        [Fact]
        public void Set_Pacman_SetsPacmanObject_SetPacmanReturnsTrue()
        {
            // Arrange
            var orangePacman = this.CreateOrangePacman();

            // Act
            orangePacman.Set_Pacman();

            // Assert
            Assert.NotNull(orangePacman.PacmanImage.Image);
        }
    }
}

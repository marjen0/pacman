using Moq;
using Pacman.Classes;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class RedPacmanTests
    {
        private RedPacman CreateRedPacman()
        {
            string id = null;

            return new RedPacman(id);
        }

        [Fact]
        public void AddPacmanImages_AddsPacmanImages_PacmanImagesCountIsNot0()
        {
            // Arrange
            var redPacman = this.CreateRedPacman();

            // Act
            var result = redPacman.AddPacmanImages();

            // Assert
            Assert.NotEqual(0, result);
        }

        [Fact]
        public void Set_Pacman_SetsPacmanObject_SetPacmanReturnsTrue()
        {
            // Arrange
            var redPacman = this.CreateRedPacman();

            // Act
            redPacman.Set_Pacman();

            // Assert
            Assert.NotNull(redPacman.PacmanImage.Image);
        }
    }
}

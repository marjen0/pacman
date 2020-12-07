using Moq;
using Pacman.Classes;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class BluePacmanTests
    {        
        private BluePacman CreateBluePacman()
        {
            string id = null;

            return new BluePacman(id);
        }

        [Fact]
        public void AddPacmanImages_AddsPacmanImages_PacmanImagesCountIsNot0()
        {
            // Arrange
            var bluePacman = this.CreateBluePacman();

            // Act
            var result = bluePacman.AddPacmanImages();

            // Assert
            Assert.NotEqual(0, result);
        }
        
        [Fact]
        public void Set_Pacman_SetsPacmanObject_SetPacmanReturnsTrue()
        {
            // Arrange
            var bluePacman = this.CreateBluePacman();

            // Act
            var result = bluePacman.Set_Pacman();

            // Assert
            Assert.True(result);
        }
    }
}

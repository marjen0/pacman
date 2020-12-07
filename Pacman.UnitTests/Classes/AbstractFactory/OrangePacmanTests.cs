using Moq;
using Pacman.Classes;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class OrangePacmanTests
    {
        private MockRepository mockRepository;



        public OrangePacmanTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private OrangePacman CreateOrangePacman()
        {
            return new OrangePacman(
                TODO);
        }

        [Fact]
        public void AddPacmanImages_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var orangePacman = this.CreateOrangePacman();

            // Act
            orangePacman.AddPacmanImages();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Set_Pacman_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var orangePacman = this.CreateOrangePacman();

            // Act
            orangePacman.Set_Pacman();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

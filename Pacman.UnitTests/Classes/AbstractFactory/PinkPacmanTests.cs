using Moq;
using Pacman.Classes;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class PinkPacmanTests
    {
        private MockRepository mockRepository;



        public PinkPacmanTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private PinkPacman CreatePinkPacman()
        {
            return new PinkPacman(
                TODO);
        }

        [Fact]
        public void AddPacmanImages_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pinkPacman = this.CreatePinkPacman();

            // Act
            pinkPacman.AddPacmanImages();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Set_Pacman_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pinkPacman = this.CreatePinkPacman();

            // Act
            pinkPacman.Set_Pacman();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

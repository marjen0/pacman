using Moq;
using Pacman.Classes;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class RedPacmanTests
    {
        private MockRepository mockRepository;



        public RedPacmanTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private RedPacman CreateRedPacman()
        {
            return new RedPacman(
                TODO);
        }

        [Fact]
        public void AddPacmanImages_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var redPacman = this.CreateRedPacman();

            // Act
            redPacman.AddPacmanImages();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Set_Pacman_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var redPacman = this.CreateRedPacman();

            // Act
            redPacman.Set_Pacman();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

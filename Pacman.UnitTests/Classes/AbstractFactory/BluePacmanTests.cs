using Moq;
using Pacman.Classes;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class BluePacmanTests
    {
        private MockRepository mockRepository;



        public BluePacmanTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private BluePacman CreateBluePacman()
        {
            return new BluePacman(
                TODO);
        }

        [Fact]
        public void AddPacmanImages_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var bluePacman = this.CreateBluePacman();

            // Act
            bluePacman.AddPacmanImages();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void Set_Pacman_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var bluePacman = this.CreateBluePacman();

            // Act
            bluePacman.Set_Pacman();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

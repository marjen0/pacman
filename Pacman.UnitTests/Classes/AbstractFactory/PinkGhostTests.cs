using Moq;
using Pacman.Classes;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class PinkGhostTests
    {
        private MockRepository mockRepository;



        public PinkGhostTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private PinkGhost CreatePinkGhost()
        {
            return new PinkGhost();
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var pinkGhost = this.CreatePinkGhost();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

using Moq;
using Pacman.Classes;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class BlueGhostTests
    {
        private MockRepository mockRepository;



        public BlueGhostTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private BlueGhost CreateBlueGhost()
        {
            return new BlueGhost();
        }
        /*
        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var blueGhost = this.CreateBlueGhost();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }*/
    }
}

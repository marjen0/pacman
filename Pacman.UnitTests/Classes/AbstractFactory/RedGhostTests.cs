using Moq;
using Pacman.Classes;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class RedGhostTests
    {
        private MockRepository mockRepository;



        public RedGhostTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private RedGhost CreateRedGhost()
        {
            return new RedGhost();
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var redGhost = this.CreateRedGhost();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

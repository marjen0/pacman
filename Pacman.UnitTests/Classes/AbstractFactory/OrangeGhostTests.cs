using Moq;
using Pacman.Classes;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class OrangeGhostTests
    {
        private MockRepository mockRepository;



        public OrangeGhostTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private OrangeGhost CreateOrangeGhost()
        {
            return new OrangeGhost();
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var orangeGhost = this.CreateOrangeGhost();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

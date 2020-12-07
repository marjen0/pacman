using Moq;
using Pacman.Classes;
using Pacman.Services;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.AbstractFactory
{
    public class BlueFactoryTests
    {
        private MockRepository mockRepository;



        public BlueFactoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private BlueFactory CreateFactory()
        {
            return new BlueFactory();
        }

        [Fact]
        public void CreateGhost_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = this.CreateFactory();

            // Act
            var result = factory.CreateGhost();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void CreatePacman_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = this.CreateFactory();
            SignalR signalr = null;
            string id = null;

            // Act
            var result = factory.CreatePacman(
                signalr,
                id);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

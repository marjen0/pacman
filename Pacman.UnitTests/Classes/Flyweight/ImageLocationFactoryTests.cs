using Moq;
using Pacman.Classes.Flyweight;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Flyweight
{
    public class ImageLocationFactoryTests
    {
        private MockRepository mockRepository;



        public ImageLocationFactoryTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ImageLocationFactory CreateFactory()
        {
            return new ImageLocationFactory();
        }

        [Fact]
        public void GetImageLocation_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var factory = this.CreateFactory();
            int x = 0;

            // Act
            var result = factory.GetImageLocation(
                x);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

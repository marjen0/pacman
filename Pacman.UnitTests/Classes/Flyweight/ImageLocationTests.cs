using Moq;
using Pacman.Classes.Flyweight;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Flyweight
{
    public class ImageLocationTests
    {
        private MockRepository mockRepository;



        public ImageLocationTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private ImageLocation CreateImageLocation()
        {
            return new ImageLocation();
        }

        [Fact]
        public void SetX_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var imageLocation = this.CreateImageLocation();
            int x = 0;

            // Act
            imageLocation.SetX(
                x);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void SetY_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var imageLocation = this.CreateImageLocation();
            int y = 0;

            // Act
            imageLocation.SetY(
                y);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetPoint_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var imageLocation = this.CreateImageLocation();

            // Act
            var result = imageLocation.GetPoint();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetInstance_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var imageLocation = this.CreateImageLocation();

            // Act
            var result = imageLocation.GetInstance();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

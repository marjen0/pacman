using Moq;
using Pacman.Classes.Flyweight;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Xunit;

namespace Pacman.UnitTests.Classes.Flyweight
{
    public class ImageLocationTests
    {
        private readonly List<ImageLocation> imageLocations = new List<ImageLocation>();

        private ImageLocation CreateImageLocation()
        {
            return new ImageLocation();
        }

        [Fact]
        public void SetX_SetsImageXPoint_ImageXPointIsSetToSpecifiedValue()
        {
            // Arrange
            var imageLocation = this.CreateImageLocation();
            int x = 5;

            // Act
            imageLocation.SetX(x);
            var result = imageLocation.GetPoint().X;

            // Assert
            Assert.Equal(x, result);
        }

        [Fact]
        public void SetY_SetsImageYPoint_ImageYPointIsSetToSpecifiedValue()
        {
            // Arrange
            var imageLocation = this.CreateImageLocation();
            int y = 10;

            // Act
            imageLocation.SetY(y);
            var result = imageLocation.GetPoint().Y;

            // Assert
            Assert.Equal(y, result);
        }

        [Fact]
        public void GetPoint_GetsImagePoint_TypeIsPoint()
        {
            // Arrange
            var imageLocation = this.CreateImageLocation();

            // Act
            var result = imageLocation.GetPoint();

            // Assert
            Assert.IsType<Point>(result);
        }
    }
}

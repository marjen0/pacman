using Moq;
using Pacman.Classes.Flyweight;
using System;
using System.Drawing;
using Xunit;

namespace Pacman.UnitTests.Classes.Flyweight
{
    public class ImageLocationFactoryTests
    {
        [Fact]
        public void GetImageLocation_GetsExistingOrNewImageLocation_ReturnsExistingOrNewImageLocation()
        {
            // Arrange
            int x = 0;

            // Act
            var imageLocation1 = ImageLocationFactory.GetImageLocation(x);
            imageLocation1.SetY(1);
            x = 1;
            var imageLocation2 = ImageLocationFactory.GetImageLocation(x);
            x = 0;
            var imageLocation3 = ImageLocationFactory.GetImageLocation(x);
            imageLocation3.SetY(3);

            // Assert
            Assert.NotEqual(imageLocation1, imageLocation2);
            Assert.Equal(imageLocation1, imageLocation3);
        }
    }
}

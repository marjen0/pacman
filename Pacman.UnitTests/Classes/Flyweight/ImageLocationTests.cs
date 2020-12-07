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
            return ImageLocation.GetInstance();
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

        [Fact]
        public void GetInstance_GetsImageLocationInstance_OnlyOneInstanceIsCreated()
        {
            // Arrange
            var t1 = new Thread(new ThreadStart(ThreadProc));
            var t2 = new Thread(new ThreadStart(ThreadProc));
            int x = 10;

            // Act
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            var localImageLocation = CreateImageLocation();
            localImageLocation.SetX(x);
            localImageLocation.SetY(x);

            // Assert
            foreach (var elem in imageLocations)
            {
                Assert.Equal(localImageLocation, elem);
                Assert.Equal(x, elem.GetPoint().X);
                Assert.Equal(x, elem.GetPoint().Y);
            }
        }

        public void ThreadProc()
        {
            for (int i = 0; i < 2; i++)
            {
                imageLocations.Add(ImageLocation.GetInstance());
                imageLocations[i].SetX(i);
                imageLocations[i].SetY(i);
                Thread.Sleep(10);
            }
        }
    }
}

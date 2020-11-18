using Pacman.Classes.FactoryMethod;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.FactoryMethod
{
    public class MegaFoodCreatorTests
    {
        private readonly FoodCreator _megaFoodCreator;
        public MegaFoodCreatorTests()
        {
            _megaFoodCreator = new MegaFoodCreator();
        }
        [Fact]
        public void CreateFood_CreatesFoodOfTypeMegaFood_TypeIsMegaFood()
        {
            // Arrange
            // Act
            Food megaFood = _megaFoodCreator.CreateFood();
            // Assert
            Assert.IsType<MegaFood>(megaFood);
        }
    }
}

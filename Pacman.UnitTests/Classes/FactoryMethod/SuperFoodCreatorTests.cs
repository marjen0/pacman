using Pacman.Classes.FactoryMethod;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.FactoryMethod
{
    public class SuperFoodCreatorTests
    {
        FoodCreator _superFoodCreator;
        public SuperFoodCreatorTests()
        {
            _superFoodCreator = new SuperFoodCreator();
        }
        [Fact]
        public void CreateFood_CreatesFoodOfTypeSuperFood_TypeIsSuperFood()
        {
            // Arrange
            // Act
            Food superFood = _superFoodCreator.CreateFood();

            // Assert
            Assert.IsType<SuperFood>(superFood);
        }
       
    }
}

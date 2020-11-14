using Pacman.Classes.FactoryMethod;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.FactoryMethod
{
    public class RegularFoodCreatorTests
    {
        FoodCreator _regularFoodCreator;
        public RegularFoodCreatorTests()
        {
            _regularFoodCreator = new RegularFoodCreator();
        }
        [Fact]
        public void CreateFood_CreatesFoodOfTypeRegularFood_TypeIsRegularFood()
        {
            // Arrange
            // Act
            Food regularFood = _regularFoodCreator.CreateFood();

            // Assert
            Assert.IsType<RegularFood>(regularFood);
        }
    }
}

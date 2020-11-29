using Pacman.Classes.FactoryMethod;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Pacman.UnitTests.Classes.FactoryMethod
{
    public class RegularFoodTests
    {
        private readonly ITestOutputHelper _output;
        FoodCreator _regularFoodCreator;
        public RegularFoodTests(ITestOutputHelper testOutput)
        {
            _output = testOutput;
            _regularFoodCreator = new RegularFoodCreator();
        }
        [Fact]
        public void CreateFoodImages_Creates240FoodImages_True()
        {
            // Arange
            Form1 form = new Form1();
            Food regularFood = _regularFoodCreator.CreateFood();
            // Act
            regularFood.CreateFoodImages(form);
            // Assert
            Assert.Equal(240, form.regularFood.Amount);
        }
        [Fact]
        public void EatFood_EatenFoodIsInvisible_True()
        {
            // Arrange
            Food regularFood = _regularFoodCreator.CreateFood();
            regularFood.CreateFoodImages(new Form1());
            // Act
            regularFood.EatFood(10, 10);
            // Assert
            _output.WriteLine("hello from test");
            Assert.False(regularFood.FoodImage[10,10].Visible);
        }

    }
}

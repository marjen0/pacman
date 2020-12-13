using Pacman.Classes.FactoryMethod;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Pacman.UnitTests.Classes.FactoryMethod
{
    public class RegularFoodTests: IDisposable
    {
        private readonly ITestOutputHelper _output;
        FoodCreator _regularFoodCreator;
        private Form1 _form;
        public RegularFoodTests(ITestOutputHelper testOutput)
        {
            _output = testOutput;
            _regularFoodCreator = new RegularFoodCreator();
            _form = new Form1();
        }
        [Fact]
        public void CreateFoodImages_Creates0FoodImages_True()
        {
            // Arange
            Form1 form = new Form1();
            Food regularFood = _regularFoodCreator.CreateFood();
            // Act
            regularFood.CreateFoodImages(form);
            // Assert
            Assert.Equal(0,regularFood.Amount);
        }

        public void Dispose()
        {
            _form.Dispose();
        }
    }
}

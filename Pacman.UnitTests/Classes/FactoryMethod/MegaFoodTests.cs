using Pacman.Classes.FactoryMethod;
using Xunit;
using Xunit.Abstractions;

namespace Pacman.UnitTests.Classes.FactoryMethod
{
    public class MegaFoodTests
    {
        private readonly ITestOutputHelper _output;
        private readonly FoodCreator _megaFoodCreator;
        public MegaFoodTests(ITestOutputHelper outputHelper)
        {
            _output = outputHelper;
            _megaFoodCreator = new MegaFoodCreator();
        }

        
    }
}

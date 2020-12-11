using Moq;
using Pacman.Classes.Interpreter;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Interpreter
{
    public class ContextTests
    {
        private Context CreateContext()
        {
            return new Context();
        }

        [Fact]
        public void Input_SetsOrGetsInput_InputIsSetCorrectly()
        {
            // Arrange
            var context = this.CreateContext();
            string input = "f1";

            // Act
            context.Input = input;

            // Assert
            Assert.Equal(input, context.Input);
        }
    }
}

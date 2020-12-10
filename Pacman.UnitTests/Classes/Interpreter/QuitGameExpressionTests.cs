using Moq;
using Pacman.Classes.Interpreter;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Interpreter
{
    public class QuitGameExpressionTests
    {
        private QuitGameExpression CreateQuitGameExpression()
        {
            return new QuitGameExpression();
        }

        [Fact]
        public void Interpret_InterpretsPressedQButton_OnlyQButtonPressReturnsTrue()
        {
            // Arrange
            var quitGameExpression = this.CreateQuitGameExpression();
            Context context1 = new Context("");
            Context context2 = new Context("w");
            Context context3 = new Context("q");

            // Act
            var result1 = quitGameExpression.Interpret(context1);
            var result2 = quitGameExpression.Interpret(context2);
            var result3 = quitGameExpression.Interpret(context3);

            // Assert
            Assert.False(result1);
            Assert.False(result2);
            Assert.True(result3);
        }
    }
}

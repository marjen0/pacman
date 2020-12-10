using Moq;
using Pacman.Classes.Interpreter;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Interpreter
{
    public class PauseGameExpressionTests
    {
        private PauseGameExpression CreatePauseGameExpression()
        {
            return new PauseGameExpression();
        }

        [Fact]
        public void Interpret_InterpretsPressedPButton_OnlyPButtonPressReturnsTrue()
        {
            // Arrange
            var pauseGameExpression = this.CreatePauseGameExpression();
            Context context1 = new Context("");
            Context context2 = new Context("q");
            Context context3 = new Context("p");

            Form1.players.RemoveAll();
            while (Form1.players.GetCount() < 2)
                Form1.players.Add(new Player());

            // Act
            var result1 = pauseGameExpression.Interpret(context1);
            var result2 = pauseGameExpression.Interpret(context2);
            var result3 = pauseGameExpression.Interpret(context3);

            // Assert
            Assert.False(result1);
            Assert.False(result2);
            Assert.True(result3);
            Form1.players.RemoveAll();
        }
    }
}

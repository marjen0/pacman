using Microsoft.AspNetCore.SignalR.Client;
using Moq;
using Pacman.Classes.Interpreter;
using Pacman.Services;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Interpreter
{
    public class JoinGameExpressionTests
    {
        private JoinGameExpression CreateJoinGameExpression()
        {
            return new JoinGameExpression();
        }

        [Fact]
        public void Interpret_InterpretsPressedF1Button_OnlyF1ButtonPressReturnsTrue()
        {
            // Arrange
            var joinGameExpression = this.CreateJoinGameExpression();
            Context context1 = new Context("");
            Context context2 = new Context("f2");
            Context context3 = new Context("f1");

            Form1.players.RemoveAll();
            if (Form1.players.GetCount() < 1)
                Form1.players.Add(new Player());

            // Act
            var result1 = joinGameExpression.Interpret(context1);
            var result2 = joinGameExpression.Interpret(context2);
            var result3 = joinGameExpression.Interpret(context3);

            // Assert
            Assert.False(result1);
            Assert.False(result2);
            Assert.True(result3);
            Form1.players.RemoveAll();
        }
    }
}

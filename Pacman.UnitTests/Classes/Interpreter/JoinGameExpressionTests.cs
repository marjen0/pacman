using Moq;
using Pacman.Classes.Interpreter;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Interpreter
{
    public class JoinGameExpressionTests
    {
        private MockRepository mockRepository;



        public JoinGameExpressionTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private JoinGameExpression CreateJoinGameExpression()
        {
            return new JoinGameExpression();
        }

        [Fact]
        public void Interpret_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var joinGameExpression = this.CreateJoinGameExpression();
            Context context = null;

            // Act
            joinGameExpression.Interpret(
                context);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

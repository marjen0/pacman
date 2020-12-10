using Moq;
using Pacman.Classes.Interpreter;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Interpreter
{
    public class QuitGameExpressionTests
    {
        private MockRepository mockRepository;



        public QuitGameExpressionTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private QuitGameExpression CreateQuitGameExpression()
        {
            return new QuitGameExpression();
        }

        [Fact]
        public void Interpret_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var quitGameExpression = this.CreateQuitGameExpression();
            Context context = null;

            // Act
            quitGameExpression.Interpret(
                context);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

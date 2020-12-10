using Moq;
using Pacman.Classes.Interpreter;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Interpreter
{
    public class PauseGameExpressionTests
    {
        private MockRepository mockRepository;



        public PauseGameExpressionTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private PauseGameExpression CreatePauseGameExpression()
        {
            return new PauseGameExpression();
        }

        [Fact]
        public void Interpret_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pauseGameExpression = this.CreatePauseGameExpression();
            Context context = null;

            // Act
            pauseGameExpression.Interpret(
                context);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

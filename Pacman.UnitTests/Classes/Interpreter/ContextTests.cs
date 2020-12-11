using Moq;
using Pacman.Classes.Interpreter;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Interpreter
{
    public class ContextTests
    {
        private MockRepository mockRepository;



        public ContextTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Context CreateContext()
        {
            return new Context();
        }

        [Fact]
        public void TestMethod1()
        {
            // Arrange
            var context = this.CreateContext();

            // Act


            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

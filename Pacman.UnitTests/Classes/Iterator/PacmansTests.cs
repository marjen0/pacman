using Moq;
using Pacman.Classes.Iterator;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Iterator
{
    public class PacmansTests
    {
        private MockRepository mockRepository;



        public PacmansTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Pacmans CreatePacmans()
        {
            return new Pacmans();
        }

        [Fact]
        public void Add_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pacmans = this.CreatePacmans();
            Pacman p = null;

            // Act
            pacmans.Add(
                p);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetPacmans_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pacmans = this.CreatePacmans();

            // Act
            var result = pacmans.GetPacmans();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetCount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pacmans = this.CreatePacmans();

            // Act
            var result = pacmans.GetCount();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public void GetEnumerator_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var pacmans = this.CreatePacmans();

            // Act
            var result = pacmans.GetEnumerator();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}

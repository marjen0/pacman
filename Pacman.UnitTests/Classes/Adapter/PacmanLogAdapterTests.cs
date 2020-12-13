using Pacman;
using Pacman.Classes.Adapter;
using Pacman.Classes.Template;
using Pacman.Classes;
using System;
using Xunit;
using Pacman.Services;
using Moq;
using Pacman.Classes.Adapter;

namespace Pacman.UnitTests.Classes.Adapter
{
    public class PacmanLogAdapterTests : IDisposable
    {
        private Form1 _form;
        private FormElements _formElements;
        public PacmanLogAdapterTests()
        {
            _form = new Form1();
        }

        [Fact]
        public void LogData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            FormElements formElements = new FormElementsStandard();
            Pacman p = new RedPacman("pacmanId");
            ILog pacmanLogAdapter = new PacmanLogAdapter(p, _form);

            // Act
            p.AddPacmanImages();
            p.Set_Pacman();
            formElements.CreateFormElements(_form);
            pacmanLogAdapter.LogData(null);
            // Assert
            Assert.Equal(p.ToString()+"\n",_form.formElements.Log.Text);
        }

       [Theory]
       [InlineData("abc", "abc")]
       [InlineData("qwerty","qwerty")]
       [InlineData("myuniqueid", "myuniqueid")]
        public void getPacmanId_ReturnsCorrectID_True(string pacmanId, string expectedId)
        {
            // Arrange
            Pacman p = new RedPacman(pacmanId);
            Form1 form = new Form1();
            PacmanLogAdapter adapter = new PacmanLogAdapter(p, form);
            // Act
            string id = adapter.getPacmanId();

            // Assert
            Assert.Equal(expectedId, id);
        }

        public void Dispose()
        {
            _form.Dispose();
        }
    }
}

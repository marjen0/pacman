using Pacman.Classes.Template;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Template
{
    public class FormElementsMinimalTests : IDisposable
    {
        private Form1 _form;
        private FormElements _formElements;

        public FormElementsMinimalTests()
        {
            _form = new Form1();
            _formElements = new FormElementsMinimal();
        }
        [Fact]
        public void CreatePlayerOneScoreLabel__ShouldCreatePlayerScoreText__True()
        {
            // Arrange
    
            // Act

            _formElements.CreateFormElements(_form);
            // Assert
            Assert.NotNull(_formElements.PlayerOneScoreText);
        }

        [Fact]
        public void CreateLogBox__LogBoxNotCreated__True()
        {
            // Arrange
    
            // Act
            _formElements.CreateFormElements(_form);
            // Assert
            Assert.NotNull(_formElements.Log);
        }
        [Fact]
        public void CreateHighScoreLabel__LabelNotNull__True()
        {
            // Arrange
            // Act
            _formElements.CreateFormElements(_form);
            // Assert
            Assert.NotNull(_formElements.HighScoreText);
        }

        [Fact]
        public void CreateFormElements__InitialPlayerScoreText__True()
        {
            // Arrange
   
            // Act
            _formElements.CreateFormElements(_form);
            // Assert
            Assert.Equal("1UP", _formElements.PlayerOneScoreText.Text);
        }
        [Fact]
        public void CreateFormElements__HighScoreText__True()
        {
            // Arrange
   
            // Act
            _formElements.CreateFormElements(_form);
            // Assert
            Assert.Equal("HIGH SCORE", _formElements.HighScoreText.Text);
        }
        [Fact]
        public void CreateFormElements__LoggingBoxEnabled__True()
        {
            // Arrange

            // Act
            _formElements.CreateFormElements(_form);
            // Assert
            Assert.True(_formElements.Log.Enabled);
        }
        [Fact]
        public void CreateLogBox__ThrowsException__True()
        {
            // Arrange
            
            // Act
           
            // Assert
            Assert.Throws<NotImplementedException>(() =>_formElements.CreateLogBox(_form));
        }

        public void Dispose()
        {
            _form.Dispose();
        }
    }
}

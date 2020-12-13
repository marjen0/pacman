using Pacman;
using System;
using Xunit;
using Pacman.Classes.Template;
using System.Linq;

namespace Pacman.UnitTests.Classes.Template
{
    public class FormElementsStandardTests
    {
        private FormElements _formElements;
        private Form1 _form;

        public FormElementsStandardTests()
        {
            _formElements = new FormElementsStandard();
            _form = new Form1();
        }

        [Fact]
        public void CreatePlayerOneScoreLabel__ShouldCreatePlayerScoreText__True()
        {
            // Arrange
            
            // Act

            _formElements.CreateFormElements(_form);
            // Assert
            Assert.NotNull(_form.Controls.Find("PayerOneScoreLabel", false).FirstOrDefault());
        }

        [Fact]
        public void CreateLogBox__ShouldCreateLoggingBox__True()
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
        public void CreateFormElements__LoggingBoxEnabled__False()
        {
            // Arrange
    
            // Act
            _formElements.CreateFormElements(_form);
            // Assert
            Assert.False(_formElements.Log.Enabled);
        }
    }
}

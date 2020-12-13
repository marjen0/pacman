using Pacman.Classes.Template;
using System;
using Xunit;
using System.Drawing;

namespace Pacman.UnitTests.Classes.Template
{
    public class FormElementsBrightTests: IDisposable
    {
        private FormElements _formElements;
        private Form1 _form;

        public FormElementsBrightTests()
        {
            _formElements = new FormElementsBright();
            _form = new Form1();
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
        public void CreatePlayerOneScoreLabel__ForeColorGreenYellow__True()
        {
            // Arrange
   
            // Act

            _formElements.CreateFormElements(_form);
            // Assert
            Assert.Equal(Color.GreenYellow,_formElements.PlayerOneScoreText.ForeColor);
        }
        [Fact]
        public void CreateLogBox__ShouldCreateLoggingBox__True()
        {
            // Arrange
        
            // Act
            _formElements.CreateFormElements(new Form1());
            // Assert
            Assert.NotNull(_formElements.Log);
        }
        [Fact]
        public void CreateLogBox__BackColorGreenYellow__True()
        {
            // Arrange
        
            // Act

            _formElements.CreateFormElements(_form);
            // Assert
            Assert.Equal(Color.GreenYellow, _formElements.Log.BackColor);
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
        public void CreateHighScoreLabel__ForeColorGreenYellow__True()
        {
            // Arrange

            // Act

            _formElements.CreateFormElements(_form);
            // Assert
            Assert.Equal(Color.GreenYellow, _formElements.HighScoreText.ForeColor);
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

        public void Dispose()
        {
            _form.Dispose();
        }
    }
}

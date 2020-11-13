using Pacman;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes
{
    public class FormElementsTests
    {
        [Fact]
        public void CreateFormElements__ShouldCreatePlayerScoreText()
        {
            // Arrange
            var formElements = new FormElements();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.NotNull(formElements.PlayerOneScoreText);
        }

        [Fact]
        public void CreateFormElements__ShouldCreateLoggingBox()
        {
            // Arrange
            FormElements formElements = new FormElements();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.NotNull(formElements.Log);
        }
        [Fact] 
        public void CreateFormElements__ShouldCreateHighscoreText()
        {
            // Arrange
            FormElements formElements = new FormElements();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.NotNull(formElements.HighScoreText);
        }
        [Fact]
        public void CreateFormElements__InitialPlayerScoreText()
        {
            // Arrange
            FormElements formElements = new FormElements();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.Equal("1UP", formElements.PlayerOneScoreText.Text);
        }
        [Fact]
        public void CreateFormElements__HighScoreText()
        {
            // Arrange
            FormElements formElements = new FormElements();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.Equal("HIGH SCORE", formElements.HighScoreText.Text);
        }
        [Fact]
        public void CreateFormElements__LoggingBoxEnabled__False()
        {
            // Arrange
            FormElements formElements = new FormElements();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.False(formElements.Log.Enabled);
        }
    }
}

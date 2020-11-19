using Pacman;
using System;
using Xunit;
using Pacman.Classes.Template;
using System.Linq;

namespace Pacman.UnitTests.Classes.Template
{
    public class FormElementsStandardTests
    {
        [Fact]
        public void CreatePlayerOneScoreLabel__ShouldCreatePlayerScoreText__True()
        {
            // Arrange
            FormElements formElements = new FormElementsStandard();
            Form1 form = new Form1();
            // Act

            formElements.CreateFormElements(form);
            // Assert
            Assert.NotNull(form.Controls.Find("PayerOneScoreLabel", false).FirstOrDefault());
        }

        [Fact]
        public void CreateLogBox__ShouldCreateLoggingBox__True()
        {
            // Arrange
            FormElements formElements = new FormElementsStandard();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.NotNull(formElements.Log);
        }
        [Fact] 
        public void CreateHighScoreLabel__LabelNotNull__True()
        {
            // Arrange
            FormElements formElements = new FormElementsStandard();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.NotNull(formElements.HighScoreText);
        }
        [Fact]
        public void CreateFormElements__InitialPlayerScoreText__True()
        {
            // Arrange
            FormElements formElements = new FormElementsStandard();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.Equal("1UP", formElements.PlayerOneScoreText.Text);
        }
        [Fact]
        public void CreateFormElements__HighScoreText__True()
        {
            // Arrange
            FormElements formElements = new FormElementsStandard();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.Equal("HIGH SCORE", formElements.HighScoreText.Text);
        }
        [Fact]
        public void CreateFormElements__LoggingBoxEnabled__False()
        {
            // Arrange
            FormElements formElements = new FormElementsStandard();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.False(formElements.Log.Enabled);
        }
    }
}

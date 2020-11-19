using Pacman.Classes.Template;
using System;
using Xunit;
using System.Drawing;

namespace Pacman.UnitTests.Classes.Template
{
    public class FormElementsBrightTests
    {
        [Fact]
        public void CreatePlayerOneScoreLabel__ShouldCreatePlayerScoreText__True()
        {
            // Arrange
            FormElements formElements = new FormElementsBright();
            Form1 form = new Form1();
            // Act

            formElements.CreateFormElements(form);
            // Assert
            Assert.NotNull(formElements.PlayerOneScoreText);
        }
        [Fact]
        public void CreatePlayerOneScoreLabel__ForeColorGreenYellow__True()
        {
            // Arrange
            FormElements formElements = new FormElementsBright();
            Form1 form = new Form1();
            // Act

            formElements.CreateFormElements(form);
            // Assert
            Assert.Equal(Color.GreenYellow,formElements.PlayerOneScoreText.ForeColor);
        }
        [Fact]
        public void CreateLogBox__ShouldCreateLoggingBox__True()
        {
            // Arrange
            FormElements formElements = new FormElementsBright();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.NotNull(formElements.Log);
        }
        [Fact]
        public void CreateLogBox__BackColorGreenYellow__True()
        {
            // Arrange
            FormElements formElements = new FormElementsBright();
            Form1 form = new Form1();
            // Act

            formElements.CreateFormElements(form);
            // Assert
            Assert.Equal(Color.GreenYellow, formElements.Log.BackColor);
        }
        [Fact]
        public void CreateHighScoreLabel__LabelNotNull__True()
        {
            // Arrange
            FormElements formElements = new FormElementsBright();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.NotNull(formElements.HighScoreText);
        }
        [Fact]
        public void CreateHighScoreLabel__ForeColorGreenYellow__True()
        {
            // Arrange
            FormElements formElements = new FormElementsBright();
            Form1 form = new Form1();
            // Act

            formElements.CreateFormElements(form);
            // Assert
            Assert.Equal(Color.GreenYellow, formElements.HighScoreText.ForeColor);
        }
        [Fact]
        public void CreateFormElements__InitialPlayerScoreText__True()
        {
            // Arrange
            FormElements formElements = new FormElementsBright();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.Equal("1UP", formElements.PlayerOneScoreText.Text);
        }
        [Fact]
        public void CreateFormElements__HighScoreText__True()
        {
            // Arrange
            FormElements formElements = new FormElementsBright();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.Equal("HIGH SCORE", formElements.HighScoreText.Text);
        }
        [Fact]
        public void CreateFormElements__LoggingBoxEnabled__True()
        {
            // Arrange
            FormElements formElements = new FormElementsBright();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.True(formElements.Log.Enabled);
        }
    }
}

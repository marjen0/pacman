using Pacman.Classes.Template;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Template
{
    public class FormElementsMinimalTests
    {
        [Fact]
        public void CreatePlayerOneScoreLabel__ShouldCreatePlayerScoreText__True()
        {
            // Arrange
            FormElements formElements = new FormElementsMinimal();
            Form1 form = new Form1();
            // Act

            formElements.CreateFormElements(form);
            // Assert
            Assert.NotNull(formElements.PlayerOneScoreText);
        }

        [Fact]
        public void CreateLogBox__LogBoxNotCreated__True()
        {
            // Arrange
            FormElements formElements = new FormElementsMinimal();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.NotNull(formElements.Log);
        }
        [Fact]
        public void CreateHighScoreLabel__LabelNotNull__True()
        {
            // Arrange
            FormElements formElements = new FormElementsMinimal();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.NotNull(formElements.HighScoreText);
        }

        [Fact]
        public void CreateFormElements__InitialPlayerScoreText__True()
        {
            // Arrange
            FormElements formElements = new FormElementsMinimal();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.Equal("1UP", formElements.PlayerOneScoreText.Text);
        }
        [Fact]
        public void CreateFormElements__HighScoreText__True()
        {
            // Arrange
            FormElements formElements = new FormElementsMinimal();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.Equal("HIGH SCORE", formElements.HighScoreText.Text);
        }
        [Fact]
        public void CreateFormElements__LoggingBoxEnabled__True()
        {
            // Arrange
            FormElements formElements = new FormElementsMinimal();
            // Act
            formElements.CreateFormElements(new Form1());
            // Assert
            Assert.True(formElements.Log.Enabled);
        }
        [Fact]
        public void CreateLogBox__ThrowsException__True()
        {
            // Arrange
            FormElements formElements = new FormElementsMinimal();
            // Act
           
            // Assert
            Assert.Throws<NotImplementedException>(() =>formElements.CreateLogBox(new Form1()));
        }

    }
}

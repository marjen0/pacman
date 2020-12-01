using Pacman;
using Pacman.Classes.Adapter;
using Pacman.Classes.Template;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Adapter
{
    public class PlayerLogAdapterTests
    {
        [Fact]
        public void LogData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Form1 form = new Form1();
            FormElements formElements = new FormElementsStandard();
            Player p = new Player("id", "name");
            AbstractLogger playerLogAdapter = new PlayerLogAdapter(p, form);
            formElements.CreateFormElements(form);
            // Act
            playerLogAdapter.LogData(null);

            // Assert
            Assert.Equal(p.ToString()+"\n", form.formElements.Log.Text);
        }

        [Fact]
        public void getPlayerId_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Form1 form = new Form1();
            Player p = new Player("id", "name");
            PlayerLogAdapter playerLogAdapter = new PlayerLogAdapter(p, form);

            // Act
            string id = playerLogAdapter.getPlayerId();

            // Assert
            Assert.Equal("id", id);
        }
    }
}

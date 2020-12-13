using Pacman;
using Pacman.Classes.Adapter;
using Pacman.Classes.Template;
using System;
using Xunit;

namespace Pacman.UnitTests.Classes.Adapter
{
    public class PlayerLogAdapterTests:IDisposable
    {
        private Form1 _form;

        public PlayerLogAdapterTests()
        {
            _form = new Form1();
        }

        [Theory]
        [InlineData("id", "name")]
        [InlineData("adgjl","Joshua")]
        [InlineData("zxcvbnm","Mathew")]
        public void LogData_LogsPlayerData_LogboxHasPlayerData(string playerId, string playerName)
        {
            // Arrange
            FormElements formElements = new FormElementsStandard();
            Player p = new Player(playerId, playerName);
            ILog playerLogAdapter = new PlayerLogAdapter(p, _form);
            formElements.CreateFormElements(_form);
            // Act
            playerLogAdapter.LogData(null);

            // Assert
            Assert.Equal(p.ToString()+"\n", _form.formElements.Log.Text);
        }

        [Theory]
        [InlineData("id")]
        [InlineData("adgjl")]
        [InlineData("zxcvbnm")]
        public void getPlayerId_ReturnsCorrectPlayerId_True(string playerId)
        {
            // Arrange
            Player p = new Player(playerId, "name");
            PlayerLogAdapter playerLogAdapter = new PlayerLogAdapter(p, _form);

            // Act
            string id = playerLogAdapter.getPlayerId();

            // Assert
            Assert.Equal(playerId, id);
        }

        public void Dispose()
        {
            _form.Dispose();
        }
    }
}

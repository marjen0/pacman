using Pacman;
using Pacman.Classes.Adapter;
using Pacman.Classes.Template;
using Pacman.Classes;
using System;
using Xunit;
using Pacman.Services;
using Moq;

namespace Pacman.UnitTests.Classes.Adapter
{
    public class PacmanLogAdapterTests
    {
        [Fact]
        public void LogData_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            Form1 form = new Form1();
            FormElements formElements = new FormElementsStandard();
            Pacman p = new RedPacman("pacmanId");
            AbstractLogger pacmanLogAdapter = new PacmanLogAdapter(p, form);

            // Act
            p.AddPacmanImages();
            p.Set_Pacman();
            formElements.CreateFormElements(form);
            pacmanLogAdapter.LogData(null);
            // Assert
            Assert.Equal(p.ToString()+"\n",form.formElements.Log.Text);
        }

       [Fact]
        public void getPacmanId_ReturnsCorrectID_True()
        {
            // Arrange
            Pacman p = new RedPacman("qwe147");
            Form1 form = new Form1();
            PacmanLogAdapter adapter = new PacmanLogAdapter(p, form);
            // Act
            string id = adapter.getPacmanId();

            // Assert
            Assert.Equal("qwe147", id);
        }
    }
}

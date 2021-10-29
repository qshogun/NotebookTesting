using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Faker;

namespace NotebookTesting
{
    public class NotepadSession
    {
        
        [TestClass]
        public class SmokeTests : TestSuite
        {
            private NotepadMain notepadMain;
            private FileMenu fileMenu;

            [TestInitialize]
            [Obsolete]
            public void InitializeTests()
            {
                notepadMain = new NotepadMain(driver);
                fileMenu = new FileMenu(driver);
                notepadMain.DeleteAllText();
                Assert.AreEqual(string.Empty, notepadMain.EditBox.Text);
            }
            [TestMethod]
            public void CanType()
            {
                // Arrange
                var randomWord = Name.First();
                // Act
                notepadMain.TypeTextInEditBox(randomWord);
                // Assert
                Assert.AreEqual(randomWord, notepadMain.EditBox.Text);
            }
            [TestMethod]
            public void CanDeleteAll()
            {
                // Arrange
                var randomWord = Name.First();
                // Act
                notepadMain.TypeTextInEditBox(randomWord)
                    .DeleteAllText();
                // Assert
                Assert.AreEqual(string.Empty, notepadMain.EditBox.Text);
            }
            [TestMethod]
            public void CanClose()
            {
                // Arrange

                // Act
                notepadMain.FileMenu.Click();
                fileMenu.CloseButton.Click();
                // Assert
                // TODO
            }
            
            [TestCleanup]
            public void CloseApp()
            {
                notepadMain.QuitDriver();
            }
        }
    }
}
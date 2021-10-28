using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Faker;

namespace NotebookTesting
{
    public class NotepadSession
    {
        private const string _WinAPPDriverServer = "http://127.0.0.1:4723";
        private const string _ApplicationPathOrAppName = @"C:\Windows\System32\notepad.exe";

        [TestClass]
        public class SmokeTests
        {
            private NotepadMain notepadMain;

            [TestInitialize]
            [Obsolete]
            public void initializeTests()
            {
                notepadMain = new NotepadMain(_ApplicationPathOrAppName, _WinAPPDriverServer);
                notepadMain.DeleteAllText();
                Assert.AreEqual(string.Empty, notepadMain.EditBox.Text);

            }
            [TestMethod]
            public void T0010_canType()
            {
                // Arrange
                var randomWord = Name.First();
                // Act
                notepadMain.TypeTextInEditBox(randomWord);
                // Assert
                Assert.AreEqual(randomWord, notepadMain.EditBox.Text);
            }
            [TestMethod]
            public void T0020_canDeleteAll()
            {
                // Arrange
                var randomWord = Name.First();
                // Act
                notepadMain.TypeTextInEditBox(randomWord)
                    .DeleteAllText();
                // Assert
                Assert.AreEqual(string.Empty, notepadMain.EditBox.Text);
            }
            
            [TestCleanup]
            public void closeApp()
            {
                notepadMain.QuitDriver();

            }
        }
    }
}
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
            private SavePopUpDialog savePopUpDialog;

            [TestInitialize]
            [Obsolete]
            public void InitializeTests()
            {
                notepadMain = new NotepadMain(driver);
                fileMenu = new FileMenu(driver);
                savePopUpDialog = new SavePopUpDialog(driver);
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
            public void CanSaveFile()
            {
                // Arrange
                var randomText = Lorem.Sentence(minWordCount: 3);
                var randomWord = Name.First();
                
                // Act
                notepadMain.TypeTextInEditBox(randomText)
                    .FileMenu.Click();
                fileMenu.SaveAsButton.Click();
                savePopUpDialog.TypeFileName(randomWord)
                    .SaveButton.Click();

                // Assert
                Assert.IsTrue(driver.Title.Contains(randomWord));
            }
            
            [TestCleanup]
            public void CloseApp()
            {
                if(driver!=null)
                {
                    driver.Close();
                    try
                    {
                        notepadMain.DontSaveButton.Click();
                    } catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                driver.Quit();
            }
        }
    }
}
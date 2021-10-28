using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotebookTesting
{
    public class NotepadSession
    {
        private const string winAPPDriverServer = "http://127.0.0.1:4723";
        private const string applicationPathOrAppName = @"C:\Windows\System32\notepad.exe";

        [TestClass]
        public class SmokeTests
        {
            private NotepadMain notepadMain;



            [TestInitialize]
            [Obsolete]
            public void initializeTests()
            {
                notepadMain = new NotepadMain(applicationPathOrAppName, winAPPDriverServer);

            }

            [TestMethod]
            public void T0010_canType()
            {
                notepadMain.TypeRandomWordInEditBox()
                    .IsTextEqual();
            }
            
            [TestMethod]
            public void T0020_canDeleteAll()
            {
                notepadMain.TypeRandomWordInEditBox()
                    .DeleteAllText()
                    .IsBlank();
            }
            

            [TestCleanup]
            public void closeApp()
            {
                notepadMain.QuitDriver();

            }
        }
    }
    
}
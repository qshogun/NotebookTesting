using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotebookTesting
{
    public class NotepadMain : BasePage
    {
        private WindowsDriver<WindowsElement> driver;
        public WindowsElement EditBox => driver.FindElement(By.ClassName("Edit"));

        [Obsolete]
        public NotepadMain(string applicationPathOrAppName, string winAPPDriverServer)
            : base(applicationPathOrAppName, winAPPDriverServer)
        {
            this.driver = GetDriver();
            PageFactory.InitElements(this.driver, this);
        }
        public NotepadMain TypeTextInEditBox(string text)
        {
            EditBox.SendKeys(text);
            return this;
        }
        public NotepadMain DeleteAllText()
        {
            EditBox.SendKeys(Keys.Control + 'a');
            EditBox.SendKeys(Keys.Delete);
            return this;
        }
        public NotepadMain IsBlank()
        {
            Assert.AreEqual(string.Empty, EditBox.Text);
            return this;
        }
    }
}
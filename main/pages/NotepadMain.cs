using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Faker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotebookTesting
{
    public class NotepadMain : BasePage
    {
        private WindowsDriver<WindowsElement> driver;

        //[FindsBy(How = How.ClassName, Using = "Edit")]
        //public WindowsElement editBox { get; set; }

        public By EditBox { get; set; } = By.ClassName("Edit");

        protected WindowsElement EditBoxElement()
        {
            return driver.FindElement(EditBox);
        }


        protected static WindowsElement plik;

        [Obsolete]
        public NotepadMain(string applicationPathOrAppName, string winAPPDriverServer)
            : base(applicationPathOrAppName, winAPPDriverServer)
        {
           // this.driver = GetDriver();
            PageFactory.InitElements(this.driver, this);
        }

        public NotepadMain TypeRandomWordInEditBox()
        {
            string randomWord = Name.First();
            EditBoxElement().SendKeys(randomWord);
            return this;
        }
        public NotepadMain DeleteAllText()
        {
            EditBoxElement().SendKeys(Keys.Control + 'a');
            EditBoxElement().SendKeys(Keys.Delete);
            return this;
        }
        public NotepadMain IsBlank()
        {
            Assert.AreEqual(string.Empty, EditBoxElement().Text);
            return this;
        }
        
    }
}
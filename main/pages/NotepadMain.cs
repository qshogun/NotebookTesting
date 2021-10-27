using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
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
        protected static WindowsElement zapisz;
        protected static WindowsElement nazwaPliku;
        protected static WindowsElement zapiszButton;

        [Obsolete]
        public NotepadMain(string applicationPathOrAppName, string winAPPDriverServer)
            : base(applicationPathOrAppName, winAPPDriverServer)
        {
            this.driver = getDriver();
            PageFactory.InitElements(driver, this);
        }

        public NotepadMain typeRandomWordInEditBox()
        {
            string randomWord = Name.First();
            EditBoxElement().SendKeys(randomWord);
            return this;
        }
        public NotepadMain deleteAllText()
        {
            EditBoxElement().SendKeys(Keys.Control + 'a');
            EditBoxElement().SendKeys(Keys.Delete);
            return this;
        }
        public NotepadMain isBlank()
        {
            Assert.IsNull(EditBoxElement().Text);
            return this;
        }
        
    }
}

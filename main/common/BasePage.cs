using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.PageObjects;

namespace NotebookTesting
{
    public class BasePage
    {
        
        public WindowsDriver<WindowsElement> driver { get; set; }

        public BasePage(WindowsDriver<WindowsElement> driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }        
        
        public WindowsDriver<WindowsElement> GetDriver()
        {
            return driver;
        }
        public void EnterText(WindowsElement windowsElement, string text)
        {
            try
            {
                if(windowsElement.Displayed)
                {
                    windowsElement.SendKeys(text);
                }
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
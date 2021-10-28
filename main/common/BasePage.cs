using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;


namespace NotebookTesting
{
    public class BasePage
    {
        
        private const int TimeOutForElement = 20;
        private WindowsDriver<WindowsElement> driver { get; set; }

        public BasePage()
        {

        }
        public BasePage(string applicationPathOrAppName, string winAPPDriverServer)
        {
            try
            {
                AppiumOptions appCapabilities = new AppiumOptions();
                appCapabilities.AddAdditionalCapability("app", applicationPathOrAppName);
                driver = new WindowsDriver<WindowsElement>(new Uri(winAPPDriverServer), appCapabilities);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TimeOutForElement);

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

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

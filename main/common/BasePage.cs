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
        
        private const int TIME_OUT_FOR_ELEMENT = 20;
        private WindowsDriver<WindowsElement> driver;

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
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TIME_OUT_FOR_ELEMENT);

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public WindowsDriver<WindowsElement> getDriver()
        {
            return driver;
        }

        public void enterText(WindowsElement windowsElement, string text)
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
        public void quitDriver()
        {
            driver.Quit();
        }
    }
}

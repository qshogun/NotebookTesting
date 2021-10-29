using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;

namespace NotebookTesting
{
    public class TestSuite
    {
        // TODO
        // private static Dictionary<string, string> setupFile = Helpers.GetData("TestsSetup.txt");
        // private string _WinAPPDriverServer = setupFile["WinAPPDriverServer"];
        // private string _ApplicationPathOrAppName = setupFile["ApplicationPathOrAppName"];
        private const string _WinAPPDriverServer = "http://127.0.0.1:4723";
        private const string _ApplicationPathOrAppName = @"C:\Windows\System32\notepad.exe";
        private const int TimeOutForElement = 20;
        public WindowsDriver<WindowsElement> driver;

        [TestInitialize]
        public void Setup()
        {
            AppiumOptions appCapabilities = new AppiumOptions();
            appCapabilities.AddAdditionalCapability("app", _ApplicationPathOrAppName);
            driver = new WindowsDriver<WindowsElement>(new Uri(_WinAPPDriverServer), appCapabilities);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TimeOutForElement);
        }
    }
}
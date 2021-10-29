using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace NotebookTesting
{
    public class FileMenu : BasePage
    {
        // Windows Elements visible under File menu
        public WindowsElement NewFileButton => driver.FindElementByAccessibilityId("1");
        public WindowsElement NewWindowButton => driver.FindElementByAccessibilityId("8");
        public WindowsElement OpenButton => driver.FindElementByAccessibilityId("2");
        public WindowsElement SaveButton => driver.FindElementByAccessibilityId("3");
        public WindowsElement SaveAsButton => driver.FindElementByAccessibilityId("4");
        public WindowsElement SettingsButton => driver.FindElementByAccessibilityId("5");
        public WindowsElement PrintButton => driver.FindElementByAccessibilityId("6");
        public WindowsElement CloseButton => driver.FindElementByAccessibilityId("7");

        public FileMenu(WindowsDriver<WindowsElement> driver)
            : base(driver)
        {
        }
    }
}
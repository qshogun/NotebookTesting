using System;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium;

namespace NotebookTesting
{
    public class NotepadMain : BasePage
    {
        // Windows Elements visible on the main screen
        public WindowsElement EditBox => driver.FindElement(By.ClassName("Edit"));
        public WindowsElement FileMenu => driver.FindElementByName("Plik");
        public WindowsElement EditMenu => driver.FindElementByName("Edycja");
        public WindowsElement FormatMenu => driver.FindElementByName("Format");
        public WindowsElement ViewMenu => driver.FindElementByName("Widok");
        public WindowsElement HelpMenu => driver.FindElementByName("Pomoc");

        // Windows Elements visible on exit pop up (when changes are not saved)
        public WindowsElement MessagePopUp => driver.FindElementByAccessibilityId("MainInstruction");
        public WindowsElement SaveButton => driver.FindElementByAccessibilityId("CommandButton_6");
        public WindowsElement DontSaveButton => driver.FindElementByAccessibilityId("CommandButton_7");
        public WindowsElement CancelButton => driver.FindElementByAccessibilityId("CommandButton_2");

        [Obsolete]
        public NotepadMain(WindowsDriver<WindowsElement> driver)
            : base(driver)
        {
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
    }
}
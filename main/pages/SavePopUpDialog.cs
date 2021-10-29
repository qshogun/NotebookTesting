using OpenQA.Selenium.Appium.Windows;

namespace NotebookTesting
{
    public class SavePopUpDialog : BasePage
    {
        // Windows Elements visible under File menu
        public WindowsElement FileNameField => driver.FindElementByAccessibilityId("1001");
        public WindowsElement SaveButton => driver.FindElementByAccessibilityId("1");
        public WindowsElement CancelButton => driver.FindElementByAccessibilityId("2");


        public SavePopUpDialog(WindowsDriver<WindowsElement> driver)
            : base(driver)
        {
        }

        public SavePopUpDialog TypeFileName(string fileName)
        {
            FileNameField.SendKeys(fileName);
            return this;
        }
    }
}
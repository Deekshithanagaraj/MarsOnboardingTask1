using MarsOnboardingTask1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsOnboardingTask1.Pages
{
    public class Language: CommonDriver
    {

        //Finding elements
        private IWebElement addNewLanguageButton => driver.FindElement(By.XPath("//div[@data-tab='first']//div[@class ='ui teal button ']"));
        private IWebElement addLanguage => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private IWebElement dropdownLanguage => driver.FindElement(By.XPath("//div[@data-tab='first']//select[@class='ui dropdown']"));
        private IWebElement AddButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement language => driver.FindElement(By.XPath(e_language));
        private IWebElement languageLevel => driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[2]"));
        private IWebElement editLanguageButton => driver.FindElement(By.XPath(e_editLanguageButton));
        private IWebElement editLanguage => driver.FindElement(By.XPath("//input[@placeholder='Add Language']"));
        private IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement DeleteButton => driver.FindElement(By.XPath("//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[2]/i"));
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private IWebElement tabOption => driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[1]"));

        //Elements for wait
        private string e_language = "//div[@data-tab='first']//tbody[last()]/tr/td[1]";
        private string e_editLanguageButton = "//div[@data-tab='first']//tbody[last()]/tr/td[3]/span[1]/i";
        private string e_message = "//div[@class='ns-box-inner']";
        private string e_waitForTab = "//div[@class='ui top attached tabular menu']";


        public void AddALanguage(string language, string languagelevel)
        {
            //Click Add New Language
            addNewLanguageButton.Click();

            //Enter language
            addLanguage.SendKeys(language);

            //Choose Language Level
            var selectLanguageDropdown = new SelectElement(dropdownLanguage);
            selectLanguageDropdown.SelectByValue(languagelevel);

            //Click Add
            AddButton.Click();
        }
        public string GetLanguage()
        {
            //Get last record language text
            try
            {
                Waits.WaitToBeVisible(driver, "XPath", e_language, 5);
                return language.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
        public string GetLanguageLevel()
        {
            //Get last record Language level
            return languageLevel.Text;
        }

        public void EditLanguage(string language, string languagelevel)
        {
            //Wait for edit button

            Waits.WaitToBeClickable(driver, "XPath", e_editLanguageButton, 5);

            //Click edit button
            editLanguageButton.Click();

            //Edit language
            editLanguage.Clear();
            editLanguage.SendKeys(language);

            //Edit Lanuage Level
            var selectLanguage = new SelectElement(dropdownLanguage);
            selectLanguage.SelectByValue(languagelevel);

            //Click Update
            UpdateButton.Click();
        }

        public void DeleteLanguage(string language)
        {
            try
            {
                string strLanguage = GetLanguage();
                if (strLanguage == language)
                {
                    //Click delete
                    DeleteButton.Click();
                }
                else
                {
                    Assert.Fail("No matching language found.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No language is found", ex.Message);
            }
        }

        public string GetMessage()
        {
            Waits.WaitToBeVisible(driver, "XPath", e_message, 3);
            return message.Text;
        }
        public void ClickAnyTab(string tab)
        {
            //Wait for tabs to be visible
            Waits.WaitToBeVisible(driver, "XPath", e_waitForTab, 3);

            //Click on specified tab
            tabOption.Click();
        }

    }
}
using MarsOnboardingTask1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MarsOnboardingTask1.Pages
{
    public class Skill: CommonDriver
    {

        //Finding for elements
        private IWebElement message => driver.FindElement(By.XPath(e_message));
        private IWebElement tabOption => driver.FindElement(By.XPath("//div[@class = 'ui top attached tabular menu']/a[2]"));
        private IWebElement AddNewButton => driver.FindElement(By.XPath(e_AddNewButton));
        private IWebElement addSkill => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement SkillLeveldropdown => driver.FindElement(By.XPath("//select[@name='level']"));
        private IWebElement AddButton => driver.FindElement(By.XPath("//input[@value='Add']"));
        private IWebElement skill => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[1]"));
        private IWebElement addedSkillLevel => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[2]"));
        private IWebElement UpdateButton => driver.FindElement(By.XPath(e_UpdateButton));
        private IWebElement editSkill => driver.FindElement(By.XPath("//input[@placeholder='Add Skill']"));
        private IWebElement CompleteUpdateButton => driver.FindElement(By.XPath("//input[@value='Update']"));
        private IWebElement deletedSkill => driver.FindElement(By.XPath(e_recordLastSkill));

        //Elements for wait
        private string e_message = "//div[@class='ns-box-inner']";
        private string e_tab = "//div[@class='ui top attached tabular menu']";
        private string e_AddNewButton = "//div[@class='ui teal button']";
        private string e_UpdateButton = "//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[1]";
        private string e_recordLastSkill = "//div[@data-tab='second']//table/tbody[last()]/tr/td[1]";
       
        private IWebElement DeleteButton => driver.FindElement(By.XPath("//div[@data-tab='second']//table/tbody[last()]/tr/td[3]/span[2]"));


        public string GetMessage()
        {

            Waits.WaitToBeVisible(driver, "XPath", e_message, 3);
            return message.Text;
        }
        public void ClickAnyTab(string tab)
        {
            //Wait for tabs to be visible
            Waits.WaitToBeVisible(driver, "XPath", e_tab, 3);

            //Click on specified tab
            tabOption.Click();
        }


        public void AddSkill(string skill, string skillLevel)
        {
            //Wait Add new button to be visible
            Waits.WaitToBeClickable(driver, "XPath", e_AddNewButton, 3);

            //Click Add new
            AddNewButton.Click();

            //Enter skill
            addSkill.SendKeys(skill);

            //Select skill level
            var selectSkillLevel = new SelectElement(SkillLeveldropdown);
            selectSkillLevel.SelectByValue(skillLevel);

            //Click add
            AddButton.Click();
        }
        public string GetSkill()
        {
            //get last skill record 
            try
            {
                return skill.Text;
            }
            catch (Exception)
            {
                return "locator not found";
            }
        }
        public string GetSkillLevel()
        {
            //Get last skill level record
            return addedSkillLevel.Text;
        }

        public void EditSkill(string skill, string skillLevel)
        {
            //Wait
            Waits.WaitToBeClickable(driver, "XPath", e_UpdateButton, 3);

            //Click edit button
            UpdateButton.Click();

            //Edit Skills
            editSkill.Clear();
            editSkill.SendKeys(skill);

            //Edit Skill level
            var selectSkillLevel = new SelectElement(SkillLeveldropdown);
            selectSkillLevel.SelectByValue(skillLevel);

            //Click Update
            CompleteUpdateButton.Click();
        }

        public void DeleteSkill(string skill)
        {
            try
            {
                //Wait for Skill loaded
                Waits.WaitToBeVisible(driver, "XPath", e_recordLastSkill, 3);

                //Check if skill is the one to be deleted
                if (deletedSkill.Text == skill)
                {
                    //Click Delete button
                    DeleteButton.Click();
                }
                else
                {
                    Assert.Fail("No matching skill is not found.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("No skill is found.", ex.Message);
            }
        }

    }
}
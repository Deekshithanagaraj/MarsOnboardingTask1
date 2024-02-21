using MarsOnboardingTask1.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;


namespace MarsOnboardingTask1.Pages
{
    public class LoginPage: CommonDriver
    {

        LoginPage LoginPageObj;

        public void LogInActions()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");

            try
            {
                //click Sign In
                IWebElement signInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
                signInButton.Click();

                //Enter email address
                IWebElement emailAddress = driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
                emailAddress.SendKeys("deekshithanagaraj@gmail.com");

                //Enter password
                IWebElement password = driver.FindElement(By.Name("password"));
                password.SendKeys("123@123");

                //Click Login
                IWebElement loginButton = driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));
                loginButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Portal does not launch.", ex.Message);
            }

        }
    }
}

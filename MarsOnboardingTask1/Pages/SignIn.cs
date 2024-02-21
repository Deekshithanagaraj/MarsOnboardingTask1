using OpenQA.Selenium;
using MarsOnboardingTask1.Utilities;


namespace MarsOnboardingTask1.Pages
{

    public class SignIn: CommonDriver
    {
        //Finding for elements
        private IWebElement welcomeText => driver.FindElement(By.XPath(e_wecomeText));

        //Element for wait
        private string e_wecomeText = "//*[@id=\"account-profile-section\"]/div/div[1]/div[2]/div/span";

        public string getWecomeText()
        {

            Waits.WaitToBeVisible(driver, "XPath", e_wecomeText, 3);
            return welcomeText.Text;
        }
    }
}
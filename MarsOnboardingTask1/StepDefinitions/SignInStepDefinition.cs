using MarsOnboardingTask1.Utilities;
using NUnit.Framework;
using MarsOnboardingTask1.Pages;
using OpenQA.Selenium.Chrome;


namespace MarsOnboardingTask1.StepDefinitions
{
    [Binding]
    public class SignInStepDefinitions : CommonDriver
    {
        SignIn SignInObj;
        LoginPage LoginPageObj;

        [Given(@"I signed into the portal successfully")]
        public void GivenISignedIntoThePortalSuccessfully()
        {
            //Open Chrome browser
            driver = new ChromeDriver();

            //Initiate objects
            SignInObj = new SignIn();
            LoginPageObj = new LoginPage();

            //signin
            LoginPageObj.LogInActions();
        }

        [Then(@"I am able to see my profile page")]
        public void ThenIAmAbleToSeeMyProfilePage()
        {
            string welcomeText = SignInObj.getWecomeText();
            Assert.That(welcomeText == "Hi Deekshitha" || welcomeText == "Hi", "Actual welcome text and expected welcome text do not match");
            driver.Close();
        }
    }
}
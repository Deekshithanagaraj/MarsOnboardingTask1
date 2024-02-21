using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MarsOnboardingTask1.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private ChromeDriver driver;

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {

            driver = new ChromeDriver();

        }

        [AfterScenario]
        public void AfterScenario()
        {

            driver.Close();
        }
    }
}
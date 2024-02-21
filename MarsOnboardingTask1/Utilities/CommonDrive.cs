using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace MarsOnboardingTask1.Utilities
{
    [Binding]
    public class CommonDriver
    {
        public static IWebDriver driver;

        public static void Initialize()
        {
           driver = new ChromeDriver();
        }
        public void Close()
        {
            driver.Close();
        }

    }
}
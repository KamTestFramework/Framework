using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BasicQA.Inners
{
    [Binding]
    public sealed class Hooks1
    {
        public static IWebDriver driver;

        [BeforeScenario]
        public void Setup()
        {
            driver = new ChromeDriver();
            // driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qaworks.com");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicQA.Inners;
using BasicQA.PageObj;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BasicQA.StepDefinitions
{
    [Binding]
    public sealed class StepDefinition1 : AllPageObjects
    {
        public IWebDriver driver = Hooks1.driver;

        [Given(@"I am on the QAWorks Site")]
        public void GivenIAmOnTheQAWorksSite()
        {
            Homepage = new Homepage(driver);
            Homepage.ClickContactUs();
        }

        [Then(@"I should be able to contact QAWorks with the following information: (.*) and (.*) and (.*)")]
        public void ThenIShouldBeAbleToContactQAWorksWithTheFollowingInformationAndAnd(string name, string email, string message)
        {
            ContactUs = new ContactUs(driver);
            ContactUs.EnterDetails(name,email,message);
            ContactUs.PressSend();
        }

        [Then(@"I receive a valid error message when I enter Incorrect data such as: (.*) and (.*) and (.*)")]
        public void ThenIReceiveAValidErrorMessageWhenIEnterIncorrectDataSuchAsAndAnd(string name, string email, string message)
        {
            ContactUs = new ContactUs(driver);
            ContactUs.EnterDetails(name, email, message);
            ContactUs.PressSend();
            ContactUs.ValidationError();
        }

    }
}

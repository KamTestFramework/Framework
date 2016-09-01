using System.Drawing.Imaging;
using System.Linq;
using ClassLibrary1.Inners;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.PageObjects;

namespace BasicQA.PageObj
{
    public class ContactUs
    {
        #region PageObjects
        public IWebDriver _driver;


        readonly By _contactUsHeader = By.Id("ContactHead");

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$EmailBox")]
        private IWebElement _email;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_MessageBox")]
        private IWebElement _message;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_NameBox")]
        private IWebElement _name;

        [FindsBy(How = How.ClassName, Using = "SendButton")]
        private IWebElement _sendBtn;

        #endregion

        public ContactUs(IWebDriver driver)
        {
            _driver = driver;
            _driver.Sync();
            PageFactory.InitElements(_driver, this);
            if (!this._driver.ElementExist(_contactUsHeader))
            {
                Assert.Fail(
                     "Contact Us page is not being displayed, failing test please investigate, url = '{0}'",
                     driver.Url);
            }
        }

        public void EnterDetails(string name, string email, string message)
        {
            _name.SendKeys(name);
            _email.SendKeys(email);
            _message.SendKeys(message);
            _driver.FindElement(_contactUsHeader).Click();
        }

        public void PressSend()
        {
            _sendBtn.Click();
            VerifyError();
        }

        public void ValidationError()
        {
            string messages = "";
            var errorMessages = _driver.FindElements(By.CssSelector("span[id^='ctl00_MainContent_r']"));
            foreach (IWebElement message in errorMessages)
            {
                if (message.Displayed)
                {
                    messages = messages + message.Text + ". ";
                }
            }
            if (messages != "")
            {
                Assert.Fail("Validation Errors exist. They are: " + messages);
            }
        }

        public void VerifyError()
        {
            if (!this._driver.ElementExist(_contactUsHeader))
            {
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                ss.SaveAsFile("c:\\Temp\\ss.png", ImageFormat.Png);
                Assert.Fail("Submit Button DID NOT WORK");
            }
        }
    }
}


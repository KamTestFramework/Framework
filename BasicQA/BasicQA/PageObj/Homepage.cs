using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1.Inners;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace BasicQA.PageObj
{
    public class Homepage
    {
         #region PageObjects
        public IWebDriver _driver;

        [FindsBy(How = How.LinkText, Using = "Contact")]
        private IWebElement _contactUsLink;

        [FindsBy(How = How.ClassName, Using = "postcode-input")]
        private IWebElement _postcodeInput;

        #endregion
        public Homepage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Sync();
            PageFactory.InitElements(_driver, this);
            if (!this._contactUsLink.Displayed)
            {
                Assert.Fail(
                     "Book valuation button is not being displayed, failing test please investigate, url = '{0}'",
                     driver.Url);
            }
        }

        public void ClickContactUs()
        {
            _contactUsLink.Click();
        }
    }
}

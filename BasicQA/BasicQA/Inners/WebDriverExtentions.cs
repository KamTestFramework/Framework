using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
namespace ClassLibrary1.Inners
{
    public static class WebDriverExtentions
    {

        public static void Sync(this IWebDriver driver)
        {
            Thread.Sleep(1000);
            var driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(180));
            driverWait.IgnoreExceptionTypes(typeof(InvalidOperationException));
            driverWait.PollingInterval = TimeSpan.FromMilliseconds(500);
            try
            {
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            }
            catch (UnhandledAlertException)
            {
                return;
            }

            driverWait.Until(
                driverA =>
                {
                    try
                    {
                        var browserStatus = (string)((IJavaScriptExecutor)driverA).ExecuteScript("return document.readyState");
                        return string.Compare("complete", browserStatus, StringComparison.OrdinalIgnoreCase) == 0;
                    }
                    catch (NoSuchWindowException)
                    {
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
        }

        public static bool ElementExist(this IWebDriver driver, By by, int timeout = 10)
        {
            var value = false;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException));
            try
            {
                value = wait.Until(d => d.FindElements(by).Count > 0);
            }
            catch
            {
                return value;
            }

            return value;
        }
    }
}

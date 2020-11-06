using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDAutomation.Shared
{
    public class Utility
    {
        private IWebDriver _driver;
        private WebDriverWait _webDriverWait;

        public Utility(ScenarioContext context)
        {
            _driver = context["WEB_DRIVER"] as IWebDriver;
            _webDriverWait = context["webDriverWait"] as WebDriverWait;
        }

        public  void click(By byElement)
        {

            _driver.FindElement(byElement).Click();
        }

        public  void enterDetails(By byElement, string testToEnter)
        {
            WaitUntilElementVisible(byElement);
            _driver.FindElement(byElement).SendKeys(testToEnter);
        }

        public  string getTextOfElement(By byElement)
        {
            //WaitUntilElementContainsText(webelement, "Welcome");
            return _driver.FindElement(byElement).Text;
        }

        public  Func<IWebDriver, bool> AlertState()
        {
            return (_driver) =>
            {
                var alertState = false;
                try
                {
                    _driver.SwitchTo().Alert();
                    alertState = true;
                    return alertState;
                }
                catch (NoAlertPresentException)
                {
                    alertState = false;
                    return alertState;
                }
            };
        }
        public  bool AlertIsPresent()
        {

            try
            {
                _webDriverWait.Until(AlertState());

            }

            catch (WebDriverTimeoutException)
            {
                return false;
            }
            return true;
        }

        public  void AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }
        private  void WaitUntilElementContainsText(IWebElement webElement, string textToSearch)
        {
            _webDriverWait.PollingInterval = TimeSpan.FromSeconds(10);
            _webDriverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            _webDriverWait.Until(d =>
            {

                return webElement.Text.Contains(textToSearch);
            });
        }

        

        public bool WaitUntilElementVisible(By byElement)
        {
            return _webDriverWait.Until(d =>
            {
                return _driver.FindElement(byElement).Displayed && _driver.FindElement(byElement).Enabled;
            });
        }

    }
}

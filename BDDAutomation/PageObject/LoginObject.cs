using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace BDDAutomation.PageObject
{
    public class LoginObject 
    {
        private IWebDriver _driver;
        private WebDriverWait _webDriverWait;

        public LoginObject(ScenarioContext context)
        {
            _driver = context["WEB_DRIVER"] as IWebDriver;
            _webDriverWait = context["webDriverWait"] as WebDriverWait;
        }

        public IWebElement Username { get { return _driver.FindElement(By.Id("loginusername")); }  }

        public IWebElement Password { get { return _driver.FindElement(By.Id("loginpassword")); } }

        public IWebElement LoginButton { get { return _driver.FindElement(By.XPath("//button[text()='Log in']"));} }
        public IWebElement LoggedInUsername { get { return _driver.FindElement(By.XPath("//*[@id='nameofuser']")); } }



        //button[text()='Log in']
        public IWebElement LoginElement { get
            { return _driver.FindElement(By.Id("login2")); }
        }

        public void click(IWebElement webElement )
        {
            
            webElement.Click();
        }

        public void enterDetails(IWebElement webElement, string testToEnter)
        {
            WaitUntilElementVisible(webElement);
            webElement.SendKeys(testToEnter);
        }

        public string getTextOfElement(IWebElement webelement)
        {
            WaitUntilElementContainsText(webelement, "Welcome");
            return webelement.Text;
        }

        public static Func<IWebDriver, bool> AlertState()
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
        public bool  AlertIsPresent()
        {
           
            try
                {
                _webDriverWait.Until(AlertState());
               
                }
               
                catch(WebDriverTimeoutException)
                {
                    return false;
                }
            return true;
        }

        public void AcceptAlert()
        {
            _driver.SwitchTo().Alert().Accept();
        }
        private void WaitUntilElementContainsText(IWebElement webElement, string textToSearch)
        {
            _webDriverWait.PollingInterval = TimeSpan.FromSeconds(10);
            _webDriverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            _webDriverWait.Until(d =>
            {
               
                return webElement.Text.Contains(textToSearch);
            });
        }

        private void WaitUntilElementVisible(IWebElement webElement)
        {
            _webDriverWait.Until(d =>
            {

                return webElement.Displayed && webElement.Enabled;
            });
        }

    }
}
    
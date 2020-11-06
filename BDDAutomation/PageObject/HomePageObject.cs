using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDAutomation.PageObject
{
    
    public class HomePageObject
    {
        private IWebDriver _driver;
        private WebDriverWait _webDriverWait;
        public HomePageObject(ScenarioContext context)
        {
            _driver = context["WEB_DRIVER"] as IWebDriver;
            _webDriverWait = context["webDriverWait"] as WebDriverWait;
        }

        public string MobileName { get; set; }
        //public IWebElement LoginElement { get { return _driver.FindElement(By.Id("login2")); } }
        //public IWebElement HomeTab { get { return _driver.FindElement(By.XPath("//a[text()='Home ']")); } }

        //public IWebElement MobileToAdd { get { return _driver.FindElement(By.XPath("//a[text()='" + MobileName + "']")); } }

        public By LoginElement { get { return By.Id("login2"); } }
        public By HomeTab { get { return By.XPath("//a[text()='Home ']"); } }
        public By CartTab { get { return By.XPath("//a[text()='Cart']"); } }
        
        public By MobileToAdd { get { return By.XPath("//a[text()='" + MobileName + "']"); } }

    }
}

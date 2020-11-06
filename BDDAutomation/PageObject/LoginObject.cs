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

        //public IWebElement Username { get { return _driver.FindElement(By.Id("loginusername")); }  }

        //public IWebElement Password { get { return _driver.FindElement(By.Id("loginpassword")); } }

        //public IWebElement LoginButton { get { return _driver.FindElement(By.XPath("//button[text()='Log in']"));} }
        //public IWebElement LoggedInUsername { get { return _driver.FindElement(By.XPath("//*[@id='nameofuser']")); } }



        //button[text()='Log in']

        public By Username { get { return By.Id("loginusername"); } }

        public By Password { get { return By.Id("loginpassword"); } }

        public By LoginButton { get { return By.XPath("//button[text()='Log in']"); } }
        public By LoggedInUsername { get { return By.XPath("//*[@id='nameofuser']"); } }



    }
}
    
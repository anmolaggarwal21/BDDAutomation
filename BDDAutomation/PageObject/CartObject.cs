using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDAutomation.PageObject
{
    public class CartObject
    {

        private IWebDriver _driver;
        private WebDriverWait _webDriverWait;

        public CartObject(ScenarioContext context)
        {
            _driver = context["WEB_DRIVER"] as IWebDriver;
            _webDriverWait = context["webDriverWait"] as WebDriverWait;
        }
        public string ProductName { get; set; }
        public By ItemDescriptionLabel { get { return By.XPath("//*[text()='"+ ProductName + "']"); } }

        public By DeleteButton { get { return By.XPath("//*[text()='" + ProductName + "']/following-sibling::td[2]/a"); } }
    }
}

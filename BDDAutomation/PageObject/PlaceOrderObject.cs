using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDAutomation.PageObject
{
    public class PlaceOrderObject
    {
        private IWebDriver _driver;
        private WebDriverWait _webDriverWait;
        public PlaceOrderObject(ScenarioContext context)
        {
            _driver = context["WEB_DRIVER"] as IWebDriver;
            _webDriverWait = context["webDriverWait"] as WebDriverWait;
        }

        public By PlaceOrderLabel { get { return By.XPath("//*[@id='orderModalLabel']"); } }
        public By NameField { get { return By.XPath("//*[@id='name']"); } }
        public By CountryField { get { return By.XPath("//*[@id='country']"); } }
        public By CityField { get { return By.XPath("//*[@id='city']"); } }
        public By CardField { get { return By.XPath("//*[@id='card']"); } }
        public By MonthField { get { return By.XPath("//*[@id='month']"); } }
        public By YearField { get { return By.XPath("//*[@id='year']"); } }
        public By CloseButton { get { return By.XPath("//*[text()='Close']"); } }
        public By PurchaseButton { get { return By.XPath("//*[text()='Purchase']"); } }

        public By PurchaseValid { get { return By.XPath("//*[text()='Thank you for your purchase!']"); } }
        public By OKButton { get { return By.XPath("//button[text()='OK']"); } }

        public By PurchaseID { get { return By.XPath("//p[contains(text(),'Id')]"); } }

        //*[text()='Place Order']
    }
}

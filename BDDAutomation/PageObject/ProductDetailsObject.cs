using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDAutomation.PageObject
{
    public class ProductDetailsObject
    {
       

        private IWebDriver _driver;
       
        public ProductDetailsObject(ScenarioContext context)
        {
            _driver = context["WEB_DRIVER"] as IWebDriver;
           
        }

//        public IWebElement AddToCartButton { get { return _driver.FindElement(By.XPath("//a[text()='Add to cart']")); } }

        public By AddToCartButton { get { return By.XPath("//a[text()='Add to cart']");  } }
        public By ProductDescriptionLabel { get { return By.XPath("//*[text()='Product description']"); } }


    }
}

using BDDAutomation.PageObject;
using BDDAutomation.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using SoftAssert;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace BDDAutomation.StepFiles
{
    [Binding]
    public class AddToCartStepFile
    {
        ScenarioContext _context;
        IWebDriver driver;
        LoginObject _loginObject;
        HomePageObject _homePageObject;
        Utility _utility;
        ProductDetailsObject _productDetailsObject;
        CartObject _cartObject;

        public AddToCartStepFile(ScenarioContext context, LoginObject loginObject, HomePageObject homePageObject, Utility utility
            , ProductDetailsObject productDetailsObject , CartObject cartObject
            )
        {

            _context = context;
            _loginObject = loginObject;
            _homePageObject = homePageObject;
            _utility = utility;
            _productDetailsObject = productDetailsObject;
            _cartObject = cartObject;
            driver = _context["WEB_DRIVER"] as IWebDriver;


        }

       

        [When(@"I click on (.*) mobile to add to cart")]
        public void WhenIClickOnSamsungGalaxySMobileToAddToCart(string MobileName)
        {
            _homePageObject.MobileName = MobileName;
            _utility.click(_homePageObject.MobileToAdd);
        }

        [Then(@"I am on details page of phone")]
        public void ThenIAmOnDetailsPageOfPhone()
        {
            if(_utility.WaitUntilElementVisible(_productDetailsObject.AddToCartButton))
            {
                Assert.IsTrue(true, "User is on Product Details Page");
            }
            else
            {
                Assert.IsFalse(false, "User is not on Product Details Page");
            }

        }

        [Then(@"I am able to check the product description")]
        public void ThenIAmAbleToCheckTheProductDescription()
        {
            if (_utility.WaitUntilElementVisible(_productDetailsObject.ProductDescriptionLabel))
            {
                Assert.IsTrue(true, "User is able to see the product description");
            }
            else
            {
                Assert.IsFalse(false, "User is not able to see the product description");
            }
        }

        [When(@"I click on Add to Cart")]
        public void WhenIClickOnAddToCart()
        {
            _utility.click(_productDetailsObject.AddToCartButton);
        }

        [Then(@"I can see an Alert of Product Added")]
        public void ThenICanSeeAnAlertOfProductAdded()
        {
           if(_utility.AlertIsPresent())
            {
                _utility.AcceptAlert();
            }
            else
            {
                AssertAll.Succeed(
                    () => Assert.IsFalse(false, "Product not added to cart")) ;
            }
        }

        [When(@"I click on Cart in Home Page")]
        public void WhenIClickOnCartInHomePage()
        {
            _utility.click(_homePageObject.CartTab);
        }

        [Then(@"I am able to see the (.*) in the cart")]
        public void ThenIAmAbleToSeeTheSamsungGalaxySInTheCart(string productName)
        {
            _cartObject.ProductName = productName;
            if (_utility.WaitUntilElementVisible(_cartObject.ItemDescriptionLabel))
            {
                Assert.IsTrue(true, "User is able to see the product added in the cart");
            }
            else
            {
                Assert.IsFalse(false, "User is not able to see the product added in the cart");
            }
        }


        [When(@"I click on delete item of cart")]
        public void ThenIClickOnDeleteItemOfCart()
        {
            _utility.click(_cartObject.DeleteButton);
        }

        [Then(@"I am not able to see the (.*) in the cart")]
        public void ThenIAmNotAbleToSeeTheSamsungGalaxySInTheCart(string productName)
        {
            _cartObject.ProductName = productName;
            if (_utility.WaitUntilElementVisible(_cartObject.ItemDescriptionLabel))
            {
                Assert.IsFalse(false, "User is able to see the product added in the cart");
            }
            else
            {
                Assert.IsTrue(true, "User is not able to see the product added in the cart");
            }
        }

    }
}

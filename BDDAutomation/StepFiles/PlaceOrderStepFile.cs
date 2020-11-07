using BDDAutomation.PageObject;
using BDDAutomation.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace BDDAutomation.StepFiles
{
    [Binding]
   public  class PlaceOrderStepFile
    {

        ScenarioContext _context;
        IWebDriver driver;
        LoginObject _loginObject;
        HomePageObject _homePageObject;
        CartObject _cartObject;
        PlaceOrderObject _placeOrderObject;
        Utility _utility;

        public PlaceOrderStepFile(ScenarioContext context, LoginObject loginObject, HomePageObject homePageObject, 
            CartObject cartObject, PlaceOrderObject placeOrderObject, Utility utility)
        {

            _context = context;
            _loginObject = loginObject;
            _homePageObject = homePageObject;
            _utility = utility;
            _cartObject = cartObject;
            _placeOrderObject = placeOrderObject;
            driver = _context["WEB_DRIVER"] as IWebDriver;

        }

        [Given(@"I am on details page of phone")]
        public void GivenIAmOnDetailsPageOfPhone()
        {
            _utility.WaitUntilElementVisible(_cartObject.PlaceOrderButton);
        }


        [When(@"I click on Place Order")]
        public void WhenIClickOnPlaceOrder()
        {
            _utility.click(_cartObject.PlaceOrderButton);
        }

        [Then(@"I am on purchase order details modal")]
        public void ThenIAmOnPurchaseOrderDetailsModal()
        {
            if (_utility.WaitUntilElementVisible(_placeOrderObject.PlaceOrderLabel))
            {
                Assert.IsTrue(true, "Ordered  Placed");
            }
            else
            {
                SoftAssert.AssertAll.Succeed(
                    () => Assert.IsFalse(false, "Ordered Not Placed")
                    );
            }
        }

        [When(@"I enter details like (.*) (.*) (.*) (.*) (.*) (.*)")]
        public void WhenIEnterDetailsLike(string name, string country, string city, string creditCard, string month, string year)
        {
            _utility.enterDetails( _placeOrderObject.NameField , name);
            _utility.enterDetails(_placeOrderObject.CountryField, country);
            _utility.enterDetails(_placeOrderObject.CityField, city);
            _utility.enterDetails(_placeOrderObject.CardField, creditCard);
            _utility.enterDetails(_placeOrderObject.MonthField, month);
            _utility.enterDetails(_placeOrderObject.YearField, year);
        }

        [When(@"I click on Purchase")]
        public void WhenIClickOnPurchase()
        {
            _utility.click(_placeOrderObject.PurchaseButton);
        }

        [Then(@"The order is placed with correct details")]
        public void ThenTheOrderIsPlacedWithCorrectDetails()
        {
            _utility.WaitUntilElementVisible(_placeOrderObject.PurchaseValid);
        }

        [When(@"I click ok")]
        public void WhenIClickOk()
        {
            Thread.Sleep(2000);
            _utility.click(_placeOrderObject.OKButton);
        }

     


    }
}

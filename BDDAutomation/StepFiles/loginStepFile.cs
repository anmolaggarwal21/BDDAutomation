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
    public class loginStepFile
    {
        ScenarioContext _context;
        IWebDriver driver;
        LoginObject _loginObject;
        HomePageObject _homePageObject;
        Utility _utility;

        public loginStepFile(ScenarioContext context , LoginObject loginObject, HomePageObject homePageObject, Utility utility)
        {

            _context = context;
            _loginObject = loginObject;
            _homePageObject = homePageObject;
            _utility = utility;
            driver = _context["WEB_DRIVER"] as IWebDriver;
            
        }

        [Given(@": Click on Login Icon")]
        public void GivenClickOnLoginIcon()
        {
            Thread.Sleep(3000);
            _utility.click(_homePageObject.LoginElement);
                
        }



        [When(@": I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            _utility.click(_loginObject.LoginButton);
        }

        [Then(@": I am able to login")]
        public void ThenIAmAbleToLogin()
        {
            if (_utility.AlertIsPresent())
            {
                _utility.AcceptAlert();
                AssertAll.Succeed( 
                    () => Assert.Fail("Username and password is incorrect. Not able to login")
                );
               
            }
            else
            {
               
                Assert.IsTrue(_utility.getTextOfElement(_loginObject.LoggedInUsername).Contains("testinguser1234"));
            }

        }


       

        [When(@": I enter (.*) and (.*)")]
        public void WhenIEnterAnd(string p0, string p1)
        {
            Thread.Sleep(15000);
          
            _utility.enterDetails(_loginObject.Username, p0);
            _utility.enterDetails(_loginObject.Password, p1);
        }



    }
}

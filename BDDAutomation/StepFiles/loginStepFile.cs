using BDDAutomation.PageObject;
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

        public loginStepFile(ScenarioContext context , LoginObject loginObject)
        {

            _context = context;
            _loginObject = loginObject;
            driver = _context["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@": Click on Login Icon")]
        public void GivenClickOnLoginIcon()
        {
            _loginObject.click(_loginObject.LoginElement);
                
        }


        [When(@": I enter username and password")]
        public void WhenIEnterUsernameAndPassword()
        {
            _loginObject.enterDetails(_loginObject.Username, "testinguser1234");
            _loginObject.enterDetails(_loginObject.Password, "12345678");
        }

        [When(@": I click on the login button")]
        public void WhenIClickOnTheLoginButton()
        {
            _loginObject.click(_loginObject.LoginButton);
        }

        [Then(@": I am able to login")]
        public void ThenIAmAbleToLogin()
        {
            if (_loginObject.AlertIsPresent())
            {
                _loginObject.AcceptAlert();
                AssertAll.Succeed( 
                    () => Assert.Fail("Username and password is incorrect. Not able to login")
                );
               
            }
            else
            {
                var abc = _loginObject.getTextOfElement(_loginObject.LoggedInUsername);
                Assert.IsTrue(_loginObject.getTextOfElement(_loginObject.LoggedInUsername).Contains("testinguser1234"));
            }

        }


       

        [When(@": I enter (.*) and (.*)")]
        public void WhenIEnterAnd(string p0, string p1)
        {
            _loginObject.enterDetails(_loginObject.Username, p0);
            _loginObject.enterDetails(_loginObject.Password, p1);
        }



    }
}

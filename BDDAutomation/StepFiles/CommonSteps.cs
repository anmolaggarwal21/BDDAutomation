using BDDAutomation.PageObject;
using BDDAutomation.Shared;
using NUnit.Framework;
using OpenQA.Selenium;
using SoftAssert;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDAutomation.StepFiles
{
    [Binding]
    public class CommonSteps
    {
        IWebDriver driver;
        HomePageObject _homePageObject;
        Utility _utility;
        public CommonSteps(ScenarioContext context,HomePageObject homePageObject, Utility utility)
        {
            _homePageObject = homePageObject;
            driver = context["WEB_DRIVER"] as IWebDriver;
            _utility = utility;


        }
        [Given(@"the user has navigated to the demo site")]
        public void GivenTheUserHasNavigatedToTheDemoSite()
        {
            driver.Url = $"https://www.demoblaze.com/";

        }

        [Given(@"The user is on Home Page")]
        public void GivenTheUserIsOnHomePage()
        {
            CheckUserIsOnHomePage();
        }

        [Then(@"The user is on Home Page")]
        public void ThenTheUserIsOnHomePage()
        {
            CheckUserIsOnHomePage();
        }

        private void CheckUserIsOnHomePage()
        {
            if (!_utility.WaitUntilElementVisible(_homePageObject.HomeTab))
            {
                AssertAll.Succeed(
                   () => Assert.Fail("User is not on homepage")
               );
            }
        }
    }
}

using OpenQA.Selenium;
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
        public CommonSteps(ScenarioContext context)
        {
            driver = context["WEB_DRIVER"] as IWebDriver;
        }
        [Given(@"the user has navigated to the demo site")]
        public void GivenTheUserHasNavigatedToTheDemoSite()
        {
            driver.Url = $"https://www.demoblaze.com/";

        }

    }
}

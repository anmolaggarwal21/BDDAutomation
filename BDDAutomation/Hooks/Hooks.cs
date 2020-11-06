using BDDAutomation.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDAutomation.Hooks
{
    [Binding]
    public class Hooks
    {
        IWebDriver webDriver;
       [BeforeScenario]
        public void addWebdriver(ScenarioContext context)
        {
            
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");

             webDriver = new ChromeDriver(options);
            
            WebDriverWait webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            context["WEB_DRIVER"] = webDriver;
            context["webDriverWait"] = webDriverWait;
        }

        [AfterScenario]

        public void afterScenario()
        {
            webDriver.Close();
        }
    }
}

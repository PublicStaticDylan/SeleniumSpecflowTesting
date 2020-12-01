using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using static SeleniumSpecflow.PageObjects.Login.LoginDetail;
using SeleniumSpecflow.Base;
using SeleniumSpecflow.PageObjects.Login;
using TechTalk.SpecFlow.Assist;

namespace SeleniumSpecflow.Steps
{
    [Binding]
    public class LoginWithDataTableSteps
    {
        private readonly ScenarioContext _scenarioContext;                              //local scenariocontext object
        private readonly IWebDriver driver;                                             //local webdriver object

        //constructor method to initialize webdriver object
        public LoginWithDataTableSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;                                    //pass scenariocontext to class
            driver = (IWebDriver)this._scenarioContext["webdriver"];                    //set driver to scenariodriver webdriver        
        }

        [When(@"the user enters the following credentials")]
        public void WhenTheUserEntersTheFollowingCredentials(Table table)
        {
            dynamic data = table.CreateDynamicInstance();                               //create a dynamic instance of table

            var loginPage = PropertiesCollection.currentPage.As<LoginPage>();           //get loginpage object
            loginPage.Login((string)data.userName, (string)data.password);              //enter userName and password fields from table into the site
            PropertiesCollection.currentPage = loginPage.ClickLoginButton();            //click login button and set currentpage to the next page
        }
    }
}

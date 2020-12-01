using OpenQA.Selenium;
using SeleniumSpecflow.Base;
using SeleniumSpecflow.PageObjects.Login;
using System;
using TechTalk.SpecFlow;

namespace SeleniumSpecflow.Steps
{
    [Binding]
    public class LoginWithMultipleUsersSteps
    {
        private readonly ScenarioContext _scenarioContext;                              //local scenariocontext object
        private readonly IWebDriver driver;                                             //local webdriver object

        //constructor method to initialize webdriver object
        public LoginWithMultipleUsersSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;                                    //pass scenariocontext to class
            driver = (IWebDriver)this._scenarioContext["webdriver"];                    //set driver to scenariodriver webdriver        
        }

        [When(@"the user enters (.*) and (.*)")]
        public void WhenTheUserEntersAnd(string userName, string password)
        {
            var loginPage = PropertiesCollection.currentPage.As<LoginPage>();           //get loginpage object
            loginPage.Login(userName, password);                                        //login with username and password from the Examples table in the feature file
            PropertiesCollection.currentPage = loginPage.ClickLoginButton();            //click the login button and return the next page
        }
    }
}

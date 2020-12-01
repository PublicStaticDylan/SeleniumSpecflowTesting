using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using static SeleniumSpecflow.PageObjects.Login.LoginDetail;
using SeleniumSpecflow.Base;
using SeleniumSpecflow.PageObjects.Login;

namespace SeleniumSpecflow.Steps
{
    [Binding]
    public class LoginSauceDemoSteps
    {
        private readonly ScenarioContext _scenarioContext;                              //local scenariocontext object
        private readonly IWebDriver driver;                                             //local webdriver object

        //constructor method to initialize webdriver object
        public LoginSauceDemoSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;                                    //pass scenariocontext to class
            driver = (IWebDriver)this._scenarioContext["webdriver"];                    //set driver to scenariodriver webdriver        
        }

        [Given(@"the user is able to see the login portal")]
        public void GivenTheUserIsAbleToSeeTheLoginPortal()
        {
            string url = GetURL();                                                      //get the login page url
            driver.Navigate().GoToUrl(url);                                             //navigate the webdriver to this url

            PropertiesCollection.scenarioContext = _scenarioContext;
            PropertiesCollection.currentPage = new LoginPage(driver);
        }
        
        [When(@"user enters '(.*)' and '(.*)'")]
        public void WhenUserEntersAnd(string userName, string password)
        {
            PropertiesCollection.currentPage = 
                PropertiesCollection.currentPage.As<LoginPage>().LoginAndSubmit(userName, password);
        }
        
        [Then(@"I should be logged into the inventory page")]
        public void ThenIShouldBeLoggedIntoTheInventoryPage()
        {
            PropertiesCollection.currentPage.As<InventoryPage>().HasWelcomeMessage();
        }
    }
}

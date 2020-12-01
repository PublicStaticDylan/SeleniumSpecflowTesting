using OpenQA.Selenium;
using SeleniumSpecflow.Base;
using SeleniumSpecflow.PageObjects.Checkout;
using SeleniumSpecflow.PageObjects.Login;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;
using static SeleniumSpecflow.PageObjects.Login.LoginDetail;

namespace SeleniumSpecflow.Steps
{
    [Binding]
    public class BuyItemFullSauceDemoSteps
    {
        private readonly ScenarioContext _scenarioContext;                              //local scenariocontext object
        private readonly IWebDriver driver;                                             //local webdriver object

        //constructor method to initialize webdriver object
        public BuyItemFullSauceDemoSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;                                    //pass scenariocontext to class
            driver = (IWebDriver)this._scenarioContext["webdriver"];                    //set driver to scenariodriver webdriver        
        }

        [Given(@"The user is able to log into the site with '(.*)' and '(.*)'")]
        public void GivenTheUserIsAbleToLogIntoTheSiteWithAnd(string userName, string password)
        {
            driver.Navigate().GoToUrl(GetURL());                                        //go to login frontpage
            PropertiesCollection.scenarioContext = _scenarioContext;                    //set global scenariocontext equal to local one
            PropertiesCollection.currentPage 
                = new LoginPage(driver).LoginAndSubmit(userName, password);             //login to site and set the currentpage object to the next page
        }

        [Given(@"The user adds an item to their cart")]
        public void GivenTheUserAddsAnItemToTheirCart()
        {
            //PropertiesCollection.currentPage.As<InventoryPage>().AddItemToCart(0);    //add to cart the first item on the inventory page
            PropertiesCollection.currentPage.As<InventoryPage>().AddRandomItemToCart(); //adds a random item to the cart
        }
        
        [Given(@"The user proceeds to the cart page")]
        public void GivenTheUserProceedsToTheCartPage()
        {
            PropertiesCollection.currentPage =                                          //continue to the cart page
                PropertiesCollection.currentPage.As<InventoryPage>().ContinueToCart();  //and set currentpage to the cart page
        }
        
        [Given(@"The user proceeds to the checkout page")]
        public void GivenTheUserProceedsToTheCheckoutPage()
        {
            PropertiesCollection.currentPage =                                          //continue to checkout page
                PropertiesCollection.currentPage.As<CartPage>().ContinueToCheckout();   //and set currentpage to the first checkout page
        }

        [Given(@"The user enters (.*) and (.*) and (.*) and continues to the checkout overview")]
        public void GivenTheUserEntersAndAndAndContinuesToTheCheckoutOverview(string firstName, string secondName, string postCode)
        {
            CheckoutStage1 detailsPage = PropertiesCollection.currentPage.As<CheckoutStage1>();
            detailsPage.EnterDetails(firstName, secondName, postCode);                  //enter user details into fields
            PropertiesCollection.currentPage = detailsPage.ContinueToCheckoutOverview();//continue to next page and set currentpage to next page
        }
        
        [Given(@"The user clicks finish")]
        public void GivenTheUserClicksFinish()
        {
            PropertiesCollection.currentPage =                                          //click finish checkout and continue to success page
                PropertiesCollection.currentPage.As<CheckoutStage2>().FinishCheckout(); //set currentpage to the finish checkout page
        }
        
        [Then(@"The purchase should have been successfully purchased")]
        public void ThenThePurchaseShouldHaveBeenSuccessfullyPurchased()
        {
            PropertiesCollection.currentPage.As<CheckoutComplete>().HasSuccessMessage();//check if the transaction was successful
        }
    }
}

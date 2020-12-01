using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumSpecflow.PageObjects.Checkout
{
    class CheckoutStage1 : Base.BasePage
    {
        private readonly IWebDriver _webDriver;                                             //page's webdriver object
        public CheckoutStage1(IWebDriver driver) => _webDriver = driver;                    //constructor to get current webdriver

        public IWebElement txtFirstName => _webDriver.FindElement(By.Id("first-name"));
        public IWebElement txtLastName => _webDriver.FindElement(By.Id("last-name"));
        public IWebElement txtPostCode => _webDriver.FindElement(By.Id("postal-code"));

        public IWebElement btnContinue => _webDriver.FindElement(By.CssSelector(".btn_primary.cart_button"));
        public IWebElement btnCancel => _webDriver.FindElement(By.CssSelector(".cart_cancel_link.btn_secondary"));

        //enters the user details fields on the page
        public void EnterDetails(string firstName, string secondName, string postCode)
        {
            txtFirstName.SendKeys(firstName);
            txtLastName.SendKeys(secondName);
            txtPostCode.SendKeys(postCode);
        }
        //clicks the continue button and returns the next page
        public CheckoutStage2 ContinueToCheckoutOverview()
        {
            btnContinue.Click();
            return new CheckoutStage2(_webDriver);
        }
    }
}

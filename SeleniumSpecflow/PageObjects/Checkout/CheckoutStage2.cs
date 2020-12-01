using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumSpecflow.PageObjects.Checkout
{
    class CheckoutStage2 : Base.BasePage
    {
        private readonly IWebDriver _webDriver;                                             //page's webdriver object
        public CheckoutStage2(IWebDriver driver) => _webDriver = driver;                    //constructor to get current webdriver

        public IWebElement btnFinish => _webDriver.FindElement(By.CssSelector(".btn_action.cart_button"));
        public IWebElement btnCancel => _webDriver.FindElement(By.CssSelector(".cart_cancel_link.btn_secondary"));
        
        //clicks on the finish purchase button and returns the next page
        public CheckoutComplete FinishCheckout()
        {
            btnFinish.Click();
            return new CheckoutComplete(_webDriver);
        }
    }
}

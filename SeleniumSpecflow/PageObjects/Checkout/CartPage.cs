using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumSpecflow.PageObjects.Checkout
{
    class CartPage : Base.BasePage
    {
        private readonly IWebDriver _webDriver;                                             //page's webdriver object
        public CartPage(IWebDriver driver) => _webDriver = driver;                          //constructor to get current webdriver
        //note- if the classsname has a space in it, must use CssSelector and replace space with . and add . before first char
        public IWebElement btnCheckout => _webDriver.FindElement(By.CssSelector(".btn_action.checkout_button"));    
        public IWebElement btnContinueShopping => _webDriver.FindElement(By.ClassName("btn_secondary"));
        //public IWebElement btnCheckout => _webDriver.FindElement(By.ClassName("btn_action checkout_button"));

        //continues to the checkout page from the cart
        public CheckoutStage1 ContinueToCheckout()
        {
            btnCheckout.Click();                                        //click checkout button
            return new CheckoutStage1(_webDriver);                      //returns checkoutpage and pass webdriver into constructor
        }   
    }
}

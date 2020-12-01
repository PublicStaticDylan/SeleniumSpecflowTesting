using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumSpecflow.PageObjects.Checkout
{
    class CheckoutComplete : Base.BasePage
    {
        private readonly IWebDriver _webDriver;                                             //page's webdriver object
        public CheckoutComplete(IWebDriver driver) => _webDriver = driver;                  //constructor to get current webdriver
        private string _successMessage = "THANK YOU FOR YOUR ORDER";

        public void HasSuccessMessage()
        {
            //checks that the page contains the successmessage, if not then test is fail
            Assert.That(_webDriver.PageSource.Contains(_successMessage), Is.EqualTo(true), "Purchase Failed");
        }
    }
}

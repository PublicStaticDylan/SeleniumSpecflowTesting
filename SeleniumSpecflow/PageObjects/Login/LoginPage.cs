using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumSpecflow.PageObjects.Login
{
    class LoginPage : Base.BasePage
    {
        private readonly IWebDriver _webDriver;                                             //page's webdriver object
        public LoginPage(IWebDriver driver) => _webDriver = driver;                         //constructor to get current webdriver
        public IWebElement txtUsername => _webDriver.FindElement(By.Id("user-name"));       //username input box
        public IWebElement txtPassword => _webDriver.FindElement(By.Id("password"));        //password input box
        public IWebElement btnLogin => _webDriver.FindElement(By.Id("login-button"));       //login button

        //function to login to enter login details to site
        public void Login(string userName, string password)
        {
            txtUsername.SendKeys(userName);
            txtPassword.SendKeys(password);
        }
        //function to click the login button and return the next page
        public InventoryPage ClickLoginButton()
        {
            btnLogin.Click();                                                               //click the login button
            return new InventoryPage(_webDriver);                                           //return the inventory page
        }
        //enters login details and submits them, returns the next page
        public InventoryPage LoginAndSubmit(string userName, string password)
        {
            txtUsername.SendKeys(userName);
            txtPassword.SendKeys(password);
            return ClickLoginButton();
        }
    }
}

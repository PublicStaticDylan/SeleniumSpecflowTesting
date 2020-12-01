using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SeleniumSpecflow.PageObjects.Login
{
    class InventoryPage : Base.BasePage
    {
        private readonly IWebDriver _webDriver;                                                 //page's webdriver object
        public InventoryPage(IWebDriver driver) => _webDriver = driver;                         //constructor to get current webdriver

        //gets a list of elements on the page with the class "Inventory Items" so that seperate items can be selected and added to cart
        public IReadOnlyCollection<IWebElement> inventoryItems => _webDriver.FindElements(By.ClassName("inventory_item"));
        public IWebElement btnCart => _webDriver.FindElement(By.ClassName("shopping_cart_container"));
        public void HasWelcomeMessage()
        {
            //check that the webpage contains the word "Products" to determine if the page has been reached
            Assert.That(_webDriver.PageSource.Contains("Products"), Is.EqualTo(true), "Login Failed");
        }
        public void AddItemToCart(int index)
        {
            var item = inventoryItems.ElementAt(index);                                         //get inventory item from list
            item.FindElement(By.CssSelector(".btn_primary.btn_inventory")).Click();             //find the child add to cart button and click it
        }
        public void AddRandomItemToCart()
        {
            int randomIndex = new Random().Next(inventoryItems.Count);                          //get random index from list of items
            inventoryItems.ElementAt(randomIndex)
                .FindElement(By.CssSelector(".btn_primary.btn_inventory")).Click();             //finds the child 'add to cart' button of the item and clicks it

            DebugConsole.WriteLine("Element Chosen: " + randomIndex);                           //prints the item selected to test output
        }

        //clicks on the cart button and returns the next page
        public Checkout.CartPage ContinueToCart()
        {
            btnCart.Click();
            return new Checkout.CartPage(_webDriver);
        }
    }
}

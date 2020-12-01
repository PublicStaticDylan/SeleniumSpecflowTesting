using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumSpecflow.Base
{
    public class PropertiesCollection
    {
        //different pageobjects can be converted to the generic BasePage class and cast into other pages
        private static BasePage _currentPage;
        //scenarioContext is a String-Object dictionary for storing data between different test stages
        public static ScenarioContext scenarioContext;

        //public static currentpage is used to store and convert the current pageobject 
        public static BasePage currentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                scenarioContext["class"] = value;                               //sets the "class" entry of the scenariocontext object to whatever currentPage is set to
                _currentPage = scenarioContext.Get<BasePage>("class");          //private _currentpage is set to the basepage stored in scenariocontext class
            }
        }
    }
}

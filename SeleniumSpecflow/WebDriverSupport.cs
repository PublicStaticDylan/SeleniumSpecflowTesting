using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumSpecflow
{
    [Binding]
    public class WebDriverSupport
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;
        public bool _closeBrowserOnTestEnd = true;                 //if false, page closes after test ends

        public WebDriverSupport(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }
        //initializes and opens chrome
        [BeforeScenario]
        public void InitialiseWebDriver()
        {
            string headless = "No";
            string browser = "Chrome";

            switch (browser)
            {
                case "IE":
                    var options = new InternetExplorerOptions();
                    driver = new InternetExplorerDriver(options);
                    break;

                case "Firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (headless == "Yes")
                    {
                        firefoxOptions.AddArgument("--headless");
                    }
                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "Chrome":
                    ChromeOptions chromeOptions = new ChromeOptions();

                    if (headless == "Yes")
                    {
                        chromeOptions.AddArgument("--headless");
                    }
                    //gets the chromedriver from the assembly path
                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

                    break;

                default:
                    throw new NotSupportedException(browser);
            }
            driver.Manage().Window.Maximize();                      //maximize browser window
            _scenarioContext["webdriver"] = driver;                 //stores driver in local scenariocontext dictionary
        }

        [AfterScenario]
        public void TearDown()
        {
            if (_closeBrowserOnTestEnd)
            {
                driver.Dispose();     
            }
        }
    }
}

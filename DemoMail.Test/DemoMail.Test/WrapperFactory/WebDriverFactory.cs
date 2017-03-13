using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;

namespace DemoMail.Test.WrapperFactory
{
    class WebDriverFactory
    {
        private IWebDriver driver;

        public IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitDriver.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public void InitDriver(string driverName)
        {
            switch (driverName)
            {
                case "Firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();
                    }
                    break;

                case "IE":
                    if (driver == null)
                    {
                        driver = new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory);
                    }
                    break;

                case "Chrome":
                    if (driver == null)
                    {
                        driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
                    }
                    break;
            }
        }

        public void CloseDriver()
        {
            Driver.Dispose();
        }
    }
}

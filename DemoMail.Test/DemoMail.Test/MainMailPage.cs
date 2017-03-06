using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace DemoMail.Test
{
     public class MainMailPage
    {
        private readonly IWebDriver _driver;

        public MainMailPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public string UserEmail => _driver.FindElement(By.Id("PH_user-email")).Text;
    }
}

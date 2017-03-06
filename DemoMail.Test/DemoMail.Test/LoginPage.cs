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
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private const string PageURL = @"https://mail.ru/";

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public static LoginPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageURL);

            return new LoginPage(driver);
        }

        public string BoxName
        {
            set
            {
                _driver.FindElement(By.Id("mailbox__login")).SendKeys(value);
            }
        }

        public string DomainName
        {
            set
            {
                _driver.FindElement(By.Id("mailbox__login__domain")).SendKeys(value);
            }
        }

        public string PasswordText
        {
            set
            {
                _driver.FindElement(By.Id("mailbox__password")).SendKeys(value);
            }
        }

        public void DeselectAuthenticationRemembering()
        {
            _driver.FindElement(By.Id("mailbox__auth__remember__checkbox")).Click();
        }

        public MainMailPage SubmitLogin()
        {
            _driver.FindElement(By.Id("mailbox__auth__button")).Click();

            return new MainMailPage(_driver);
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DemoMail.Test.Properties;
using DemoMail.Test.WrapperFactory;
using System;
using OpenQA.Selenium.Support.UI;

namespace DemoMail_Nunit.Test
{
    public class LoginPage
    {
        #region FindElements by locator

        [FindsBy(How = How.Id, Using = "mailbox__login")]
        private IWebElement _boxName;

        [FindsBy(How = How.Id, Using = "mailbox__login__domain")]
        private IWebElement _domainName;

        [FindsBy(How = How.Id, Using = "mailbox__password")]
        private IWebElement _passwordText;

        private bool isChecked;

        [FindsBy(How = How.Id, Using = "mailbox__auth__remember__checkbox")]
        private IWebElement _deselectAuthenticationRemembering;

        [FindsBy(How = How.Id, Using = "mailbox__auth__button")]
        private IWebElement _submitLogin;

        [FindsBy(How = How.ClassName, Using = "b-toolbar__btn__text b-toolbar__btn__text_pad")]
        private IWebElement _submitNewMail;

        #endregion

        #region Fields

        private WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromSeconds(10));

        #endregion

        #region Properties

        public string BoxName
        {
            set
            {
                _boxName.SendKeys(value);
            }
        }

        public string DomainName
        {
            set
            {
                _domainName.SendKeys(value);
            }
        }

        public string PasswordText
        {
            set
            {
                _passwordText.SendKeys(value);
            }
        }

        #endregion

        #region Methods

        public void NavigateTo()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(Resources.Url);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("mailbox__login")));
        }

        public void DeselectAuthenticationRemembering()
        {
            //If attribute exist in HTML then it checked, if not - then not checked and GetAttribute will return null
            isChecked = (_deselectAuthenticationRemembering.GetAttribute("checked") != null);

            //If checked then click to deselect
            if (isChecked)
            {
                _deselectAuthenticationRemembering.Click();
            }
        }

        public void SubmitLogin()
        {
            _submitLogin.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("PH_logoutLink")));
        }

        public void SubmitInvalidLogin()
        {
            _submitLogin.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("b-login__errors")));
        }

        #endregion
    }
}

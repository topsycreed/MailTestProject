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

        private WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromSeconds(10));

        public void NavigateTo()
        {
            WebDriverFactory.Driver.Navigate().GoToUrl(Resources.Url);
        }

        public string BoxName
        {
            set
            {
                bool NotFinded = true;
                int count = 1;

                while (NotFinded && count < 10)
                {
                    try
                    {
                        _boxName.SendKeys(value);

                        NotFinded = false;
                    }
                    catch (StaleElementReferenceException)
                    {
                        count++;
                        continue;
                    }
                }
            }
        }

        public string DomainName
        {
            set
            {
                bool NotFinded = true;
                int count = 1;

                while (NotFinded && count < 10)
                {
                    try
                    {
                        _domainName.SendKeys(value);

                        NotFinded = false;
                    }
                    catch (StaleElementReferenceException)
                    {
                        count++;
                        continue;
                    }
                }
            }
        }

        public string PasswordText
        {
            set
            {
                bool NotFinded = true;
                int count = 1;

                while (NotFinded && count < 10)
                {
                    try
                    {
                        _passwordText.SendKeys(value);

                        NotFinded = false;
                    }
                    catch (StaleElementReferenceException)
                    {
                        count++;
                        continue;
                    }
                }
            }
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
        }

        public void SubmitInvalidLogin()
        {
            _submitLogin.Click();
        }

        public void SubmitNewMail()
        {
            _submitNewMail.Click();
        }
    }
}

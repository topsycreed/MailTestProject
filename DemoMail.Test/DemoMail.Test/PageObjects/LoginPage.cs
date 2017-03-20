using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DemoMail.Test.Properties;
using DemoMail.Test.PageObjects;
using DemoMail.Test.WrapperFactory;

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

        [FindsBy(How = How.Id, Using = "mailbox__auth__remember__checkbox")]
        private IWebElement _deselectAuthenticationRemembering;

        [FindsBy(How = How.Id, Using = "mailbox__auth__button")]
        private IWebElement _submitLogin;

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
            _deselectAuthenticationRemembering.Click();
        }

        public void SubmitLogin()
        {
            _submitLogin.Click();
        }

        public void SubmitInvalidLogin()
        {
            _submitLogin.Click();
        }
    }
}

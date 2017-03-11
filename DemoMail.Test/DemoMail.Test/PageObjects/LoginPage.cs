using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using DemoMail.Test.Properties;
using DemoMail.Test.PageObjects;

namespace DemoMail_Nunit.Test
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

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

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public static LoginPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(Resources.Url);

            return new LoginPage(driver);
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
                        count++;
                    }
                    catch (StaleElementReferenceException)
                    {
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
                        count++;
                    }
                    catch (StaleElementReferenceException)
                    {
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
                        count++;
                    }
                    catch (StaleElementReferenceException)
                    {
                        continue;
                    }
                }
            }
        }

        public void DeselectAuthenticationRemembering()
        {
            _deselectAuthenticationRemembering.Click();
        }

        public MainMailPage SubmitLogin()
        {
            _submitLogin.Click();

            return new MainMailPage(_driver);
        }

        public ErrorLoginPage SubmitInvalidLogin()
        {
            _submitLogin.Click();

            return new ErrorLoginPage(_driver);
        }
    }
}

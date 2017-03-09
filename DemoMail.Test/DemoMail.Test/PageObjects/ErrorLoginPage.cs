using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoMail.Test.PageObjects
{
    public class ErrorLoginPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.CssSelector, Using = "div[class=b-login__errors]")]
        private IWebElement _errorMessage;

        public ErrorLoginPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public string ErrorMessage
        {
            get
            {
                return _errorMessage.Text;
            }
        }
    }
}

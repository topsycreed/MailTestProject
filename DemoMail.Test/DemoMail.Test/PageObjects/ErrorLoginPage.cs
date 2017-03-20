using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoMail.Test.PageObjects
{
    public class ErrorLoginPage
    {
        [FindsBy(How = How.CssSelector, Using = "div[class=b-login__errors]")]
        private IWebElement _errorMessage;

        public string ErrorMessage
        {
            get
            {
                return _errorMessage.Text;
            }
        }
    }
}

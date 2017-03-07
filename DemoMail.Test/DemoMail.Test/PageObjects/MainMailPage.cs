using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoMail_Nunit.Test
{
    public class MainMailPage
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.Id, Using = "PH_user-email")]
        private IWebElement _userEmail;

        public MainMailPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public string UserEmail
        {
            get
            {
                return _userEmail.Text;
            }
        }
    }
}

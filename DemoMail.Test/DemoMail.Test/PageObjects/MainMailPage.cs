using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Reflection;

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
                bool NotFinded = true;
                int count = 1;

                while (NotFinded && count < 10)
                {
                    try
                    {
                        return _userEmail.Text;

                        NotFinded = false;
                        count++;
                    }
                    catch (StaleElementReferenceException)
                    {
                        continue;
                    }
                    catch (TargetInvocationException)
                    {
                        continue;
                    }
                }
                return _userEmail.Text;
            }
        }
    }
}

using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace DemoMail.Test
{
    [Binding]
    public class MailSteps
    {
        private IWebDriver _driver;

        [Given(@"I am on the mail site")]
        public void GivenIAmOnTheMailSite()
        {
            _driver = new ChromeDriver(@"C:\SeleniumDrivers");

            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://mail.ru/");
        }
        
        [Given(@"I enter a mailbox login (.*)")]
        public void GivenIEnterAMailboxLoginJohnDoe(string login)
        {
            IWebElement boxName = _driver.FindElement(By.Id("mailbox__login"));
            boxName.SendKeys(login);
        }
        
        [Given(@"I enter a mailbox domain (.*)")]
        public void GivenIEnterAMailboxDomainList_Ru(string domain)
        {
            SelectElement domainName = new SelectElement(_driver.FindElement(By.Id("mailbox__login__domain")));
            domainName.SelectByText(domain);
        }
        
        [Given(@"I enter a mailbox password (.*)")]
        public void GivenIEnterAMailboxPasswordINeedSomePassword(string password)
        {
            IWebElement passwordText = _driver.FindElement(By.Id("mailbox__password"));
            passwordText.SendKeys(password);
        }
        
        [Given(@"I select that I have not authentication remembering")]
        public void GivenISelectThatIHaveNotAuthenticationRemembering()
        {
            _driver.FindElement(By.Id("mailbox__auth__remember__checkbox")).Click();
        }
        
        [When(@"I submit my login data")]
        public void WhenISubmitMyLoginData()
        {
            _driver.FindElement(By.Id("mailbox__auth__button")).Click();
        }
        
        [Then(@"I should see my e-mail address (.*) in the header of site")]
        public void ThenIShouldSeeMyE_MailAddressJohnDoeList_RuInTheHeaderOfSite(string correctEmail)
        {
            IWebElement userEmail = _driver.FindElement(By.Id("PH_user-email"));
            string email = userEmail.Text;
            correctEmail = correctEmail.ToLower();

            Assert.Equal(correctEmail, email);
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}

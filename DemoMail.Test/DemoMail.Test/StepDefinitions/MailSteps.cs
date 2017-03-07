using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoMail_Nunit.Test
{
    [Binding]
    public class MailSteps
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private MainMailPage _mainMailPage;

        [Given(@"I am on the mail site")]
        public void GivenIAmOnTheMailSite()
        {
            _driver = new ChromeDriver(@"C:\SeleniumDrivers");
            _driver.Manage().Window.Maximize();

            _loginPage = LoginPage.NavigateTo(_driver);
        }

        [Given(@"I enter a mailbox login (.*)")]
        public void GivenIEnterAMailboxLoginJohnDoe(string login)
        {
            _loginPage.BoxName = login;
        }

        [Given(@"I enter a mailbox domain (.*)")]
        public void GivenIEnterAMailboxDomainList_Ru(string domain)
        {
            _loginPage.DomainName = domain;
        }

        [Given(@"I enter a mailbox password (.*)")]
        public void GivenIEnterAMailboxPasswordINeedSomePassword(string password)
        {
            _loginPage.PasswordText = password;
        }

        [Given(@"I select that I have not authentication remembering")]
        public void GivenISelectThatIHaveNotAuthenticationRemembering()
        {
            _loginPage.DeselectAuthenticationRemembering();
        }

        [When(@"I submit my login data")]
        public void WhenISubmitMyLoginData()
        {
            _mainMailPage = _loginPage.SubmitLogin();
        }

        [Then(@"I should see my e-mail address (.*) in the header of site")]
        public void ThenIShouldSeeMyE_MailAddressJohnDoeList_RuInTheHeaderOfSite(string correctEmail)
        {
            correctEmail = correctEmail.ToLower();

            Assert.That(correctEmail, Is.EqualTo(_mainMailPage.UserEmail));
            //Assert.Equal(correctEmail, _mainMailPage.UserEmail);
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}

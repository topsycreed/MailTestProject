using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DemoMail.Test.Properties;
using System.Linq;
using DemoMail.Test.Support;
using DemoMail.Test.PageObjects;

namespace DemoMail_Nunit.Test
{
    [Binding]
    public class MailSteps : TechTalk.SpecFlow.Steps
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private MainMailPage _mainMailPage;
        private ErrorLoginPage _errorLoginPage;

        [Given(@"I am on the mail site")]
        public void GivenIAmOnTheMailSite()
        {
            var ChromeDriverLocation = Resources.Driver;
            _driver = new ChromeDriver(ChromeDriverLocation);
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

        [When(@"I submit my login data")]
        [Scope(Tag = "invalid_login_or_password")]
        public void WhenISubmitMyInvalidLoginData()
        {
            _errorLoginPage = _loginPage.SubmitInvalidLogin();
        }

        [Then(@"I should see my e-mail address (.*) in the header of site")]
        public void ThenIShouldSeeMyE_MailAddressJohnDoeList_RuInTheHeaderOfSite(string correctEmail)
        {
            correctEmail = correctEmail.ToLower();

            Assert.That(correctEmail, Is.EqualTo(_mainMailPage.UserEmail));
        }

        [Given(@"I enter a correct mailbox login")]
        public void GivenIEnterACorrectMailboxLogin()
        {
            _loginPage.BoxName = Resources.Login;
        }

        [Given(@"I enter a correct mailbox domain")]
        public void GivenIEnterACorrectMailboxDomain()
        {
            _loginPage.DomainName = Resources.Domain;
        }

        [Given(@"I enter a correct mailbox password")]
        public void GivenIEnterACorrectMailboxPassword()
        {
            _loginPage.PasswordText = Resources.Password;
        }

        [Given(@"I enter a incorrect mailbox (.*) password")]
        public void GivenIEnterAIncorrectMailboxINeedSomePassword(string password)
        {
            _loginPage.PasswordText = password;
        }

        [Then(@"I should see error message (.*) about invalid login or password")]
        public void ThenIShouldSeeErrorMessageAboutInvalidLoginOrPassw0rd(string errorMessage)
        {
            Assert.That(errorMessage, Is.EqualTo(_errorLoginPage.ErrorMessage));
        }

        [Given(@"I enter following parameters on Login page \(weak\)")]
        public void GivenIEnterFollowingParametersOnLoginPageWeak(Table table)
        {
            _loginPage.BoxName = table.Rows.First(row => row["field"] == "login")["value"];
            _loginPage.DomainName = table.Rows.First(row => row["field"] == "domain")["value"];
            _loginPage.PasswordText = table.Rows.First(row => row["field"] == "password")["value"];
        }

        [Given(@"I enter following parameters on Login page \(strong\)")]
        public void GivenIEnterFollowingParametersOnLoginPageStrong(Table table)
        {
            var fields = table.CreateInstance<MailFields>();

            _loginPage.BoxName = fields.Login;
            _loginPage.DomainName = fields.Domain;
            _loginPage.PasswordText = fields.Password;
        }

        [Given(@"I enter following parameters on Login page \(dynamic\)")]
        public void GivenIEnterFollowingParametersOnLoginPageDynamic(Table table)
        {
            dynamic fields = table.CreateDynamicInstance();

            _loginPage.BoxName = fields.login;
            _loginPage.DomainName = fields.domain;
            _loginPage.PasswordText = fields.password;
        }

        [Given(@"I enter a correct mailbox login with saving into ScenarioContext")]
        [Scope(Tag = "not_thread_safe")]
        public void GivenIEnterACorrectMailboxLoginWithSavingIntoScenarioContextNotThreadSave()
        {
            ScenarioContext.Current["ExpectedMail"] = Resources.Login;

            _loginPage.BoxName = Resources.Login;
        }

        [Given(@"I enter a correct mailbox domain with saving into ScenarioContext")]
        [Scope(Tag = "not_thread_safe")]
        public void GivenIEnterACorrectMailboxDomainWithSavingIntoScenarioContextNotThreadSave()
        {
            ScenarioContext.Current["ExpectedMail"] += Resources.Domain;

            _loginPage.DomainName = Resources.Domain;
        }

        [Then(@"I should see my correct e-mail address in the header of site, using ScenarioContext")]
        [Scope(Tag = "not_thread_safe")]
        public void ThenIShouldSeeMyCorrectE_MailAddressInTheHeaderOfSiteUsingScenarioContextNotThreadSave()
        {
            string correctEmail = (string)ScenarioContext.Current["ExpectedMail"];
            correctEmail = correctEmail.ToLower();

            Assert.That(correctEmail, Is.EqualTo(_mainMailPage.UserEmail));
        }

        [Given(@"I enter a correct mailbox login with saving into ScenarioContext")]
        [Scope(Tag = "thread_safe")]
        public void GivenIEnterACorrectMailboxLoginWithSavingIntoScenarioContextThreadSave()
        {
            this.ScenarioContext["ExpectedMail"] = Resources.Login;

            _loginPage.BoxName = Resources.Login;
        }

        [Given(@"I enter a correct mailbox domain with saving into ScenarioContext")]
        [Scope(Tag = "thread_safe")]
        public void GivenIEnterACorrectMailboxDomainWithSavingIntoScenarioContextThreadSave()
        {
            this.ScenarioContext["ExpectedMail"] += Resources.Domain;

            _loginPage.DomainName = Resources.Domain;
        }

        [Then(@"I should see my correct e-mail address in the header of site, using ScenarioContext")]
        [Scope(Tag = "thread_safe")]
        public void ThenIShouldSeeMyCorrectE_MailAddressInTheHeaderOfSiteUsingScenarioContextThreadSave()
        {
            string correctEmail = (string)this.ScenarioContext["ExpectedMail"];
            correctEmail = correctEmail.ToLower();

            Assert.That(correctEmail, Is.EqualTo(_mainMailPage.UserEmail));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            _driver.Dispose();
        }
    }
}

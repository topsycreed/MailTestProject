using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using DemoMail.Test.Properties;
using System.Linq;
using DemoMail.Test.Support;
using DemoMail.Test.PageObjects;
using System;
using DemoMail.Test.WrapperFactory;

namespace DemoMail_Nunit.Test
{
    [Binding]
    public class MailSteps : TechTalk.SpecFlow.Steps
    {
        [Given(@"I am on the mail site with (.*) browser")]
        public void GivenIAmOnTheMailSiteWithBrowser(string browser)
        {
            WebDriverFactory.InitDriver(browser);
            WebDriverFactory.Driver.Manage().Window.Maximize();

            Page.Login.NavigateTo();
            Page.Login.DeselectAuthenticationRemembering();
        }

        [Given(@"I enter a mailbox login (.*)")]
        public void GivenIEnterAMailboxLoginJohnDoe(string login)
        {
            Page.Login.BoxName = login;
        }

        [Given(@"I enter a mailbox domain (.*)")]
        public void GivenIEnterAMailboxDomainList_Ru(string domain)
        {
            Page.Login.DomainName = domain;
        }

        [Given(@"I enter a mailbox password (.*)")]
        public void GivenIEnterAMailboxPasswordINeedSomePassword(string password)
        {
            Page.Login.PasswordText = password;
        }

        [Given(@"I select that I have not authentication remembering")]
        public void GivenISelectThatIHaveNotAuthenticationRemembering()
        {
            Page.Login.DeselectAuthenticationRemembering();
        }

        [When(@"I submit my login data")]
        public void WhenISubmitMyLoginData()
        {
            Page.Login.SubmitLogin();
        }

        [When(@"I submit my login data")]
        [Scope(Tag = "invalid_login_or_password")]
        public void WhenISubmitMyInvalidLoginData()
        {
            Page.Login.SubmitInvalidLogin();
        }

        [Then(@"I should see my e-mail address (.*) in the header of site")]
        public void ThenIShouldSeeMyE_MailAddressJohnDoeList_RuInTheHeaderOfSite(string correctEmail)
        {
            correctEmail = correctEmail.ToLower();

            Assert.That(correctEmail, Is.EqualTo(Page.MainMale.UserEmail));
        }

        [Given(@"I enter a correct mailbox login")]
        public void GivenIEnterACorrectMailboxLogin()
        {
            Page.Login.BoxName = Resources.Login;
        }

        [Given(@"I enter a correct mailbox domain")]
        public void GivenIEnterACorrectMailboxDomain()
        {
            Page.Login.DomainName = Resources.Domain;

        }

        [Given(@"I enter a correct mailbox password")]
        public void GivenIEnterACorrectMailboxPassword()
        {
            Page.Login.PasswordText = Resources.Password;
        }

        [Given(@"I enter a incorrect mailbox (.*) password")]
        public void GivenIEnterAIncorrectMailboxINeedSomePassword(string password)
        {
            Page.Login.PasswordText = password;
        }

        [Then(@"I should see error message (.*) about invalid login or password")]
        public void ThenIShouldSeeErrorMessageAboutInvalidLoginOrPassw0rd(string errorMessage)
        {
            Assert.That(errorMessage, Is.EqualTo(Page.ErrorLogin.ErrorMessage));
        }

        [Given(@"I enter following parameters on Login page \(weak\)")]
        public void GivenIEnterFollowingParametersOnLoginPageWeak(Table table)
        {
            Page.Login.BoxName = table.Rows.First(row => row["field"] == "login")["value"];
            Page.Login.DomainName = table.Rows.First(row => row["field"] == "domain")["value"];
            Page.Login.PasswordText = table.Rows.First(row => row["field"] == "password")["value"];
        }

        [Given(@"I enter following parameters on Login page \(strong\)")]
        public void GivenIEnterFollowingParametersOnLoginPageStrong(Table table)
        {
            var fields = table.CreateInstance<MailFields>();

            Page.Login.BoxName = fields.Login;
            Page.Login.DomainName = fields.Domain;
            Page.Login.PasswordText = fields.Password;
        }

        [Given(@"I enter following parameters on Login page \(dynamic\)")]
        public void GivenIEnterFollowingParametersOnLoginPageDynamic(Table table)
        {
            dynamic fields = table.CreateDynamicInstance();

            Page.Login.BoxName = fields.login;
            Page.Login.DomainName = fields.domain;
            Page.Login.PasswordText = fields.password;
        }

        [Given(@"I enter a correct mailbox login with saving into ScenarioContext")]
        [Scope(Tag = "not_thread_safe")]
        public void GivenIEnterACorrectMailboxLoginWithSavingIntoScenarioContextNotThreadSave()
        {
            ScenarioContext.Current["ExpectedMail"] = Resources.Login;

            Page.Login.BoxName = Resources.Login;
        }

        [Given(@"I enter a correct mailbox domain with saving into ScenarioContext")]
        [Scope(Tag = "not_thread_safe")]
        public void GivenIEnterACorrectMailboxDomainWithSavingIntoScenarioContextNotThreadSave()
        {
            ScenarioContext.Current["ExpectedMail"] += Resources.Domain;

            Page.Login.DomainName = Resources.Domain;
        }

        [Then(@"I should see my correct e-mail address in the header of site, using ScenarioContext")]
        [Scope(Tag = "not_thread_safe")]
        public void ThenIShouldSeeMyCorrectE_MailAddressInTheHeaderOfSiteUsingScenarioContextNotThreadSave()
        {
            string correctEmail = (string)ScenarioContext.Current["ExpectedMail"];
            correctEmail = correctEmail.ToLower();

            Assert.That(correctEmail, Is.EqualTo(Page.MainMale.UserEmail));
        }

        [Given(@"I enter a correct mailbox login with saving into ScenarioContext")]
        [Scope(Tag = "thread_safe")]
        public void GivenIEnterACorrectMailboxLoginWithSavingIntoScenarioContextThreadSave()
        {
            this.ScenarioContext["ExpectedMail"] = Resources.Login;

            Page.Login.BoxName = Resources.Login;
        }

        [Given(@"I enter a correct mailbox domain with saving into ScenarioContext")]
        [Scope(Tag = "thread_safe")]
        public void GivenIEnterACorrectMailboxDomainWithSavingIntoScenarioContextThreadSave()
        {
            this.ScenarioContext["ExpectedMail"] += Resources.Domain;

            Page.Login.DomainName = Resources.Domain;
        }

        [Then(@"I should see my correct e-mail address in the header of site, using ScenarioContext")]
        [Scope(Tag = "thread_safe")]
        public void ThenIShouldSeeMyCorrectE_MailAddressInTheHeaderOfSiteUsingScenarioContextThreadSave()
        {
            string correctEmail = (string)this.ScenarioContext["ExpectedMail"];
            correctEmail = correctEmail.ToLower();

            Assert.That(correctEmail, Is.EqualTo(Page.MainMale.UserEmail));
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            WebDriverFactory.CloseDriver();
        }
    }
}

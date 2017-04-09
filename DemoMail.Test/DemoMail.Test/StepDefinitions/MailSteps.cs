using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;
using DemoMail.Test.Properties;
using System.Linq;
using DemoMail.Test.Support;
using DemoMail.Test.PageObjects;
using DemoMail.Test.WrapperFactory;
using OpenQA.Selenium;

namespace DemoMail_Nunit.Test
{
    [Binding]
    public class MailSteps : TechTalk.SpecFlow.Steps
    {
        #region Background

        [Given(@"I am on the mail site with (.*) browser")]
        public void GivenIAmOnTheMailSiteWithBrowser(string browser)
        {
            WebDriverFactory.InitDriver(browser);
            WebDriverFactory.Driver.Manage().Window.Maximize();

            Page.Login.NavigateTo();
        }

        #endregion

    #region Login

        #region Succsesful login to mail site using parameterization method input

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

        [Then(@"I should see my e-mail address (.*) in the header of site")]
        public void ThenIShouldSeeMyE_MailAddressJohnDoeList_RuInTheHeaderOfSite(string correctEmail)
        {
            correctEmail = correctEmail.ToLower();

            Assert.That(correctEmail, Is.EqualTo(Page.MainMail.UserEmail));
        }

        #endregion

        #region Succsesful login to mail site using resources

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

        #endregion

        #region Succsesful login to mail site using resources and ScenarioContext (not thread safe) to share data between steps

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

            Assert.That(correctEmail, Is.EqualTo(Page.MainMail.UserEmail));
        }

        #endregion

        #region Succsesful login to mail site using resources and ScenarioContext (thread safe) to share data between steps

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

            Assert.That(correctEmail, Is.EqualTo(Page.MainMail.UserEmail));
        }

        #endregion

        #region Succsesful login to mail site using weakly-typed step data table

        [Given(@"I enter following parameters on Login page \(weak\)")]
        public void GivenIEnterFollowingParametersOnLoginPageWeak(Table table)
        {
            Page.Login.BoxName = table.Rows.First(row => row["field"] == "login")["value"];
            Page.Login.DomainName = table.Rows.First(row => row["field"] == "domain")["value"];
            Page.Login.PasswordText = table.Rows.First(row => row["field"] == "password")["value"];
        }

        #endregion

        #region Succsesful login to mail site using strongly-typed step data table

        [Given(@"I enter following parameters on Login page \(strong\)")]
        public void GivenIEnterFollowingParametersOnLoginPageStrong(Table table)
        {
            var fields = table.CreateInstance<MailFields>();

            Page.Login.BoxName = fields.Login;
            Page.Login.DomainName = fields.Domain;
            Page.Login.PasswordText = fields.Password;
        }

        #endregion

        #region Succsesful login to mail site using dynamic step data table

        [Given(@"I enter following parameters on Login page \(dynamic\)")]
        public void GivenIEnterFollowingParametersOnLoginPageDynamic(Table table)
        {
            dynamic fields = table.CreateDynamicInstance();

            Page.Login.BoxName = fields.login;
            Page.Login.DomainName = fields.domain;
            Page.Login.PasswordText = fields.password;
        }

        #endregion

        #region Login to mail site with incorrect password

        [Given(@"I enter a incorrect mailbox (.*) password")]
        public void GivenIEnterAIncorrectMailboxINeedSomePassword(string password)
        {
            Page.Login.PasswordText = password;
        }

        [When(@"I submit my login data")]
        [Scope(Tag = "invalid_login_or_password")]
        public void WhenISubmitMyInvalidLoginData()
        {
            Page.Login.SubmitInvalidLogin();
        }

        [Then(@"I should see error message (.*) about invalid login or password")]
        public void ThenIShouldSeeErrorMessageAboutInvalidLoginOrPassw0rd(string errorMessage)
        {
            Assert.That(errorMessage, Is.EqualTo(Page.ErrorLogin.ErrorMessage));
        }

        #endregion

    #endregion

    #region Draft

        #region Succesful saving draft e-mail

        //This is duplicate method becouse possible SpecFlow error
        [Given(@"I submit my login data")]
        [Scope(Tag = "draft")]
        public void GivenISubmitMyLoginData()
        {
            Page.Login.SubmitLogin();
        }

        [Given(@"I succesfully login to mail site")]
        public void GivenISuccesfullyLoginToMailSite()
        {
            Given(string.Format("I enter a correct mailbox login"));
            Given(string.Format("I enter a correct mailbox domain"));
            Given(string.Format("I enter a correct mailbox password"));
            Given(string.Format("I select that I have not authentication remembering"));
            //This is a SpecFlow bug? I can't use When in Given method. So I create duplicate method with Given
            //When(string.Format("I submit my login data")); 
            Given(string.Format("I submit my login data"));
        }

        [Given(@"I select a new e-mail")]
        public void GivenISelectANewE_Mail()
        {
            Page.MainMail.WriteMail();
        }

        [Given(@"I enter a whom of the message (.*)")]
        public void GivenIEnterAWhomOfTheMessage(string toWhom)
        {
            this.ScenarioContext["ToWhom"] = toWhom;
            Page.MainMail.ToWhom = (string)this.ScenarioContext["ToWhom"];
        }

        [Given(@"I enter a theme of the message (.*)")]
        public void GivenIEnterAThemeOfTheMessage(string theme)
        {
            this.ScenarioContext["Theme"] = theme;
            Page.MainMail.Theme = (string)this.ScenarioContext["Theme"];
        }

        [Given(@"I enter a body of the message (.*)")]
        public void GivenIEnterABodyOfTheMessage(string body)
        {
            this.ScenarioContext["Body"] = body;
            Page.MainMail.Body = (string)this.ScenarioContext["Body"];
        }

        [When(@"I submit saving my message")]
        public void WhenISubmitSavingMyMessage()
        {
            Page.MainMail.SubmitSaving();
        }

        [Then(@"I should see a confirmation of saving")]
        public void ThenIShouldSeeAConfirmationOfSaving()
        {
            Assert.That(Page.MainMail.SaveStatus, Does.Contain("Сохранено в черновиках в"));
        }

        #endregion

        #region Viewing draft e-mails after saving

        //This is duplicate method becouse possible SpecFlow error
        [Given(@"I submit saving my message")]
        [Scope(Tag = "draft")]
        public void GivenISubmitSavingMyMessage()
        {
            Page.MainMail.SubmitSaving();
        }

        [Given(@"I succesfully saving draft e-mail")]
        public void GivenISuccesfullySavingDraftE_Mail()
        {
            Given(string.Format("I select a new e-mail"));
            Given(string.Format("I enter a whom of the message johndoe1990@list.ru"));
            Given(string.Format("I enter a theme of the message Test"));
            Given(string.Format("I enter a body of the message Hello, Mail World!"));
            Given(string.Format("I submit saving my message"));
        }

        [When(@"I select drafts messages")]
        public void WhenISelectDraftsMessages()
        {
            Page.MainMail.OpenDraft();
        }

        [Then(@"I should see a first message that equals my saved draft")]
        public void ThenIShouldSeeAFirstMessageThatEqualsMySavedDraft()
        {
            //Actual data in saved draft
            string toWhom = Page.MainMail.DraftTitle;
            string subject = Page.MainMail.DraftSubject;
            string body = Page.MainMail.DraftBody;

            //Data, added in saving draft
            string _toWhom = (string)this.ScenarioContext["ToWhom"];
            string _subject = (string)this.ScenarioContext["Theme"];
            string _body = (string)this.ScenarioContext["Body"];

            Assert.That(toWhom, Is.EqualTo("johndoe1990@list.ru"));
            Assert.That(subject, Does.Contain(_subject));
            Assert.That(body, Does.Contain("Hello, Mail World!"));
        }

        #endregion

    #endregion

        [AfterScenario]
        public void DisposeWebDriver()
        {
            WebDriverFactory.CloseDriver();
        }
    }
}

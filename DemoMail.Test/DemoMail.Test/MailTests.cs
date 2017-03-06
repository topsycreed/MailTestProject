using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace DemoMail.Test
{
    public class MailTests
    {
        [Fact]
        public void StartSite()
        {
            using (IWebDriver driver = new ChromeDriver(@"C:\SeleniumDrivers"))
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://mail.ru/");

                //IWebElement submitButton = driver.FindElement(By.Id("mailbox__auth__button"));
                //submitButton.Click();

                Assert.Equal("Mail.Ru: почта, поиск в интернете, новости, игры", driver.Title);
            }
        }

        [Fact]
        public void Login()
        {
            using (IWebDriver driver = new ChromeDriver(@"C:\SeleniumDrivers"))
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://mail.ru/");

                IWebElement boxName = driver.FindElement(By.Id("mailbox__login"));
                boxName.SendKeys("JohnDoe1990");
                SelectElement domain = new SelectElement(driver.FindElement(By.Id("mailbox__login__domain")));
                domain.SelectByText("@list.ru");
                IWebElement password = driver.FindElement(By.Id("mailbox__password"));
                password.SendKeys("INeedSomePassword");
                IWebElement saveAuth = driver.FindElement(By.Id("mailbox__auth__remember__checkbox"));
                saveAuth.Click();
                IWebElement submitButton = driver.FindElement(By.Id("mailbox__auth__button"));
                submitButton.Click();

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                IWebElement userEmail = driver.FindElement(By.Id("PH_user-email"));

                Assert.Equal("johndoe1990@list.ru", userEmail.Text);
            }
        }

        [Fact]
        public void SaveDraft()
        {
            using (IWebDriver driver = new ChromeDriver(@"C:\SeleniumDrivers"))
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://mail.ru/");

                IWebElement boxName = driver.FindElement(By.Id("mailbox__login"));
                SelectElement domain = new SelectElement(driver.FindElement(By.Id("mailbox__login__domain")));
                IWebElement password = driver.FindElement(By.Id("mailbox__password"));
                IWebElement submitButton = driver.FindElement(By.Id("mailbox__auth__button"));
                IWebElement saveAuth = driver.FindElement(By.Id("mailbox__auth__remember__checkbox"));

                //*[@id="PH_user-email"]
                boxName.SendKeys("JohnDoe1990");
                domain.SelectByText("@list.ru");
                password.SendKeys("INeedSomePassword");
                saveAuth.Click();
                submitButton.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                IWebElement newEmailButton = driver.FindElement(By.Id("b-toolbar__left"));
                newEmailButton.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                
                //IWebElement mailText = driver.FindElement(By.CssSelector("#tinymce"));
                

                IWebElement frameElement = driver.FindElement(By.XPath("//iframe[contains(@id,'toolkit')]"));
                driver.SwitchTo().Frame(frameElement);
                //driver.SwitchTo().Frame(9);
                IWebElement mailText = driver.FindElement(By.CssSelector("#tinymce"));
                mailText.SendKeys("TestTestTest");
                driver.SwitchTo().DefaultContent();

                IWebElement toWhom = driver.FindElement(By.CssSelector("textarea.js-input.compose__labels__input"));
                IWebElement subject = driver.FindElement(By.Name("Subject"));
                IWebElement saveButton = driver.FindElement(By.XPath("//div[contains(@id,'b-toolbar__right')]//*/span[contains(@class,'b-toolbar__btn__text') and (text() = 'Сохранить')]"));
                //IWebElement sendButton = driver.FindElement(By.XPath("//div[contains(@id,'b-toolbar__right')]//*/span[contains(@class,'b-toolbar__btn__text') and (text() = 'Отправить')]"));
                toWhom.SendKeys("JohnDoe1990@list.ru");
                subject.SendKeys("TestingDraftMail");
                saveButton.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
                //IWebElement savedButton = driver.FindElement(By.XPath("//span[contains(@class, 'b-nav__item__text') and (text() = 'Черновики')]"));

                IWebElement savedButton = driver.FindElement(By.XPath("//div[contains(@class, 'b-toolbar__message') and (text() = 'Сохранено в ')]"));

                //savedButton.Click();
                //sendButton.Click();
                Assert.Contains("Сохранено в черновиках в", savedButton.Text);
            }
        }

        [Fact]
        public void CheckSavedDraft()
        {
            using (IWebDriver driver = new ChromeDriver(@"C:\SeleniumDrivers"))
            {
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://mail.ru/");

                IWebElement boxName = driver.FindElement(By.Id("mailbox__login"));
                SelectElement domain = new SelectElement(driver.FindElement(By.Id("mailbox__login__domain")));
                IWebElement password = driver.FindElement(By.Id("mailbox__password"));
                IWebElement submitButton = driver.FindElement(By.Id("mailbox__auth__button"));
                IWebElement saveAuth = driver.FindElement(By.Id("mailbox__auth__remember__checkbox"));

                //*[@id="PH_user-email"]
                boxName.SendKeys("JohnDoe1990");
                domain.SelectByText("@list.ru");
                password.SendKeys("INeedSomePassword");
                saveAuth.Click();
                submitButton.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

                IWebElement newEmailButton = driver.FindElement(By.Id("b-toolbar__left"));
                newEmailButton.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));


                //IWebElement mailText = driver.FindElement(By.CssSelector("#tinymce"));


                IWebElement frameElement = driver.FindElement(By.XPath("//iframe[contains(@id,'toolkit')]"));
                driver.SwitchTo().Frame(frameElement);
                IWebElement mailText = driver.FindElement(By.CssSelector("#tinymce"));
                mailText.SendKeys("TestTestTest");
                driver.SwitchTo().DefaultContent();

                IWebElement toWhom = driver.FindElement(By.CssSelector("textarea.js-input.compose__labels__input"));
                IWebElement subject = driver.FindElement(By.Name("Subject"));
                //IWebElement sendButton = driver.FindElement(By.XPath("//div[contains(@id,'b-toolbar__right')]//*/span[contains(@class,'b-toolbar__btn__text') and (text() = 'Отправить')]"));
                toWhom.SendKeys("JohnDoe1990@list.ru");
                subject.SendKeys("TestingDraftMail");
                IWebElement saveButton = driver.FindElement(By.XPath("//div[contains(@id,'b-toolbar__right')]//*/span[contains(@class,'b-toolbar__btn__text') and (text() = 'Сохранить')]"));
                saveButton.Click();
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));


                IWebElement saveMessage = driver.FindElement(By.XPath("//div[contains(@class, 'b-toolbar__message') and (text() = 'Сохранено в ')]"));

                ////sendButton.Click();
                Assert.Contains("Сохранено в черновиках в", saveMessage.Text);

                //IWebElement draftsButton = driver.FindElement(By.XPath("//span[contains(@class, 'b-nav__item__text') and (text() = 'Черновики')]"));
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        IWebElement draftsButton = driver.FindElement(By.XPath("//span[contains(@class, 'b-nav__item__text') and (text() = 'Черновики')]"));
                        draftsButton.Click();
                    }
                    catch (StaleElementReferenceException e)
                    {
                        continue;
                    }
                }

                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(50));

                IWebElement draftMailName = driver.FindElement(By.XPath("(//div[contains(@class, 'b-datalist__item__addr') and (text() = 'JohnDoe1990@list.ru')])[1]"));
                IWebElement draftMailSubject = driver.FindElement(By.XPath("(//div[contains(@class, 'b-datalist__item__subj') and (text() = 'TestingDraftMail')])[1]"));
                IWebElement draftMailText = driver.FindElement(By.XPath("(//span[contains(@class, 'b-datalist__item__subj__snippet') and (text() = 'TestTestTest -- John Doe')])[1]"));

                Assert.Equal("JohnDoe1990@list.ru", draftMailName.Text);
                Assert.Contains("TestingDraftMail", draftMailSubject.Text);
                Assert.Contains("TestTestTest", draftMailText.Text);

                IWebElement logoutButton = driver.FindElement(By.XPath("//*[@id='PH_logoutLink']"));
                logoutButton.Click();

                IWebElement boxNameAfterLogout = driver.FindElement(By.Id("mailbox__login"));
                Assert.Equal("input", boxNameAfterLogout.TagName);
            }
        }
    }
}
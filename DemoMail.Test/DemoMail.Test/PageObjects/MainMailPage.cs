using DemoMail.Test.WrapperFactory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;

namespace DemoMail_Nunit.Test
{
    public class MainMailPage
    {
        [FindsBy(How = How.Id, Using = "PH_user-email")]
        private IWebElement _userEmail;

        [FindsBy(How = How.ClassName, Using = "b-toolbar__btn__text b-toolbar__btn__text_pad")]
        private IWebElement _submitNewMail;

        [FindsBy(How = How.XPath, Using = "//span[text() = 'Написать письмо']")]
        private IWebElement _writeMail;

        [FindsBy(How = How.XPath, Using = "//textarea[@data-original-name='To']")]
        private IWebElement _toWhom;

        [FindsBy(How = How.XPath, Using = "//input[@name='Subject']")]
        private IWebElement _theme;

        [FindsBy(How = How.XPath, Using = "//iframe[contains(@id,'toolkit')]")]
        private IWebElement _frameElement;

        [FindsBy(How = How.CssSelector, Using = "#tinymce")]
        private IWebElement _body;

        [FindsBy(How = How.XPath, Using = "//span[text()='Сохранить']")]
        private IWebElement _submitSaving;

        [FindsBy(How = How.XPath, Using = "//div[(@class='b-toolbar__message') and (text() = 'Сохранено в ')]")]
        private IWebElement _saveStatus;

        private WebDriverWait wait = new WebDriverWait(WebDriverFactory.Driver, TimeSpan.FromSeconds(10));

        public string UserEmail
        {
            get
            {
                int count = 1;

                while (count < 10)
                {
                    try
                    {
                        return _userEmail.Text;
                    }
                    catch (StaleElementReferenceException)
                    {
                        count++;
                        continue;
                    }
                    catch (TargetInvocationException)
                    {
                        count++;
                        continue;
                    }
                }
                return "Error in MainMailPage.UserEmail";
            }
        }

        public void WriteMail()
        {
            _writeMail.Click();
        }

        public string ToWhom
        {
            set
            {
                _toWhom.SendKeys(value);
            }
        }

        public string Theme
        {
            set
            {
                _theme.SendKeys(value);
            }
        }

        public string Body
        {
            set
            {
                WebDriverFactory.Driver.SwitchTo().Frame(_frameElement);
                _body.SendKeys(value);
                WebDriverFactory.Driver.SwitchTo().DefaultContent();
            }
        }

        public void SubmitSaving()
        {
            _submitSaving.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[(@class='b-toolbar__message') and (text() = 'Сохранено в ')]")));
        }

        public string SaveStatus
        {
            get
            {
                return _saveStatus.Text;
            }
        }
    }
}

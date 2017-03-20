using DemoMail.Test.WrapperFactory;
using DemoMail_Nunit.Test;
using OpenQA.Selenium.Support.PageObjects;

namespace DemoMail.Test.PageObjects
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(WebDriverFactory.Driver, page);
            return page;
        }

        public static LoginPage Login
        {
            get { return GetPage<LoginPage>(); }
        }

        public static ErrorLoginPage ErrorLogin
        {
            get { return GetPage<ErrorLoginPage>(); }
        }

        public static MainMailPage MainMale
        {
            get { return GetPage<MainMailPage>(); }
        }
    }
}

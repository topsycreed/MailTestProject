using DemoMail.Test.WrapperFactory;
using OpenQA.Selenium;
using System;
using System.IO;

namespace DemoMail.Test.Support
{
    public class Screenshots
    {
        public static void TakeScreenshot()
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "Screenshots" + @"\";
                string name = "SeleniumDemoMail_LoginPage_" + DateTime.Now.ToString("hmmsstt") + ".png";

                Screenshot ss = ((ITakesScreenshot)WebDriverFactory.Driver).GetScreenshot();
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                ss.SaveAsFile(path + name, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
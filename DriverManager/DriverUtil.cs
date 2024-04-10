using System.IO;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace Test_Framework.DriverManager
{
    internal class DriverUtil
    {
        private readonly ChromeOptions chromeOptions = new ChromeOptions();
        public string GetDriverPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public ChromeOptions GetDriverOptions()
        {
            chromeOptions.AddArguments("no-sandbox");
            chromeOptions.AddArguments("--start-maximized");
            chromeOptions.AddArguments("--disable-blink-features=BlockCredentialedSubresources");
            chromeOptions.AddArguments("--disable-notifications");
            chromeOptions.AddArguments("enable-automation");

            return chromeOptions;
        }
    }
}
 
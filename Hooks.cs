using BoDi;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test_Framework.DriverManager
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private readonly DriverUtil _driverUtil = new DriverUtil();
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _webDriver;

        public Hooks(IObjectContainer container, ScenarioContext scenarioCtx)
        {
            _objectContainer = container;
            _scenarioContext = scenarioCtx;
        }

        [AfterScenario(Order = 100)]
        public void Dispose()
        {
            _webDriver.Close();
            _webDriver.Quit();
        }

        [BeforeScenario]
        public void LoadDriver()
        {
            _webDriver = CreateChromeDriver();

            _objectContainer.RegisterInstanceAs(_webDriver, typeof(IWebDriver));
        }

        private ChromeDriver CreateChromeDriver()
        {
            var options = _driverUtil.GetDriverOptions();
            var chromeDriverPath = _driverUtil.GetDriverPath();
            var driver = new ChromeDriver(chromeDriverPath, options);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            return driver;
        }
    }
}

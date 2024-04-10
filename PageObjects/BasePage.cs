using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
namespace Test_Framework.PageObjects
{
    public class BasePage
    {
        protected IWebDriver _webDriver;
        protected WebDriverWait _wait;
        protected Actions _actions;
        protected IJavaScriptExecutor _jsExecutor;
       
        public BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(30));
            _actions = new Actions(webDriver);
            _jsExecutor = (IJavaScriptExecutor)webDriver;
        }

        public void JSClick(IWebElement element)
        {
            _jsExecutor.ExecuteScript("arguments[0].click();", element);
        }
    }
}

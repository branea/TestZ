using OpenQA.Selenium;
using System;

namespace Test_Framework
{
    public class Navigator
    {
        protected IWebDriver _webDriver;
        
        public Navigator(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public T GoTo<T>(Uri url)
        {
            _webDriver.Navigate().GoToUrl(url);

            return (T)Activator.CreateInstance(typeof(T), _webDriver);
        }
    }
}

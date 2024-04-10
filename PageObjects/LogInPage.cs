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
    internal class LogInPage : BasePage
    {
        public LogInPage(IWebDriver webDriver) : base(webDriver)
        {
            
        }

        private IWebElement LogInButton => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("login-button")));
        private IWebElement UserName => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("user-name")));
        private IWebElement Password => _wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("password")));
        private IWebElement LockedUserMessage(string message) => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[contains(text(), '{message}')]")));
        private IWebElement EmptyUsernameMessage(string message) => _wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//*[contains(text(), '{message}')]")));
        
        
        public void ClickOnLogInButton()
        {
            _actions.MoveToElement(LogInButton);
            LogInButton.Click();
        }

        public void FillTheUsername(string username)
        {
            _actions.MoveToElement(UserName);
            UserName.SendKeys(username);
        }

        public void FillThePassword(string password)
        {
            _actions.MoveToElement(Password);
            Password.SendKeys(password);
        }

        public bool LockedUserMessageIsDisplayed(string message)
        {
            return LockedUserMessage(message).Displayed;
        }

        public bool EmptyUsernameMessageIsDisplayed(string message)
        {
            return EmptyUsernameMessage(message).Displayed;
        }

       
    }
}

using Google.Protobuf.WellKnownTypes;
using OpenQA.Selenium;
using System;
using System.Threading;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace Test_Framework.PageObjects
{
    internal class CartPage : BasePage
    {
        public CartPage(IWebDriver webDriver) : base(webDriver)
        {

        }

        private IWebElement CheckoutButton => _wait.Until(ExpectedConditions.ElementIsVisible(By.Id("checkout")));

        public CheckoutPage ClickOnCheckout()
        {
            CheckoutButton.Click();

            return new CheckoutPage(_webDriver);
        }
    }
}

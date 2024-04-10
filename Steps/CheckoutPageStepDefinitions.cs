using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Test_Framework.PageObjects;

namespace Test_Framework.Steps
{
    [Binding, Scope(Feature = "LogIn"), Scope(Feature = "CheckoutPage")]
    public class CheckoutPageStepDefinitions : BasePage
    {
        private CheckoutPage _checkoutPage;

        public CheckoutPageStepDefinitions(Navigator navigator, IWebDriver webDriver) : base(webDriver)
        {
            _checkoutPage = new CheckoutPage(webDriver);
        }

        [When(@"I click on the continue button")]
        public void WhenIClickOnContinueButton()
        {
            _checkoutPage.ClickOnContinueButton();
        }

        [Then(@"I can see successfully order message")]
        public void ThenICanSeeSuccessfullyOrderMessage()
        {
            Assert.True(_checkoutPage.OrderIsSuccessful());
        }

        [When(@"I click on the finish button")]
        public void WhenIClickOnTheFinishButton()
        {
            _checkoutPage.ClickOnFinishButton();
        }

    }
}
